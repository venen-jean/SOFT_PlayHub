using Projekt.application;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Projekt.pages
{
    public partial class RoleForm : GenericListForm<hrbac_roles>
    {
        private static readonly string connString =
            "data source=10.20.20.9;initial catalog=g4_6it23;persist security info=True;user id=g4_6it23;password=8911,LKm,Rr;trustservercertificate=True;MultipleActiveResultSets=True;";

        public RoleForm()
        {
            InitializeComponent();
            BindingSource = hrbac_rolesBindingSource;
            LoadData();
        }

        private void CreateRoleBtn_Click(object sender, EventArgs e)
        {
            var name = nameTextBox.Text;

            if (string.IsNullOrWhiteSpace(name))
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
            comboBox1.DataSource = GetTableNames();
        }

        private List<string> GetTableNames()
        {
            return globalstore.Daten.Database
                .SqlQuery<string>(
                    "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'")
                .ToList();
        }

        // ===============================================

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null) return;

            string tableName = comboBox1.SelectedItem.ToString();

            flowLayoutPanel1.Controls.Clear();

            var dgv = CreateDataGridView();
            var inputPanel = CreateInputPanel();

            flowLayoutPanel1.Controls.Add(dgv);
            flowLayoutPanel1.Controls.Add(inputPanel);

            LoadTableData(tableName, dgv);
            GenerateInputs(tableName, inputPanel);
        }

        private DataGridView CreateDataGridView()
        {
            return new DataGridView
            {
                Dock = DockStyle.Top,
                Height = 250,
                Width = 800,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
        }

        private FlowLayoutPanel CreateInputPanel()
        {
            return new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true
            };
        }

        private void LoadTableData(string tableName, DataGridView dgv)
        {
            using (var conn = CreateConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = $"SELECT * FROM [{tableName}]";

                using (var reader = cmd.ExecuteReader())
                {
                    var dt = new DataTable();
                    dt.Load(reader);
                    dgv.DataSource = dt;
                }
            }
        }

        private void GenerateInputs(string tableName, FlowLayoutPanel panel)
        {
            using (var conn = CreateConnection())
            {
                var schema = conn.GetSchema("Columns", new[] { null, null, tableName, null });

                foreach (DataRow row in schema.Rows)
                {
                    string columnName = row["COLUMN_NAME"].ToString();

                    if (columnName.Equals("id", StringComparison.OrdinalIgnoreCase))
                        continue;

                    panel.Controls.Add(CreateLabel(columnName));
                    panel.Controls.Add(CreateTextBox(columnName));
                }

                panel.Controls.Add(CreateInsertButton(tableName, panel));
            }
        }

        private Label CreateLabel(string text)
        {
            return new Label
            {
                Text = text,
                Width = 100
            };
        }

        private TextBox CreateTextBox(string columnName)
        {
            return new TextBox
            {
                Name = "txt_" + columnName,
                Width = 150
            };
        }

        private Button CreateInsertButton(string tableName, FlowLayoutPanel panel)
        {
            var btn = new Button
            {
                Text = "Insert"
            };

            btn.Click += (s, e) => InsertRow(tableName, panel);

            return btn;
        }

        private void InsertRow(string tableName, FlowLayoutPanel panel)
        {
            var textboxes = panel.Controls.OfType<TextBox>().ToList();

            var columns = new List<string>();
            var parameters = new List<string>();

            using (var conn = CreateConnection())
            using (var cmd = conn.CreateCommand())
            {
                int i = 0;

                foreach (var tb in textboxes)
                {
                    string col = tb.Name.Replace("txt_", "");
                    string paramName = "@p" + i++;

                    columns.Add($"[{col}]");
                    parameters.Add(paramName);

                    cmd.Parameters.AddWithValue(paramName, tb.Text);
                }

                cmd.CommandText =
                    $"INSERT INTO [{tableName}] ({string.Join(",", columns)}) VALUES ({string.Join(",", parameters)})";

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Inserted!");
        }

        private SqlConnection CreateConnection()
        {
            var conn = new SqlConnection(connString);
            if (conn.State != ConnectionState.Open)
                conn.Open();

            return conn;
        }
    }
}