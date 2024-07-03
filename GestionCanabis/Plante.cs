using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using IronBarCode;
using IronSoftware.Drawing;

namespace GestionCanabis
{
    public class Plante
    {

        public Plante(string eTATDESANTE, DateTime dATEENTREE, string iD, string pROVENANCE, string dESCRIPTION, string sTADE, string eNTREPOSAGE, bool aCTIVITE, DateTime dATERETRAIT, string rAISONDERETRAIT, string rESPONSABLE, string nOTE)
        {
            rowchecked = false;
            ETATDESANTE = eTATDESANTE;
            DATEENTREE = dATEENTREE;
            ID = iD;
            PROVENANCE = pROVENANCE;
            DESCRIPTION = dESCRIPTION;
            STADE = sTADE;
            ENTREPOSAGE = eNTREPOSAGE;
            ACTIVITE = aCTIVITE;
            DATERETRAIT = dATERETRAIT;
            RAISONDERETRAIT = rAISONDERETRAIT;
            RESPONSABLE = rESPONSABLE;
            NOTE = nOTE;
        }
        public string DE
        {
            get;
            set;
        }
        public string DR
        {
            get;
            set;
        }
        public string ETATDESANTE
        {
            get;
            set;
        }
        public DateTime DATEENTREE
        {
            get;
            set;
        }
        public string ID
        {
            get;
            set;
        }
        public string PROVENANCE
        {
            get;
            set;
        }
        public string DESCRIPTION
        {
            get;
            set;
        }
        public string STADE
        {
            get;
            set;
        }
        public string ENTREPOSAGE
        {
            get;
            set;
        }
        public bool ACTIVITE
        {
            get;
            set;
        }
        public DateTime DATERETRAIT
        {
            get;
            set;
        }
        public string RAISONDERETRAIT
        {
            get;
            set;
        }
        public string RESPONSABLE
        {
            get;
            set;
        }
        public string NOTE
        {
            get;
            set;
        }
        public Image CodeQR
        {
            get;set;
        }
        public string AC
        {
            get;
            set;
        }
        public bool AR
        {
            get;
            set;
        }
        public int Rownumber
        {
            get;
            set;
        }
        public bool rowchecked
        {
            get;set;
        }
        public bool verified
        {
            get;
            set;
        }
        public string verifier
        {
            get;set;
        }
        public void datesetter()
        {
            if (DATEENTREE != new DateTime())
            {
                DE = DATEENTREE.Date.Year + "-" + DATEENTREE.Date.Month + "-" + DATEENTREE.Date.Day;
            }
            else
            {
                DE = "";
            }
            if (DATERETRAIT!=new DateTime())
            {
                DR = DATERETRAIT.Date.Year + "-" + DATERETRAIT.Date.Month + "-" + DATERETRAIT.Date.Day;
                AR = true;
            }
            else
            {
                DR = "";
                AR = false;
            }
            if (ACTIVITE)
            {
                AC = "Actif";
            }
            else
            {
                AC = "Inactif";
            }
        }
        public string Changement(Plante p,string Username)
        {
            string resultat = "Utilisateur : "+Username+"\nPlante "+ID+"\nChangement de \n";
            if (p.ETATDESANTE != ETATDESANTE)
            {
                resultat = resultat + ("Etat de Santé depuis "+ETATDESANTE+" vers "+p.ETATDESANTE+"\n");
            }
            if (p.DATEENTREE != DATEENTREE)
            {
                resultat = resultat + ("Date d'Entree depuis "+DATEENTREE.Date+" vers "+p.DATEENTREE.Date+"\n");
            }
            if (p.PROVENANCE != PROVENANCE)
            {
                resultat = resultat + ("Provenance depuis "+PROVENANCE+" vers "+p.PROVENANCE+"\n");
            }
            if (!p.DESCRIPTION.Contains(DESCRIPTION))
            {
                resultat = resultat + ("Description depuis "+DESCRIPTION+" vers "+p.DESCRIPTION+"\n");
            }
            if (p.STADE != STADE)
            {
                resultat = resultat + ("Stade depuis "+STADE+" vers "+p.STADE+"\n");
            }
            if (p.ENTREPOSAGE != ENTREPOSAGE)
            {
                resultat = resultat + ("Entreposage depuis "+ENTREPOSAGE+" vers "+p.ENTREPOSAGE+"\n");
            }
            if (p.ACTIVITE != ACTIVITE)
            {
                if (ACTIVITE)
                {
                    resultat = resultat + ("Activité depuis ACTIF vers INACTIF\n");
                }
                else
                {
                    resultat = resultat + ("Activité depuis INACTIF vers ACTIF\n");
                }
            }
            if (p.DATERETRAIT != DATERETRAIT)
            {
                if (DATERETRAIT == new DateTime())
                {
                    resultat = resultat + ("Date de retrait ajoutée le"+p.DATERETRAIT.Date+"\n");
                }
                else
                {
                    resultat = resultat + ("Date retrait depuis le"+DATERETRAIT.Date+" vers le "+p.DATERETRAIT.Date+"\n");
                }
            }
            if (p.RAISONDERETRAIT != RAISONDERETRAIT)
            {
                if (RAISONDERETRAIT == null)
                {
                    resultat = resultat + ("Raison de retrait ajoutée : "+p.RAISONDERETRAIT+"\n");
                }
                else
                {
                    resultat = resultat + ("Raison de retrait depuis : "+RAISONDERETRAIT+"\nVers : "+p.RAISONDERETRAIT+"\n");
                }
            }
            if (p.RESPONSABLE != RESPONSABLE)
            {
                if (RESPONSABLE == null)
                {
                    resultat = resultat + ("Responsable ajouté : "+p.RESPONSABLE+"\n");
                }
                else
                {
                    resultat = resultat + ("Responsable depuis " + RESPONSABLE + " vers " + p.RESPONSABLE+"\n");
                }
            }
            if (p.NOTE!= NOTE)
            {
                if (NOTE == null)
                {
                    resultat = resultat + ("Note ajoutée : "+p.NOTE+"\n");
                }
                else
                {
                    resultat = resultat + ("Note depuis : " + NOTE + "\nVers : " + p.NOTE+"\n");
                }
            }
            resultat = resultat+("\n\n\n***FIN DU CHANGEMENT***");
            return resultat;
        }
        public void importverification()
        {
            if (ETATDESANTE != "" && DE!="" && ID != "" && PROVENANCE != "" && DESCRIPTION != "" && STADE != "" && ENTREPOSAGE != "" && RESPONSABLE != "")
            {
                if (ACTIVITE)
                {
                    verified= true;
                    verifier = "true";
                }
                else
                {
                    if((DR != "" && RAISONDERETRAIT != "" )||(DR != "" && RAISONDERETRAIT == "AUTRE" && NOTE != ""))
                    {
                        verified= true;
                        verifier = "true";
                    }
                    else
                    {
                        verified= false;
                        verifier = "false";
                    }
                }
            }
            else
            {
                verified= false;
                verifier = "false";
            }
        }
    }
}
