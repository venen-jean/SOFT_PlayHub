using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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


        }

        private void main_Load(object sender, EventArgs e)
        {
        }
    }
}
