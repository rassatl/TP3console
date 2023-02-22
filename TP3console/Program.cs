using TP3console.Models.EntityFramework;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using Castle.Components.DictionaryAdapter;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TP3console
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Exo2Q1();
            //Exo2Q2();
            //Exo2Q3();
            //Exo2Q4();
            //Exo2Q5();
            //Exo2Q6();
            //Exo2Q7();
            //Exo2Q8();
            //Exo2Q9();
            //Auth();
            //Update();
            //Delete();
            //AddAvi();
            //Add2FilmDrame();
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
        public static void Exo2Q2()
        {
            var ctx = new FilmsDBContext();
            //Pour que cela marche, il faut que la requête envoie les mêmes noms de colonnes que les classes c#.
            var users = ctx.Utilisateurs;
            foreach (var user in users)
            {
                Console.WriteLine(user.Email.ToString());
            }
        }
        public static void Exo2Q3()
        {
            var ctx = new FilmsDBContext();
            //Pour que cela marche, il faut que la requête envoie les mêmes noms de colonnes que les classes c#.
            var users = ctx.Utilisateurs.OrderBy(user => user.Login);
            foreach (var user in users)
            {
                Console.WriteLine(user.ToString());
            }
        }

        public static void Exo2Q4()
        {
            var ctx = new FilmsDBContext();
            //Pour que cela marche, il faut que la requête envoie les mêmes noms de colonnes que les classes c#.
            var categorieAction = ctx.Categories.First(c => c.Nom == "Action");
            foreach (var film in categorieAction.Films)
            {
                Console.WriteLine(film.Id + " : " + film.Nom);
            }
        }
        public static void Exo2Q5()
        {
            var ctx = new FilmsDBContext();
            //Pour que cela marche, il faut que la requête envoie les mêmes noms de colonnes que les classes c#.
            var nbCat = ctx.Categories.Count();
            Console.WriteLine(nbCat);
        }
        public static void Exo2Q6()
        {
            var ctx = new FilmsDBContext();
            //Pour que cela marche, il faut que la requête envoie les mêmes noms de colonnes que les classes c#.
            var note = ctx.Avis.Min(x => x.Note);
            Console.WriteLine(note);
        }
        public static void Exo2Q7()
        {
            var ctx = new FilmsDBContext();
            //Pour que cela marche, il faut que la requête envoie les mêmes noms de colonnes que les classes c#.
            var films = ctx.Films.Where(film => film.Nom.ToLower().StartsWith("le"));
            foreach (var film in films)
            {
                Console.WriteLine(film);
            }
        }
        public static void Exo2Q8()
        {
            var ctx = new FilmsDBContext();
            //Pour que cela marche, il faut que la requête envoie les mêmes noms de colonnes que les classes c#.
            decimal moyenne = 0;
            int count = 0;
            foreach (var avi in ctx.Avis.Where(film => film.FilmNavigation.Nom.ToLower().StartsWith("pulp fiction")).ToList())
            {
                count++;
                moyenne += avi.Note;
            }
            moyenne /= count;
            Console.WriteLine(moyenne);
        }
        public static void Exo2Q9()
        {
            var ctx = new FilmsDBContext();
            //Pour que cela marche, il faut que la requête envoie les mêmes noms de colonnes que les classes c#.
            var noteBase = ctx.Avis;
            decimal note = 0;
            var res = "";
            foreach (var lanote in noteBase)
            {
                if (lanote.Note > note)
                    note = lanote.Note;
                res = lanote.Utilisateur.ToString();
            }
            Console.WriteLine(res + " : " + note);
        }

        public static void Auth()
        {
            var ctx = new FilmsDBContext();

            Utilisateur user = new Utilisateur();
            user.Login = "rassatl";
            user.Email = "lou.rassat@etu.univ-smb.fr";
            user.Pwd = "azety";

            ctx.Utilisateurs.Add(user);

            ctx.SaveChanges();
        }

        public static void Update()
        {
            var ctx = new FilmsDBContext();

            var films = ctx.Films.First(film => film.Nom.ToLower().Contains("l'armee des douze singes"));
            films.Description = "nsm la description";
            ctx.SaveChanges();
        }
        public static void Delete()
        {
            var ctx = new FilmsDBContext();

            var films = ctx.Films.First(film => film.Nom.ToLower().Contains("l'armee des douze singes"));
            ctx.Films.Remove(films);
            foreach(var avis in ctx.Avis.Where(s => s.Film == films.Id))
            {
                ctx.Avis.Remove(avis);
            }
            ctx.SaveChanges();
        }
        
        public static void AddAvi()
        {
            var ctx = new FilmsDBContext();

            Avi avi = new Avi();
            avi.Film = 14;
            avi.Utilisateur = 1;
            avi.Avis = "même mon père fait mieux, j'avais oublié, j'en ai pas";
            avi.Note = 1;
            
            ctx.Avis.Add(avi);

            ctx.SaveChanges();
        }

        public static void Add2FilmDrame()
        {
            var ctx = new FilmsDBContext();

            Film film = new Film();
            film.Id = 50;
            film.Nom = "Two Girls One Cup";
            film.Description = "It's litteraly two girls that shit in a cup";
            film.Categorie = 5;

            Film film2 = new Film();
            film2.Id = 51;
            film2.Nom = "CupHead";
            film2.Description = "It's litteraly the hardest game in the world";
            film2.Categorie = 5;

            ctx.Films.AddRange(film, film2);

            ctx.SaveChanges();
        }
    }
}