using Projekt.pages;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt.application
{
    public class DynamicEditForm : Form
    {
        private readonly string _tableName;
        private readonly DataRow _row;
        private readonly Dictionary<string, TextBox> _inputs = new Dictionary<string, TextBox>();

        public DynamicEditForm(string tableName, DataRow row)
        {
            _tableName = tableName;
            _row = row;

            Initialize();
        }

        private void Initialize()
        {
            var panel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoSize = true
            };

            foreach (DataColumn col in _row.Table.Columns)
            {
                if (col.ColumnName.Equals("id", StringComparison.OrdinalIgnoreCase))
                    continue;

                panel.Controls.Add(new Label { Text = col.ColumnName, Width = 100 });

                var txt = new TextBox
                {
                    Width = 150,
                    Text = _row[col]?.ToString()
                };

                _inputs[col.ColumnName] = txt;
                panel.Controls.Add(txt);
            }

            var updateBtn = new Button { Text = "Update" };
            updateBtn.Click += (s, e) => UpdateRow();

            var deleteBtn = new Button { Text = "Delete" };
            deleteBtn.Click += (s, e) => DeleteRow();

            panel.Controls.Add(updateBtn);
            panel.Controls.Add(deleteBtn);

            Controls.Add(panel);
        }

        private void UpdateRow()
        {
            using (var conn = new SqlConnection(RoleForm.connString))
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    var setParts = new List<string>();

                    foreach (var kvp in _inputs)
                    {
                        string param = "@" + kvp.Key;

                        setParts.Add($"[{kvp.Key}] = {param}");
                        cmd.Parameters.AddWithValue(param, kvp.Value.Text);
                    }

                    cmd.Parameters.AddWithValue("@id", _row["id"]);

                    cmd.CommandText =
                        $"UPDATE [{_tableName}] SET {string.Join(",", setParts)} WHERE id = @id";

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Updated!");
            Close();
        }

        private void DeleteRow()
        {
            var confirm = MessageBox.Show(
                "Are you sure you want to delete this row?",
                "Confirm",
                MessageBoxButtons.YesNo);

            if (confirm != DialogResult.Yes)
                return;

            using (var conn = new SqlConnection(RoleForm.connString))
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"DELETE FROM [{_tableName}] WHERE id = @id";
                    cmd.Parameters.AddWithValue("@id", _row["id"]);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Deleted!");
            Close();
        }
    }
}