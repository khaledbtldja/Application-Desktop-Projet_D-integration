using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCanabis
{
    public class Utilisateur
    {
        public Utilisateur(string username, string password, string nom, string prenom, string telephone, string adresse)
        {
            this.username = username;
            this.password = password;
            this.nom = nom;
            this.prenom = prenom;
            this.telephone = telephone;
            this.adresse = adresse;
        }

        public string username
        {
            get;set;
        }
        public string password
        {
            get;set;
        }
        public string nom
        {
            get; set;
        }
        public string prenom
        {
            get; set;
        }
        public string telephone
        {
            get; set;
        }
        public string adresse
        {
            get; set;

        }
    }
}
