using Projekt.application;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Projekt.pages
{
    public partial class RoleEditForm : GenericEditForm<hrbac_roles>
    {
        public RoleEditForm(hrbac_roles role, BindingSource bindingSource) : base(role, bindingSource)
        {
            InitializeComponent();
        }

        private void UpdateRoleBtn_Click(object sender, EventArgs e) => OnSaveClick(sender, e);

        private void DeleteRoleBtn_Click(object sender, EventArgs e) => OnDeleteClick(sender, e);
    }
}
