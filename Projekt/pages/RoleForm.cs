using Projekt.application;
using System;
using System.Windows.Forms;

namespace Projekt.pages
{
    public partial class RoleForm : GenericListForm<hrbac_roles>
    {
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
    }
}
