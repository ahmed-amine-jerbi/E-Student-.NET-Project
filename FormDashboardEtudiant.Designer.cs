namespace EStudentPlatform
{
    partial class FormDashboardEtudiant
    {
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.DataGridView dgvCourses;
        private System.Windows.Forms.Button btnLoadCourses;

        private void InitializeComponent()
        {
            lblWelcome = new Label();
            dgvCourses = new DataGridView();
            Enseignant = new DataGridViewTextBoxColumn();
            Titre = new DataGridViewTextBoxColumn();
            Deadline = new DataGridViewTextBoxColumn();
            btnLoadCourses = new Button();
            GreetingText = new Label();
            FiliereText = new Label();
            label3 = new Label();
            SignoutBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCourses).BeginInit();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            lblWelcome.Location = new Point(20, 20);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(317, 24);
            lblWelcome.TabIndex = 2;
            lblWelcome.Text = "Student Dashboard - My Courses";
            // 
            // dgvCourses
            // 
            dgvCourses.AllowUserToAddRows = false;
            dgvCourses.AllowUserToDeleteRows = false;
            dgvCourses.Columns.AddRange(new DataGridViewColumn[] { Enseignant, Titre, Deadline });
            dgvCourses.Location = new Point(24, 100);
            dgvCourses.Name = "dgvCourses";
            dgvCourses.Size = new Size(593, 240);
            dgvCourses.TabIndex = 1;
            // 
            // Enseignant
            // 
            Enseignant.DataPropertyName = "Enseignant";
            Enseignant.HeaderText = "Enseignant";
            Enseignant.Name = "Enseignant";
            Enseignant.Width = 150;
            // 
            // Titre
            // 
            Titre.DataPropertyName = "Titre";
            Titre.HeaderText = "Titre";
            Titre.Name = "Titre";
            Titre.Width = 200;
            // 
            // Deadline
            // 
            Deadline.DataPropertyName = "Deadline";
            Deadline.HeaderText = "Deadline";
            Deadline.Name = "Deadline";
            Deadline.Width = 200;
            // 
            // btnLoadCourses
            // 
            btnLoadCourses.Location = new Point(24, 60);
            btnLoadCourses.Name = "btnLoadCourses";
            btnLoadCourses.Size = new Size(150, 30);
            btnLoadCourses.TabIndex = 0;
            btnLoadCourses.Text = "View Available Courses";
            btnLoadCourses.Click += btnLoadCourses_Click;
            // 
            // GreetingText
            // 
            GreetingText.AutoSize = true;
            GreetingText.FlatStyle = FlatStyle.System;
            GreetingText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            GreetingText.Location = new Point(386, 29);
            GreetingText.Name = "GreetingText";
            GreetingText.Size = new Size(108, 15);
            GreetingText.TabIndex = 3;
            GreetingText.Text = "Bonjour, FullName";
            // 
            // FiliereText
            // 
            FiliereText.AutoSize = true;
            FiliereText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FiliereText.Location = new Point(386, 44);
            FiliereText.Name = "FiliereText";
            FiliereText.Size = new Size(41, 15);
            FiliereText.TabIndex = 4;
            FiliereText.Text = "Filiere";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(436, 44);
            label3.Name = "label3";
            label3.Size = new Size(0, 15);
            label3.TabIndex = 5;
            // 
            // SignoutBtn
            // 
            SignoutBtn.BackColor = Color.Brown;
            SignoutBtn.ForeColor = Color.Snow;
            SignoutBtn.Location = new Point(553, 64);
            SignoutBtn.Name = "SignoutBtn";
            SignoutBtn.Size = new Size(64, 30);
            SignoutBtn.TabIndex = 6;
            SignoutBtn.Text = "Signout";
            SignoutBtn.UseVisualStyleBackColor = false;
            SignoutBtn.Click += button1_Click;
            // 
            // FormDashboardEtudiant
            // 
            ClientSize = new Size(639, 358);
            Controls.Add(SignoutBtn);
            Controls.Add(label3);
            Controls.Add(FiliereText);
            Controls.Add(GreetingText);
            Controls.Add(btnLoadCourses);
            Controls.Add(dgvCourses);
            Controls.Add(lblWelcome);
            Name = "FormDashboardEtudiant";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Etudiant Dashboard";
            ((System.ComponentModel.ISupportInitialize)dgvCourses).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private DataGridViewTextBoxColumn Enseignant;
        private DataGridViewTextBoxColumn Titre;
        private DataGridViewTextBoxColumn Deadline;
        private Label GreetingText;
        private Label FiliereText;
        private Label label3;
        private Button SignoutBtn;
    }
}