using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using MySqlConnector;
using ProjetNET;

namespace EStudentPlatform
{
    public partial class FormDashboardEtudiant : Form
    {
        public FormDashboardEtudiant()
        {
            InitializeComponent();

            GreetingText.Text = "Bonjour, " + Session.FullName + " !";
            FiliereText.Text = "Filière : " + Session.Filiere + " " + Session.Groupe;
        }

        private void btnLoadCourses_Click(object sender, EventArgs e)
        {
            DatabaseHelper db = new DatabaseHelper();
            using (MySqlConnection SQL_SERVER = db.Connect())
            {
                try
                {
                    SQL_SERVER.Open();

                    using (MySqlCommand fetch_devoirs = new MySqlCommand(
                        @"SELECT u.Prenom, u.Nom, d.EnsId, d.Titre, d.Deadline
                FROM Devoirs d, Utilisateurs u
                WHERE d.EnsId = u.Id
                AND d.FiliereId = @FiliereId
                AND d.NiveauId = @NiveauId
                AND d.GroupeId = @GroupeId", SQL_SERVER))
                    {
                        fetch_devoirs.Parameters.AddWithValue("@FiliereId", Session.FiliereId);
                        fetch_devoirs.Parameters.AddWithValue("@NiveauId", Session.NiveauId);
                        fetch_devoirs.Parameters.AddWithValue("@GroupeId", Session.GroupeId);

                        using (MySqlDataReader reader = fetch_devoirs.ExecuteReader())
                        {
                            DataTable table = new DataTable();

                            table.Columns.Add("Enseignant", typeof(string));
                            table.Columns.Add("Titre", typeof(string));
                            table.Columns.Add("Deadline", typeof(DateTime));

                            while (reader.Read())
                            {
                                DataRow Row = table.NewRow();

                                Row["Enseignant"] = reader["Prenom"] + " " + reader["Nom"];
                                Row["Titre"] = reader["Titre"];
                                Row["Deadline"] = Convert.ToDateTime(reader["Deadline"]);

                                table.Rows.Add(Row);
                            }

                            dgvCourses.DataSource = table;
                        }

                        foreach (DataGridViewRow row in dgvCourses.Rows)
                        {
                            if (row.IsNewRow) continue;

                            var cellValue = row.Cells["Deadline"].Value;
                            if (cellValue == null || cellValue == DBNull.Value) continue;

                            DateTime dl;
                            try { dl = Convert.ToDateTime(cellValue); }
                            catch { continue; }

                            if (DateTime.Now.Date > dl.Date)
                            {
                                row.DefaultCellStyle.BackColor = Color.LightCoral; // past deadline -> red-ish
                            }
                            else
                            {
                                row.DefaultCellStyle.BackColor = Color.LightGreen; // upcoming -> green-ish
                            }
                        }

                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    SQL_SERVER.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Session.Clear();

            this.Hide();
            FormLogin LoginForm = new FormLogin();
            this.Close();
            LoginForm.ShowDialog();
        }
    }
}