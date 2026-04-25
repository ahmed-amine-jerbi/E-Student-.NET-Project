using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetNET
{
    public static class Session
    {
        public static int UserId { get; set; }
        public static byte GroupeId { get; set; }
        public static byte FiliereId { get; set; }
        public static byte NiveauId { get; set; }


        public static string FullName { get; set; }
        public static string Groupe { get; set; }
        public static string Filiere { get; set; }
        public static string Niveau { get; set; }

        public static void Clear()
        {
            UserId = 0;
            GroupeId = 0;
            FiliereId = 0;
            NiveauId = 0;
            FullName = null;
            Groupe = null;
            Filiere = null;
            Niveau = null;
        }

    }
}
