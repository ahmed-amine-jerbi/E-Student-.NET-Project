using System;
using System.Windows.Forms;
using MySqlConnector;

namespace EStudentPlatform
{
    public partial class FormCreateAccount : Form
    {
        public FormCreateAccount()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRegFirstName.Text) || string.IsNullOrWhiteSpace(textRegLastName.Text) || string.IsNullOrWhiteSpace(txtRegPass.Text) || string.IsNullOrWhiteSpace(textRegEmail.Text))
            {
                MessageBox.Show("Please fill all fields."); return;
            }

            if (txtRegPass.Text != confPwd.Text)
            {
                MessageBox.Show("Passwords do not match."); return;
            }

            DatabaseHelper db = new DatabaseHelper();
            using (MySqlConnection SQL_SERVER = db.Connect())
            {
                try
                {

                    {
                        SQL_SERVER.Open();
                        using (MySqlCommand check_email_cmd = new MySqlCommand("SELECT COUNT(*) FROM Utilisateurs WHERE Email = @Email", SQL_SERVER))
                        {
                            check_email_cmd.Parameters.AddWithValue("@Email", textRegEmail.Text);
                            object result = check_email_cmd.ExecuteScalar();

                            if (result is not DBNull && Convert.ToInt32(result) > 0)
                            {
                                MessageBox.Show("This email is already registered. Please use a different email."); return;
                            }

                            using (MySqlCommand user_insertion_query = new MySqlCommand(
                                    @"INSERT INTO utilisateurs(Prenom, Nom, Email, Password, Role, GroupeId, dateInscription)
                                    VALUES (@name, @lastname, @email, @pass, @role, @groupeid, @dateTime)", SQL_SERVER))
                            {
                                int GroupeId = 0;

                                using (MySqlCommand fetch_group_id = new MySqlCommand(
                                    @"SELECT * FROM groupes
                                    WHERE FiliereId = @filiereId
                                    AND nivId = @nivId", SQL_SERVER))
                                {
                                    fetch_group_id.Parameters.AddWithValue("@filiereId", cmbFiliere.SelectedIndex);
                                    fetch_group_id.Parameters.AddWithValue("@nivId", cmbNiveau.SelectedIndex);

                                    using (MySqlDataReader reader = fetch_group_id.ExecuteReader())
                                    {
                                        if (reader.Read())
                                        {
                                            GroupeId = reader.GetInt32("Id");
                                        }
                                        else
                                        {
                                            MessageBox.Show("No group found for the selected filiere and niveau."); return;
                                        }
                                    }
                                }

                                user_insertion_query.Parameters.AddWithValue("@name", txtRegFirstName.Text);
                                user_insertion_query.Parameters.AddWithValue("@lastname", textRegLastName.Text);
                                user_insertion_query.Parameters.AddWithValue("@email", textRegEmail.Text);
                                user_insertion_query.Parameters.AddWithValue("@pass", BCrypt.Net.BCrypt.HashPassword(txtRegPass.Text));
                                user_insertion_query.Parameters.AddWithValue("@role", "Etudiant");
                                user_insertion_query.Parameters.AddWithValue("@groupeId", GroupeId);
                                user_insertion_query.Parameters.AddWithValue("@dateTime", DateTime.Now);

                                user_insertion_query.ExecuteNonQuery();

                                MessageBox.Show("Account created successfully!", "Signup Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                { 
                    MessageBox.Show("Database error: " + ex.Message);
                }
                finally
                {
                    SQL_SERVER.Close();
                }
            }

        }
    }
}