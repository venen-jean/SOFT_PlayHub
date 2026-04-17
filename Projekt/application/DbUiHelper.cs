using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Projekt.application
{
    public static class DbUiHelper
    {
        public static Dictionary<string, string> GetForeignKeys(string connString, string tableName)
        {
            var result = new Dictionary<string, string>();

            using (var conn = new SqlConnection(connString))
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    SELECT 
                        kcu.COLUMN_NAME,
                        ccu.TABLE_NAME AS REFERENCED_TABLE
                    FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE kcu
                    JOIN INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS rc 
                        ON kcu.CONSTRAINT_NAME = rc.CONSTRAINT_NAME
                    JOIN INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE ccu 
                        ON rc.UNIQUE_CONSTRAINT_NAME = ccu.CONSTRAINT_NAME
                    WHERE kcu.TABLE_NAME = @table";

                    cmd.Parameters.AddWithValue("@table", tableName);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result[reader["COLUMN_NAME"].ToString()] =
                                reader["REFERENCED_TABLE"].ToString();
                        }
                    }
                }
            }

            return result;
        }

        public static ComboBox CreateForeignKeyComboBox(string connString, string referencedTable, string columnName)
        {
            var cb = new ComboBox
            {
                Name = "cb_" + columnName,
                Width = 150,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            using (var conn = new SqlConnection(connString))
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"SELECT * FROM [{referencedTable}]";

                    using (var reader = cmd.ExecuteReader())
                    {
                        var dt = new DataTable();
                        dt.Load(reader);

                        cb.DataSource = dt;
                        cb.ValueMember = "id";

                        var displayCol = dt.Columns
                            .Cast<DataColumn>()
                            .FirstOrDefault(c => c.ColumnName != "id")?.ColumnName ?? "id";

                        cb.DisplayMember = displayCol;
                    }
                }
            }

            return cb;
        }
    }
}
