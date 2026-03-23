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
            System.Windows.Forms.Label nameLabel;
            this.hrbac_rolesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.hrbac_rolesDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.hrbac_users_rolesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            nameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.hrbac_rolesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hrbac_rolesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hrbac_users_rolesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(45, 144);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(36, 13);
            nameLabel.TabIndex = 3;
            nameLabel.Text = "name:";
            // 
            // hrbac_rolesBindingSource
            // 
            this.hrbac_rolesBindingSource.DataSource = typeof(Projekt.hrbac_roles);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(87, 141);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(100, 20);
            this.nameTextBox.TabIndex = 9;
            // 
            // hrbac_rolesDataGridView
            // 
            this.hrbac_rolesDataGridView.AutoGenerateColumns = false;
            this.hrbac_rolesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.hrbac_rolesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.hrbac_rolesDataGridView.DataSource = this.hrbac_rolesBindingSource;
            this.hrbac_rolesDataGridView.Location = new System.Drawing.Point(221, 75);
            this.hrbac_rolesDataGridView.Name = "hrbac_rolesDataGridView";
            this.hrbac_rolesDataGridView.Size = new System.Drawing.Size(310, 220);
            this.hrbac_rolesDataGridView.TabIndex = 8;
            this.hrbac_rolesDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Hrbac_rolesDataGridView_CellClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn1.HeaderText = "id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "name";
            this.dataGridViewTextBoxColumn2.HeaderText = "name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(48, 183);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Create";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.CreateRoleBtn_Click);
            // 
            // hrbac_users_rolesBindingSource
            // 
            this.hrbac_users_rolesBindingSource.DataSource = typeof(Projekt.hrbac_users_roles);
            // 
            // AdminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 379);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.hrbac_rolesDataGridView);
            this.Controls.Add(this.button2);
            this.Controls.Add(nameLabel);
            this.Name = "AdminPanel";
            this.Text = "s";
            ((System.ComponentModel.ISupportInitialize)(this.hrbac_rolesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hrbac_rolesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hrbac_users_rolesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource hrbac_rolesBindingSource;
        private System.Windows.Forms.BindingSource hrbac_users_rolesBindingSource;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView hrbac_rolesDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.TextBox nameTextBox;
    }
}