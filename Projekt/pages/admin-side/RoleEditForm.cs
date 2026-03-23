using Projekt.application;
using System;
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
                MessageBox.Show(ex.Message, "Delete error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Close();
        }
    }
}
