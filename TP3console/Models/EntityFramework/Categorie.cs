﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace TP3console.Models.EntityFramework
{
    [Table("categorie")]
    public partial class Categorie
    {
        public Categorie()
        {
            Films = new HashSet<Film>();
        }

        private ILazyLoader _lazyLoader;
        public Categorie(ILazyLoader lazyLoader)
        {
            _lazyLoader = lazyLoader;
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("nom")]
        [StringLength(50)]
        public string Nom { get; set; } = null!;
        [Column("description")]
        public string? Description { get; set; }

        [InverseProperty(nameof(Film.CategorieNavigation))]
        public virtual ICollection<Film> Films { get; set; }
        /*private ICollection<Film> films; //Doit être écrit de la même façon que la property Films mais en minuscule

        [InverseProperty("CategorieNavigation")]
        public virtual ICollection<Film> Films
        {
            get
            {
                return _lazyLoader.Load(this, ref films);
            }
            set { films = value; }
        }*/
    }
}
