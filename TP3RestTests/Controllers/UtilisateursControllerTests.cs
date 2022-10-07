using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP3Rest.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2Console.Models.EntityFramework;
using Microsoft.EntityFrameworkCore;
using TP3Rest.Models.EntityFramework;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP3Rest.Models.Repository;
using TP3Rest.Models.DataManager;

namespace TP3Rest.Controllers.Tests
{
    [TestClass()]
    public class UtilisateursControllerTests
    {
        private SeriesDBContext _context;
        private UtilisateursController _controller;
        private IDataRepository<Utilisateur> _dataRepository;

        public UtilisateursControllerTests()
        {
            var builder = new DbContextOptionsBuilder<SeriesDBContext>()
                .UseNpgsql("Server=localhost;port=5432;Database=SeriesDB;uid=postgres;password=root;");

            _context = new SeriesDBContext(builder.Options);
            _dataRepository = new UtilisateurManager(_context);
            _controller = new UtilisateursController(_dataRepository);
        }

        [TestMethod]
        public void GetUtilisateursTest()
        {
            List<Utilisateur> utilisateurs = _context.Utilisateurs.ToListAsync().Result;
            List<Utilisateur> utilisateurs2 = (_controller.GetUtilisateurs().Result).Value.ToList();

            CollectionAssert.AreEqual(utilisateurs, utilisateurs2);
        }

        [TestMethod]
        public void GetUtilisateurByIdTest()
        {
            int id = 1;

            Utilisateur? utilisateur = _context.Utilisateurs.FindAsync(id).Result;
            Utilisateur? utilisateur2 = (_controller.GetUtilisateur(id).Result).Value;

            Assert.AreEqual(utilisateur, utilisateur2);
        }

        [TestMethod]
        public void GetUtilisateurByIdFailTest()
        {

            Utilisateur? utilisateur = _context.Utilisateurs.FindAsync(1).Result;
            Utilisateur? utilisateur2 = (_controller.GetUtilisateur(2).Result).Value;

            Assert.AreNotEqual(utilisateur, utilisateur2);
        }


        [TestMethod]
        public void GetUtilisateurByEmailTest()
        {
            string mail = "gdominguez0@washingtonpost.com";

            Utilisateur? utilisateur = _context.Utilisateurs.FirstAsync(e => e.Mail == mail).Result;
            Utilisateur? utilisateur2 = (_controller.GetUtilisateurByEmail(mail).Result).Value;

            Assert.AreEqual(utilisateur, utilisateur2);
        }

        [TestMethod]
        public void GetUtilisateurByEmailFailTest()
        {
            string mail1 = "gdominguez0@washingtonpost.com";
            string mail2 = "rrichings1@naver.com";

            Utilisateur? utilisateur = _context.Utilisateurs.FirstAsync(e => e.Mail == mail1).Result;
            Utilisateur? utilisateur2 = (_controller.GetUtilisateurByEmail(mail2).Result).Value;

            Assert.AreNotEqual(utilisateur, utilisateur2);
        }

        [TestMethod]
        public void Postutilisateur_ModelValidated_CreationOK()
        {
            // Arrange
            Random rnd = new Random();
            int chiffre = rnd.Next(1, 1000000000);
            // Le mail doit être unique donc 2 possibilités :
            // 1. on s'arrange pour que le mail soit unique en concaténant un random ou un timestamp
            // 2. On supprime le user après l'avoir créé. Dans ce cas, nous avons besoin d'appeler la méthode DELETE du WS => la décommenter
            Utilisateur userAtester = new Utilisateur()
            {
                Nom = "MACHIN",
                Prenom = "Luc",
                Mobile = "0606070809",
                Mail = "machin" + chiffre + "@gmail.com",
                Pwd = "Toto1234!",
                Rue = "Chemin de Bellevue",
                CodePostal = "74940",
                Ville = "Annecy-le-Vieux",
                Pays = "France",
                Latitude = null,
                Longitude = null
            };
            // Act
            var result = _controller.PostUtilisateur(userAtester).Result; // .Result pour appeler la méthode async de manière synchrone, afin d'obtenir le résultat
            var result2 = _controller.GetUtilisateurByEmail(userAtester.Mail);
            var actionResult = result2.Result as ActionResult<Utilisateur>;
            // Assert
            Assert.IsInstanceOfType(actionResult.Value, typeof(Utilisateur), "Pas un utilisateur");
            Utilisateur? userRecupere = _context.Utilisateurs.Where(u => u.Mail.ToUpper() ==
            userAtester.Mail.ToUpper()).FirstOrDefault();
            // On ne connait pas l'ID de l’utilisateur envoyé car numéro automatique.
            // Du coup, on récupère l'ID de celui récupéré et on compare ensuite les 2 users
            userAtester.UtilisateurId = userRecupere.UtilisateurId;
            Assert.AreEqual(userRecupere, userAtester, "Utilisateurs pas identiques");
        }
    }
}