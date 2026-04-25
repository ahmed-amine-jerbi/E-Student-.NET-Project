using MySqlConnector;
using ProjetNET;
using System;
using System.Windows.Forms;

namespace EStudentPlatform
{
    public partial class FormDashboardEnseignant : Form
    {
        public FormDashboardEnseignant()
        {
            InitializeComponent();
        }

        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            // 1. Validate inputs
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Please enter a course title.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Insert into database
            DatabaseHelper db = new DatabaseHelper();
            using (MySqlConnection SQL_SERVER = db.Connect())
            {
                try
                {
                    SQL_SERVER.Open();

                    using (MySqlCommand insertion_query = new MySqlCommand(
                        @"INSERT INTO devoirs(FiliereId, NiveauId, GroupeId, EnsId, Titre, Deadline)
                        VALUES (@FiliereId, @NiveauId, @GroupeId, @EnsId, @Titre, @Deadline)", SQL_SERVER))
                    {
                        insertion_query.Parameters.AddWithValue("@FiliereId", Session.FiliereId);
                        insertion_query.Parameters.AddWithValue("@NiveauId", Session.NiveauId);
                        insertion_query.Parameters.AddWithValue("@GroupeId", Session.GroupeId);
                        insertion_query.Parameters.AddWithValue("@EnsId", Session.UserId);

                        insertion_query.Parameters.AddWithValue("@Titre", txtTitle.Text);
                        insertion_query.Parameters.AddWithValue("@deadline", dtpDeadline.Value);

                        insertion_query.ExecuteNonQuery();

                        MessageBox.Show("Course added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txtTitle.Clear();
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    SQL_SERVER.Close();
                }
            }
        }

        private void SignoutBtn_Click(object sender, EventArgs e)
        {
            Session.Clear();

            this.Hide();
            FormLogin LoginForm = new FormLogin();
            this.Close();
            LoginForm.ShowDialog();
        }
    }
}