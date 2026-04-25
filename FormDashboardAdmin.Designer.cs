namespace EStudentPlatform
{
    partial class FormDashboardAdmin
    {
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Button btnLoadUsers;

        private void InitializeComponent()
        {
            lblWelcome = new Label();
            dgvUsers = new DataGridView();
            btnLoadUsers = new Button();
            SignoutBtn = new Button();
            cmbRole = new ComboBox();
            rechNom = new TextBox();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            lblWelcome.Location = new Point(20, 20);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(177, 24);
            lblWelcome.TabIndex = 2;
            lblWelcome.Text = "Admin Dashboard";
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.Location = new Point(24, 100);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.Size = new Size(684, 240);
            dgvUsers.TabIndex = 1;
            // 
            // btnLoadUsers
            // 
            btnLoadUsers.Location = new Point(24, 60);
            btnLoadUsers.Name = "btnLoadUsers";
            btnLoadUsers.Size = new Size(150, 30);
            btnLoadUsers.TabIndex = 0;
            btnLoadUsers.Text = "Load Users";
            btnLoadUsers.Click += btnLoadUsers_Click;
            // 
            // SignoutBtn
            // 
            SignoutBtn.BackColor = Color.Brown;
            SignoutBtn.ForeColor = Color.Snow;
            SignoutBtn.Location = new Point(644, 60);
            SignoutBtn.Name = "SignoutBtn";
            SignoutBtn.Size = new Size(64, 30);
            SignoutBtn.TabIndex = 7;
            SignoutBtn.Text = "Signout";
            SignoutBtn.UseVisualStyleBackColor = false;
            SignoutBtn.Click += SignoutBtn_Click;
            // 
            // cmbRole
            // 
            cmbRole.FormattingEnabled = true;
            cmbRole.Items.AddRange(new object[] { "Tous" });
            cmbRole.Location = new Point(501, 65);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(121, 23);
            cmbRole.TabIndex = 8;
            // 
            // rechNom
            // 
            rechNom.Location = new Point(256, 65);
            rechNom.Name = "rechNom";
            rechNom.PlaceholderText = "Recherche";
            rechNom.Size = new Size(133, 23);
            rechNom.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(445, 68);
            label1.Name = "label1";
            label1.Size = new Size(32, 15);
            label1.TabIndex = 10;
            label1.Text = "Role";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(216, 68);
            label2.Name = "label2";
            label2.Size = new Size(34, 15);
            label2.TabIndex = 11;
            label2.Text = "Nom";
            // 
            // FormDashboardAdmin
            // 
            ClientSize = new Size(720, 353);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(rechNom);
            Controls.Add(cmbRole);
            Controls.Add(SignoutBtn);
            Controls.Add(btnLoadUsers);
            Controls.Add(dgvUsers);
            Controls.Add(lblWelcome);
            Name = "FormDashboardAdmin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Admin Dashboard";
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Button SignoutBtn;
        private ComboBox cmbRole;
        private TextBox rechNom;
        private Label label1;
        private Label label2;
    }
}