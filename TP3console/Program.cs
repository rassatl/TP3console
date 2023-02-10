using TP3console.Models.EntityFramework;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace TP3console
{
    public class Program
    {
        static void Main(string[] args)
        {
            Exo2Q1();
            Console.ReadKey();
        }
        public static void Exo2Q1()
        {
            var ctx = new FilmsDBContext();
            //Pour que cela marche, il faut que la requête envoie les mêmes noms de colonnes que les classes c#.
            var films = ctx.Films.FromSqlRaw("SELECT * FROM film");
            foreach (var film in films)
            {
                Console.WriteLine(film.ToString());
            }
        }
    }
}