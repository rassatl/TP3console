using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3console.Models.EntityFramework
{
    public partial class Categorie
    {
        public Categorie(ILazyLoader lazyLoader, int id, string nom, string? description, ICollection<Film> films) : this(lazyLoader)
        {
            Id = id;
            Nom = nom;
            Description = description;
            Films = films;
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
            return "Description : " + Description;
        }
    }
}
