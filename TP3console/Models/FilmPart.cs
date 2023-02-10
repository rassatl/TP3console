using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3console.Models.EntityFramework
{
    partial class FilmPart
    {
        public string Nom { get; set; }

        public override string? ToString()
        {
            return "id : " + Nom;
        }
    }
}
