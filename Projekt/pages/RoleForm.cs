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
        public static readonly string connString =
            "data source=10.20.20.9;initial catalog=g4_6it23;persist security info=True;user id=g4_6it23;password=8911,LKm,Rr;trustservercertificate=True;MultipleActiveResultSets=True;";

        public RoleForm()
        {
            InitializeComponent();
            BindingSource = hrbac_rolesBindingSource;
            LoadData();
        }

        protected override Form CreateEditForm(hrbac_roles entity)
        {
            return new RoleEditForm(entity, BindingSource);
        }

        // ===============================================

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
            GenerateInputs(tableName, inputPanel, dgv);
        }

        private DataGridView CreateDataGridView()
        {
            var dgv = new DataGridView
            {
                Dock = DockStyle.Top,
                Height = 250,
                Width = 800,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            dgv.CellDoubleClick += DynamicGrid_CellDoubleClick;

            return dgv;
        }

        private void DynamicGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            var dgv = sender as DataGridView;

            if (e.RowIndex < 0) return;

            var rowView = dgv.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (rowView == null) return;

            string tableName = comboBox1.SelectedItem.ToString();

            var editForm = new DynamicEditForm(tableName, rowView.Row);
            editForm.FormClosed += (s, args) => RefreshGrid(tableName, dgv);

            editForm.ShowDialog();
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

                    var bs = new BindingSource();
                    bs.DataSource = dt;

                    dgv.DataSource = bs;
                }
            }
        }

        private void GenerateInputs(string tableName, FlowLayoutPanel panel, DataGridView dgv)
        {
            using (var conn = CreateConnection())
            {
                var schema = conn.GetSchema("Columns", new[] { null, null, tableName, null });
                var foreignKeys = DbUiHelper.GetForeignKeys(connString, tableName);

                foreach (DataRow row in schema.Rows)
                {
                    string columnName = row["COLUMN_NAME"].ToString();

                    if (columnName.Equals("id", StringComparison.OrdinalIgnoreCase))
                        continue;

                    panel.Controls.Add(CreateLabel(columnName));

                    if (foreignKeys.ContainsKey(columnName))
                    {
                        panel.Controls.Add(
                            DbUiHelper.CreateForeignKeyComboBox(connString, foreignKeys[columnName], columnName)
                        );
                    }
                    else
                    {
                        panel.Controls.Add(CreateTextBox(columnName));
                    }
                }

                var btn = CreateInsertButton(tableName, panel, dgv);
                panel.Controls.Add(btn);
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

        private Button CreateInsertButton(string tableName, FlowLayoutPanel panel, DataGridView dgv)
        {
            var btn = new Button
            {
                Text = "Insert"
            };

            btn.Click += (s, e) => InsertRow(tableName, panel, dgv);

            return btn;
        }

        private void RefreshGrid(string tableName, DataGridView dgv)
        {
            if (dgv.DataSource is BindingSource bs)
            {
                using (var conn = CreateConnection())
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"SELECT * FROM [{tableName}]";

                    using (var reader = cmd.ExecuteReader())
                    {
                        var dt = new DataTable();
                        dt.Load(reader);

                        bs.DataSource = dt;
                    }
                }
            }
        }

        private void InsertRow(string tableName, FlowLayoutPanel panel, DataGridView dgv)
        {
            var textboxes = panel.Controls.OfType<TextBox>().ToList();
            var comboboxes = panel.Controls.OfType<ComboBox>().ToList();

            var columns = new List<string>();
            var parameters = new List<string>();

            using (var conn = CreateConnection())
            using (var cmd = conn.CreateCommand())
            {
                int i = 0;

                foreach (var tb in textboxes)
                {
                    string col = tb.Name.Replace("txt_", "");
                    string param = "@p" + i++;

                    columns.Add($"[{col}]");
                    parameters.Add(param);

                    cmd.Parameters.AddWithValue(param, tb.Text);
                }

                foreach (var cb in comboboxes)
                {
                    string col = cb.Name.Replace("cb_", "");
                    string param = "@p" + i++;

                    columns.Add($"[{col}]");
                    parameters.Add(param);

                    cmd.Parameters.AddWithValue(param, cb.SelectedValue);
                }

                cmd.CommandText =
                    $"INSERT INTO [{tableName}] ({string.Join(",", columns)}) VALUES ({string.Join(",", parameters)})";

                cmd.ExecuteNonQuery();
            }

            RefreshGrid(tableName, dgv);
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