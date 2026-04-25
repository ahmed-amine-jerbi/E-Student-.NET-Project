using System;
using MySqlConnector;

namespace EStudentPlatform
{
    public class DatabaseHelper
    {
        private readonly string ChaineConnexionSQLServer = "Server=localhost;Database=pfa_esen_2026;User ID=root;Password=;";

        public MySqlConnection Connect()
        {
            return new MySqlConnection(ChaineConnexionSQLServer);
        }
    }
}