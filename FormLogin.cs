using MySqlConnector;
using ProjetNET;

namespace EStudentPlatform
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool ChampsValid()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter both email and password.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!IsValidEmail(txtUsername.Text))
            {
                MessageBox.Show("Please enter a valid email address.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            if (!ChampsValid()) { return; }

            DatabaseHelper db = new DatabaseHelper();
            using (MySqlConnection SQL_SERVER = db.Connect())
            {
                try
                {
                    SQL_SERVER.Open();

                    using (MySqlCommand fetch_user_by_email = new MySqlCommand(
                        @"SELECT
                            u.Id,
                            u.Prenom,
                            u.Nom,
                            u.Email,
                            u.Password,
                            u.Role,
                            u.GroupeId,
                            g.Libelle AS GroupeLibelle,
                            n.Id AS NiveauId,
                            n.Libelle AS NiveauLibelle,
                            f.Id AS FiliereId,
                            f.Libelle AS FiliereLibelle
                        FROM utilisateurs u
                        LEFT JOIN groupes g ON g.Id = u.GroupeId
                        LEFT JOIN niveaux n ON n.Id = g.nivId
                        LEFT JOIN filieres f ON f.Id = g.FiliereId
                        WHERE u.Email = @email
                        LIMIT 1", SQL_SERVER))
                    {
                        fetch_user_by_email.Parameters.AddWithValue("@email", txtUsername.Text);

                        using (MySqlDataReader reader = fetch_user_by_email.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string HashedPassword = reader.GetString("Password");
                                if (!BCrypt.Net.BCrypt.Verify(txtPassword.Text, HashedPassword))
                                {
                                    MessageBox.Show("Veuillez Verifier votre Mot de Passe.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Utilisateur inexistant.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            string role = reader.GetString("Role");

                            MessageBox.Show("Success.");

                            Session.UserId = reader.GetInt32("Id");
                            Session.GroupeId = reader.GetByte("GroupeId");
                            Session.FiliereId = reader.GetByte("FiliereId");
                            Session.NiveauId = reader.GetByte("NiveauId");

                            Session.FullName = reader.GetString("Prenom") + " " + reader.GetString("Nom");
                            Session.Groupe = reader.GetString("GroupeLibelle");
                            Session.Filiere = reader.GetString("FiliereLibelle");
                            Session.Niveau = reader.GetString("NiveauLibelle");

                            System.Windows.Forms.Form newForm = null;

                            switch (role)
                            {
                                case "Administration":
                                    newForm = new FormDashboardAdmin();
                                    break;
                                case "Enseignant":
                                    newForm = new FormDashboardEnseignant();
                                    break;
                                default:
                                    newForm = new FormDashboardEtudiant();
                                    break;
                            }

                            this.Hide();
                            newForm.ShowDialog();
                            this.Close();
                        }
                    }

                    }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                finally
                {

                }
            }
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            this.Hide();

            FormCreateAccount createAccountForm = new FormCreateAccount();
            // Show the login form again after the create account form is closed.
            // Attach the handler before ShowDialog so it runs when the dialog closes.
            createAccountForm.FormClosed += (s, args) => this.Show();
            createAccountForm.ShowDialog();
        }
    }
}