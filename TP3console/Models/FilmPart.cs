using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3console.Models.EntityFramework
{
    public partial class Film
    {
        public Film(int id, string nom, string? description, int categorie, Categorie categorieNavigation, ICollection<Avi> avis)
        {
            Id = id;
            Nom = nom;
            Description = description;
            Categorie = categorie;
            CategorieNavigation = categorieNavigation;
            Avis = avis;
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return Id + " : " + Nom;
        }
    }
}
