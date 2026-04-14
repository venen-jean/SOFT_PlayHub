using Projekt.application;
using System;
using System.Windows.Forms;

namespace Projekt.pages
{
    public partial class RoleForm : Form
    {
        private CrudService<hrbac_roles> service = new CrudService<hrbac_roles>();

        public RoleForm()
        {
            InitializeComponent();

            service.Load(hrbac_rolesBindingSource);
        }

        private void CreateRoleBtn_Click(object sender, EventArgs e)
        {
            var name = nameTextBox.Text;

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Name ist leer");
                return;
            }

            var newRole = new hrbac_roles
            {
                name = name
            };

            service.Create(newRole);
            service.Load(hrbac_rolesBindingSource);
        }

        private void Hrbac_rolesDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var role = (hrbac_roles)hrbac_rolesBindingSource.Current;

            using (var form = new RoleEditForm(role))
            {
                form.ShowDialog();
            }

            service.Load(hrbac_rolesBindingSource);
        }
    }
}
