using Projekt.application;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Projekt.pages
{
    public partial class RoleForm : GenericListForm<hrbac_roles>
    {

        private static readonly string connString = "data source=10.20.20.9;initial catalog=g4_6it23;persist security info=True;user id=g4_6it23;password=8911,LKm,Rr;trustservercertificate=True;MultipleActiveResultSets=True;";

        public RoleForm()
        {
            InitializeComponent();
            BindingSource = hrbac_rolesBindingSource;
            LoadData();
        }

        private void CreateRoleBtn_Click(object sender, EventArgs e)
        {
            var name = nameTextBox.Text;

            if (string.IsNullOrEmpty(name))
            {
                ShowError("Name is required");
                return;
            }
        
            try
            {
                Service.Create(new hrbac_roles { name = name });
                ShowSuccess("Role created");
                nameTextBox.Clear();
                RefreshData();
            }
            catch (CrudServiceException ex)
            {
                ShowError(CrudService<hrbac_roles>.GetFullExceptionMessage(ex));
            }
        }

        private void Hrbac_rolesDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            OnCellClick((DataGridView)sender, e);
        }

        protected override Form CreateEditForm(hrbac_roles entity)
        {
            return new RoleEditForm(entity, BindingSource);
        }

        private void RoleForm_Load(object sender, EventArgs e)
        {
            var tables = globalstore.Daten.Database
                .SqlQuery<string>(
                    "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'")
                .ToList();

            comboBox1.DataSource = tables;
        }

        // ===============================================

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tableName = comboBox1.SelectedItem.ToString();

            flowLayoutPanel1.Controls.Clear(); // container panel on your form

            // Create DataGridView
            DataGridView dgv = new DataGridView
            {
                Dock = DockStyle.Top,
                Height = 250,
                Width = 800,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            flowLayoutPanel1.Controls.Add(dgv);

            // Create flow panel for inputs
            FlowLayoutPanel inputPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true
            };

            flowLayoutPanel1.Controls.Add(inputPanel);

            LoadTableData(tableName, dgv);
            GenerateInputs(tableName, inputPanel);
        }

        private void LoadTableData(string tableName, DataGridView dgv)
        {
            using (var conn = new SqlConnection(connString))
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"SELECT * FROM [{tableName}]";

                    using (var reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        dgv.DataSource = dt;
                    }
                }
            }
        }

        private void GenerateInputs(string tableName, FlowLayoutPanel panel)
        {
            using (var conn = new SqlConnection(connString))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                var schema = conn.GetSchema("Columns", new[] { null, null, tableName, null });

                foreach (DataRow row in schema.Rows)
                {
                    string columnName = row["COLUMN_NAME"].ToString();

                    if (columnName == "id") continue;

                    Label lbl = new Label
                    {
                        Text = columnName,
                        Width = 100
                    };

                    TextBox txt = new TextBox
                    {
                        Name = "txt_" + columnName,
                        Width = 150
                    };

                    panel.Controls.Add(lbl);
                    panel.Controls.Add(txt);
                }

                // Add button
                Button btn = new Button
                {
                    Text = "Insert"
                };

                btn.Click += (s, e) => InsertRow(tableName, panel);

                panel.Controls.Add(btn);
            }
        }

        private void InsertRow(string tableName, FlowLayoutPanel panel)
        {
            var textboxes = panel.Controls
                .OfType<TextBox>()
                .ToList();

            var columns = new List<string>();
            var values = new List<string>();

            foreach (var tb in panel.Controls.OfType<TextBox>())
            {
                string col = tb.Name.Replace("txt_", "");
                string val = tb.Text.Replace("'", "''"); // escape quotes

                columns.Add($"[{col}]");
                values.Add($"'{val}'");
            }

            string sql = $"INSERT INTO [{tableName}] ({string.Join(",", columns)}) VALUES ({string.Join(",", values)})";

            globalstore.Daten.Database.ExecuteSqlCommand(sql);

            MessageBox.Show("Inserted!");
        }
    }
}
