using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3console.Models.EntityFramework
{
    partial class UtilisateurPart
    {
        public string Utilisateurs { get; set; }

        public override string? ToString()
        {
            return "id : " + Utilisateurs;
        }
    }
}
