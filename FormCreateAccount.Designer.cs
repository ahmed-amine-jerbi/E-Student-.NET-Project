namespace EStudentPlatform
{
    partial class FormCreateAccount
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtRegFirstName;
        private System.Windows.Forms.TextBox txtRegPass;
        private System.Windows.Forms.ComboBox cmbFiliere;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;

        private void InitializeComponent()
        {
            txtRegFirstName = new TextBox();
            txtRegPass = new TextBox();
            cmbFiliere = new ComboBox();
            btnRegister = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textRegLastName = new TextBox();
            label4 = new Label();
            textRegEmail = new TextBox();
            label5 = new Label();
            confPwd = new TextBox();
            label6 = new Label();
            cmbNiveau = new ComboBox();
            label7 = new Label();
            cmbGroupe = new ComboBox();
            label8 = new Label();
            SuspendLayout();
            // 
            // txtRegFirstName
            // 
            txtRegFirstName.Location = new Point(120, 27);
            txtRegFirstName.Name = "txtRegFirstName";
            txtRegFirstName.Size = new Size(100, 23);
            txtRegFirstName.TabIndex = 3;
            // 
            // txtRegPass
            // 
            txtRegPass.Location = new Point(120, 114);
            txtRegPass.Name = "txtRegPass";
            txtRegPass.PasswordChar = '*';
            txtRegPass.Size = new Size(100, 23);
            txtRegPass.TabIndex = 2;
            // 
            // cmbFiliere
            // 
            cmbFiliere.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiliere.Items.AddRange(new object[] { "Selectionner une Filiere", "Business Computing", "E-Business", "Business Information Systems", "Business Intelligence" });
            cmbFiliere.Location = new Point(64, 175);
            cmbFiliere.Name = "cmbFiliere";
            cmbFiliere.Size = new Size(253, 23);
            cmbFiliere.TabIndex = 1;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(120, 274);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(75, 23);
            btnRegister.TabIndex = 0;
            btnRegister.Text = "Register";
            btnRegister.Click += btnRegister_Click;
            // 
            // label1
            // 
            label1.Location = new Point(30, 30);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 6;
            label1.Text = "First Name";
            // 
            // label2
            // 
            label2.Location = new Point(30, 117);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 5;
            label2.Text = "Password:";
            // 
            // label3
            // 
            label3.Location = new Point(14, 178);
            label3.Name = "label3";
            label3.Size = new Size(100, 23);
            label3.TabIndex = 4;
            label3.Text = "Filiere";
            // 
            // textRegLastName
            // 
            textRegLastName.Location = new Point(120, 56);
            textRegLastName.Name = "textRegLastName";
            textRegLastName.Size = new Size(100, 23);
            textRegLastName.TabIndex = 7;
            // 
            // label4
            // 
            label4.Location = new Point(30, 59);
            label4.Name = "label4";
            label4.Size = new Size(100, 23);
            label4.TabIndex = 8;
            label4.Text = "Last Name";
            // 
            // textRegEmail
            // 
            textRegEmail.Location = new Point(120, 85);
            textRegEmail.Name = "textRegEmail";
            textRegEmail.Size = new Size(100, 23);
            textRegEmail.TabIndex = 9;
            // 
            // label5
            // 
            label5.Location = new Point(30, 88);
            label5.Name = "label5";
            label5.Size = new Size(100, 23);
            label5.TabIndex = 10;
            label5.Text = "Email address";
            // 
            // confPwd
            // 
            confPwd.Location = new Point(120, 143);
            confPwd.Name = "confPwd";
            confPwd.PasswordChar = '*';
            confPwd.Size = new Size(137, 23);
            confPwd.TabIndex = 11;
            // 
            // label6
            // 
            label6.Location = new Point(6, 143);
            label6.Name = "label6";
            label6.Size = new Size(108, 23);
            label6.TabIndex = 12;
            label6.Text = "Confirm Password:";
            // 
            // cmbNiveau
            // 
            cmbNiveau.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNiveau.Items.AddRange(new object[] { "Selectionner un Niveau", "License 1", "License 2", "License 3", "Master 1", "Master 2" });
            cmbNiveau.Location = new Point(64, 204);
            cmbNiveau.Name = "cmbNiveau";
            cmbNiveau.Size = new Size(253, 23);
            cmbNiveau.TabIndex = 13;
            // 
            // label7
            // 
            label7.Location = new Point(14, 207);
            label7.Name = "label7";
            label7.Size = new Size(100, 23);
            label7.TabIndex = 14;
            label7.Text = "Niveau";
            // 
            // cmbGroupe
            // 
            cmbGroupe.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGroupe.Items.AddRange(new object[] { "Selectionner une Groupe", "Groupe 1", "Groupe 2", "Groupe 3" });
            cmbGroupe.Location = new Point(64, 233);
            cmbGroupe.Name = "cmbGroupe";
            cmbGroupe.Size = new Size(253, 23);
            cmbGroupe.TabIndex = 15;
            // 
            // label8
            // 
            label8.Location = new Point(14, 236);
            label8.Name = "label8";
            label8.Size = new Size(100, 23);
            label8.TabIndex = 16;
            label8.Text = "Groupe";
            // 
            // FormCreateAccount
            // 
            ClientSize = new Size(329, 309);
            Controls.Add(cmbGroupe);
            Controls.Add(label8);
            Controls.Add(cmbNiveau);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(confPwd);
            Controls.Add(textRegEmail);
            Controls.Add(label5);
            Controls.Add(textRegLastName);
            Controls.Add(label4);
            Controls.Add(btnRegister);
            Controls.Add(cmbFiliere);
            Controls.Add(txtRegPass);
            Controls.Add(txtRegFirstName);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormCreateAccount";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Create Account";
            ResumeLayout(false);
            PerformLayout();
        }

        private TextBox textRegLastName;
        private Label label4;
        private TextBox textRegEmail;
        private Label label5;
        private TextBox confPwd;
        private Label label6;
        private ComboBox cmbNiveau;
        private Label label7;
        private ComboBox cmbGroupe;
        private Label label8;
    }
}