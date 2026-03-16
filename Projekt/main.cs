using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt
{

    
    public partial class main : Form
    {

        private int userid;
        public main()
        {
            InitializeComponent();

            label1.Text = ("Willkommen: "+globalstore.user.username);

            var roles = (from u in globalstore.Daten.public_users
                         join ur in globalstore.Daten.hrbac_users_roles on u.id equals ur.user_id
                         join r in globalstore.Daten.hrbac_roles on ur.role_id equals r.id
                         where u.username == globalstore.user.username
                         select r.name)
                         .ToList();


            label1.Text += " " +roles;


        }

        private void main_Load(object sender, EventArgs e)
        {
        }
    }
}
