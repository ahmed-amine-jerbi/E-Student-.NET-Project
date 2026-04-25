namespace EStudentPlatform
{
    partial class FormDashboardEnseignant
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblDeadline;
        private System.Windows.Forms.DateTimePicker dtpDeadline;
        private System.Windows.Forms.Button btnAddCourse;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) { components.Dispose(); }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblWelcome = new Label();
            lblTitle = new Label();
            txtTitle = new TextBox();
            lblDeadline = new Label();
            dtpDeadline = new DateTimePicker();
            btnAddCourse = new Button();
            SignoutBtn = new Button();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            lblWelcome.Location = new Point(20, 20);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(342, 24);
            lblWelcome.TabIndex = 5;
            lblWelcome.Text = "Teacher Dashboard - Add a Course";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(24, 80);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(73, 15);
            lblTitle.TabIndex = 4;
            lblTitle.Text = "Course Title:";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(120, 77);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(200, 23);
            txtTitle.TabIndex = 3;
            // 
            // lblDeadline
            // 
            lblDeadline.AutoSize = true;
            lblDeadline.Location = new Point(24, 120);
            lblDeadline.Name = "lblDeadline";
            lblDeadline.Size = new Size(56, 15);
            lblDeadline.TabIndex = 2;
            lblDeadline.Text = "Deadline:";
            // 
            // dtpDeadline
            // 
            dtpDeadline.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dtpDeadline.Format = DateTimePickerFormat.Custom;
            dtpDeadline.Location = new Point(120, 117);
            dtpDeadline.Name = "dtpDeadline";
            dtpDeadline.Size = new Size(200, 23);
            dtpDeadline.TabIndex = 1;
            // 
            // btnAddCourse
            // 
            btnAddCourse.Location = new Point(120, 160);
            btnAddCourse.Name = "btnAddCourse";
            btnAddCourse.Size = new Size(120, 30);
            btnAddCourse.TabIndex = 0;
            btnAddCourse.Text = "Add Course";
            btnAddCourse.UseVisualStyleBackColor = true;
            btnAddCourse.Click += btnAddCourse_Click;
            // 
            // SignoutBtn
            // 
            SignoutBtn.BackColor = Color.Brown;
            SignoutBtn.ForeColor = Color.Snow;
            SignoutBtn.Location = new Point(324, 208);
            SignoutBtn.Name = "SignoutBtn";
            SignoutBtn.Size = new Size(64, 30);
            SignoutBtn.TabIndex = 7;
            SignoutBtn.Text = "Signout";
            SignoutBtn.UseVisualStyleBackColor = false;
            SignoutBtn.Click += SignoutBtn_Click;
            // 
            // FormDashboardEnseignant
            // 
            ClientSize = new Size(400, 250);
            Controls.Add(SignoutBtn);
            Controls.Add(btnAddCourse);
            Controls.Add(dtpDeadline);
            Controls.Add(lblDeadline);
            Controls.Add(txtTitle);
            Controls.Add(lblTitle);
            Controls.Add(lblWelcome);
            Name = "FormDashboardEnseignant";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Enseignant Dashboard";
            ResumeLayout(false);
            PerformLayout();
        }

        private Button SignoutBtn;
    }
}