using MySqlConnector;
using ProjetNET;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace EStudentPlatform
{
    public partial class FormDashboardAdmin : Form
    {
        public FormDashboardAdmin()
        {
            InitializeComponent();

            // Populate role filter combobox and setup role dropdown column
            List<string> RoleList = LoadAvailableRoles();
            cmbRole.DataSource = new List<string>(RoleList);

            // Setup DataGridView for role editing
            SetupDataGridViewForRoleEditing(RoleList);
        }

        private List<string> LoadAvailableRoles()
        {
            DatabaseHelper db = new DatabaseHelper();
            using (MySqlConnection SQL_SERVER = db.Connect())
            {
                try
                {
                    SQL_SERVER.Open();
                    using (MySqlCommand get_roles_query = new MySqlCommand("SELECT DISTINCT Role FROM Utilisateurs ORDER BY Role", SQL_SERVER))
                    {
                        using (MySqlDataReader reader = get_roles_query.ExecuteReader())
                        {
                            List<string> RoleList = new List<string> { "Tous" };
                            while (reader.Read())
                            {
                                RoleList.Add(reader["Role"].ToString());
                            }
                            return RoleList;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new List<string> { "Tous" };
                }
                finally
                {
                    SQL_SERVER.Close();
                }
            }
        }

        private void SetupDataGridViewForRoleEditing(List<string> RoleList)
        {
            // Remove existing Role column if it exists and recreate as DataGridViewComboBoxColumn
            if (dgvUsers.Columns["Role"] != null)
            {
                dgvUsers.Columns.Remove("Role");
            }

            // Create a combobox column for roles
            DataGridViewComboBoxColumn roleColumn = new DataGridViewComboBoxColumn
            {
                Name = "Role",
                HeaderText = "Role",
                DataPropertyName = "Role",
                DataSource = RoleList.Where(r => r != "Tous").ToList(), // Exclude "Tous" from editing
                Width = 120
            };
            dgvUsers.Columns.Add(roleColumn);

            dgvUsers.CellValueChanged += DgvUsers_CellValueChanged;
        }

        private void DgvUsers_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvUsers.Columns[e.ColumnIndex].Name == "Role")
            {
                string userId = dgvUsers.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                string newRole = dgvUsers.Rows[e.RowIndex].Cells["Role"].Value.ToString();

                if (newRole == "Administration")
                {
                    MessageBox.Show("You cannot assign the 'Administration' role to a user.", "Invalid Role", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DatabaseHelper db = new DatabaseHelper();
                using (MySqlConnection SQL_SERVER = db.Connect())
                {
                    try
                    {
                        SQL_SERVER.Open();
                        using (MySqlCommand update_role_query = new MySqlCommand("UPDATE Utilisateurs SET Role = @Role WHERE Id = @Id", SQL_SERVER))
                        {
                            update_role_query.Parameters.AddWithValue("@Role", newRole);
                            update_role_query.Parameters.AddWithValue("@Id", userId);
                            update_role_query.ExecuteNonQuery();
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
        }

        private void btnLoadUsers_Click(object sender, EventArgs e)
        {
            DatabaseHelper db = new DatabaseHelper();
            using (MySqlConnection SQL_SERVER = db.Connect())
            {
                try
                {
                    string NameFilter = rechNom.Text.Trim();
                    string RoleFilter = cmbRole.SelectedItem.ToString();

                    bool Filtering = NameFilter != "" || RoleFilter != "Tous";

                    string queryStr = "SELECT Id, Prenom, Nom, Email, Role FROM Utilisateurs";

                    if (Filtering)
                    {
                        queryStr += " WHERE";
                        if (NameFilter != "")
                        {
                            queryStr += $" (Nom LIKE '%{NameFilter}%' OR Prenom LIKE '%{NameFilter}%')";
                        }
                        if (RoleFilter != "Tous")
                        {
                            if (NameFilter != "")
                            {
                                queryStr += " AND";
                            }
                            queryStr += $" Role = '{RoleFilter}'";
                        }
                    }

                    using (MySqlDataAdapter get_users_query = new MySqlDataAdapter(queryStr, SQL_SERVER))
                    {
                        DataTable usersTable = new DataTable();
                        get_users_query.Fill(usersTable);
                        dgvUsers.DataSource = usersTable;

                        foreach (DataGridViewRow row in dgvUsers.Rows)
                        {
                            string Role = row.Cells["Role"].Value.ToString();

                            if (Role == "Administration")
                            {
                                row.ReadOnly = true;
                                row.DefaultCellStyle.BackColor = System.Drawing.Color.IndianRed;
                                row.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
                            }
                            else if (Role == "Enseignant")
                            {
                                row.DefaultCellStyle.BackColor = System.Drawing.Color.DarkOrange;
                            }
                            else
                            {
                                row.DefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;
                            }
                        }
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