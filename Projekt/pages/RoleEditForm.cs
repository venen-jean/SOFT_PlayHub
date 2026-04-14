using Projekt.application;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Projekt.pages
{
    public partial class RoleEditForm : Form
    {
        private CrudService<hrbac_roles> service = new CrudService<hrbac_roles>();

        public RoleEditForm(hrbac_roles role)
        {
            InitializeComponent();

            hrbac_rolesBindingSource.DataSource = role;
        }

        private void UpdateRoleBtn_Click(object sender, EventArgs e)
        {
            service.Save();
            Close();
        }

        private void DeleteRoleBtn_Click(object sender, EventArgs e)
        {
            var role = (hrbac_roles)hrbac_rolesBindingSource.Current;

            try
            {
                service.Delete(role);
            }
            catch (Exception ex)
            {
                MessageBox.Show(GetFullExceptionMessage(ex), "Delete error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Close();
        }

        private string GetFullExceptionMessage(Exception ex)
        {
            var messages = new List<string>();

            while (ex != null)
            {
                messages.Add(ex.Message);
                ex = ex.InnerException;
            }

            return string.Join(Environment.NewLine, messages);
        }
    }
}
