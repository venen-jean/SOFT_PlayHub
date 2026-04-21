namespace Projekt.pages
{
    partial class RoleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.public_gamesDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.public_gamesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.public_users_gamesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.logout = new System.Windows.Forms.Button();
            this.getPubBtn = new System.Windows.Forms.Button();
            this.game_platformsDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.game_platformsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.public_usersDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.public_usersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hrbac_rolesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hrbac_users_rolesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button5 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.public_gamesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.public_gamesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.public_users_gamesBindingSource)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.game_platformsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.game_platformsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.public_usersDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.public_usersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hrbac_rolesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hrbac_users_rolesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(6, 6);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 10;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 36);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1178, 614);
            this.flowLayoutPanel1.TabIndex = 11;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1202, 687);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.flowLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1194, 661);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Crud";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button5);
            this.tabPage2.Controls.Add(this.getPubBtn);
            this.tabPage2.Controls.Add(this.game_platformsDataGridView);
            this.tabPage2.Controls.Add(this.public_usersDataGridView);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1194, 661);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "UserData";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.public_gamesDataGridView);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1194, 661);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Spiele (Besitz)";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.tabPage3.Click += new System.EventHandler(this.tabPage3_Click);
            // 
            // public_gamesDataGridView
            // 
            this.public_gamesDataGridView.AutoGenerateColumns = false;
            this.public_gamesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.public_gamesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn7});
            this.public_gamesDataGridView.DataSource = this.public_gamesBindingSource;
            this.public_gamesDataGridView.Location = new System.Drawing.Point(3, 3);
            this.public_gamesDataGridView.Name = "public_gamesDataGridView";
            this.public_gamesDataGridView.Size = new System.Drawing.Size(240, 517);
            this.public_gamesDataGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "price";
            this.dataGridViewTextBoxColumn7.HeaderText = "Preis";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // public_gamesBindingSource
            // 
            this.public_gamesBindingSource.DataSource = typeof(Projekt.public_games);
            // 
            // public_users_gamesBindingSource
            // 
            this.public_users_gamesBindingSource.DataSource = typeof(Projekt.public_users_games);
            // 
            // logout
            // 
            this.logout.Location = new System.Drawing.Point(904, 11);
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(142, 23);
            this.logout.TabIndex = 1;
            this.logout.Text = "Logout";
            this.logout.UseVisualStyleBackColor = true;
            this.logout.Click += new System.EventHandler(this.button1_Click);
            // getPubBtn
            // 
            this.getPubBtn.Location = new System.Drawing.Point(526, 253);
            this.getPubBtn.Name = "getPubBtn";
            this.getPubBtn.Size = new System.Drawing.Size(93, 23);
            this.getPubBtn.TabIndex = 2;
            this.getPubBtn.Text = "Get Publishers";
            this.getPubBtn.UseVisualStyleBackColor = true;
            this.getPubBtn.Click += new System.EventHandler(this.GetPubBtn_Click);
            // 
            // game_platformsDataGridView
            // 
            this.game_platformsDataGridView.AutoGenerateColumns = false;
            this.game_platformsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            //this.game_platformsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            //this.dataGridViewTextBoxColumn6,
            //this.dataGridViewTextBoxColumn7});
            this.game_platformsDataGridView.DataSource = this.game_platformsBindingSource;
            this.game_platformsDataGridView.Location = new System.Drawing.Point(648, 6);
            this.game_platformsDataGridView.Name = "game_platformsDataGridView";
            this.game_platformsDataGridView.Size = new System.Drawing.Size(424, 220);
            this.game_platformsDataGridView.TabIndex = 1;
            this.game_platformsDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Game_platformsDataGridView_CellClick);
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn6.HeaderText = "id";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "name";
            this.dataGridViewTextBoxColumn7.HeaderText = "name";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // game_platformsBindingSource
            // 
            this.game_platformsBindingSource.DataSource = typeof(Projekt.game_platforms);
            // 
            // public_usersDataGridView
            // 
            this.public_usersDataGridView.AutoGenerateColumns = false;
            this.public_usersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            //this.public_usersDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            //this.dataGridViewTextBoxColumn1,
            //this.dataGridViewTextBoxColumn2,
            //this.dataGridViewTextBoxColumn3,
            //this.dataGridViewTextBoxColumn4,
            //this.dataGridViewTextBoxColumn5});
            this.public_usersDataGridView.DataSource = this.public_usersBindingSource;
            this.public_usersDataGridView.Location = new System.Drawing.Point(17, 6);
            this.public_usersDataGridView.Name = "public_usersDataGridView";
            this.public_usersDataGridView.Size = new System.Drawing.Size(602, 220);
            this.public_usersDataGridView.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn1.HeaderText = "id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "username";
            this.dataGridViewTextBoxColumn2.HeaderText = "username";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "email";
            this.dataGridViewTextBoxColumn3.HeaderText = "email";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "password";
            this.dataGridViewTextBoxColumn4.HeaderText = "password";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "balance";
            this.dataGridViewTextBoxColumn5.HeaderText = "balance";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // public_usersBindingSource
            // 
            this.public_usersBindingSource.DataSource = typeof(Projekt.public_users);
            // 
            // hrbac_rolesBindingSource
            // 
            this.hrbac_rolesBindingSource.DataSource = typeof(Projekt.hrbac_roles);
            // 
            // hrbac_users_rolesBindingSource
            // 
            this.hrbac_users_rolesBindingSource.DataSource = typeof(Projekt.hrbac_users_roles);
            // 
            // button1
            // 
            this.button5.Location = new System.Drawing.Point(445, 253);
            this.button5.Name = "button1";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 3;
            this.button5.Text = "Get Devs";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.GetDevBtn_Click);
            // 
            // RoleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 699);
            this.Controls.Add(this.logout);
            this.Controls.Add(this.tabControl1);
            this.Name = "RoleForm";
            this.Text = "s";
            this.Load += new System.EventHandler(this.RoleForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.public_gamesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.public_gamesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.public_users_gamesBindingSource)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.game_platformsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.game_platformsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.public_usersDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.public_usersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hrbac_rolesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hrbac_users_rolesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource hrbac_rolesBindingSource;
        private System.Windows.Forms.BindingSource hrbac_users_rolesBindingSource;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button logout;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.BindingSource public_users_gamesBindingSource;
        private System.Windows.Forms.DataGridView public_gamesDataGridView;
        private System.Windows.Forms.BindingSource public_gamesBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridView public_usersDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        //private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.BindingSource public_usersBindingSource;
        private System.Windows.Forms.DataGridView game_platformsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        //private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.BindingSource game_platformsBindingSource;
        private System.Windows.Forms.Button getPubBtn;
        private System.Windows.Forms.Button button5;
    }
}