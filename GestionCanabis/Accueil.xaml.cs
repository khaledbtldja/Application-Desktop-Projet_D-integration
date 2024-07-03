using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GestionCanabis
{
    /// <summary>
    /// Interaction logic for Accueil.xaml
    /// </summary>
    public partial class Accueil : Page
    {
        private List<Plante> list;
        public Accueil()
        {
            list = new DBConnect().listp("SELECT * FROM PLANTULE");
            InitializeComponent();
            int cpa=0, cpi=0, cpbs=0, cpsm=0, cpms=0, cped=0;
            foreach(Plante p in list)
            {
                if (p.ACTIVITE)
                {
                    cpa++;
                }
                else
                {
                    cpi++;
                }
                if(p.ETATDESANTE=="BONNE SANTE")
                {
                    cpbs++;
                }
                else if(p.ETATDESANTE=="SANTE MOYENNE")
                {
                    cpsm++;
                }
                else if(p.ETATDESANTE=="MAUVAISE SANTE")
                {
                    cpms++;
                }
                else if(p.ETATDESANTE=="PLANTE EN DANGER")
                {
                    cped++;
                }
            }
            pa.Content = "" + cpa;
            pi.Content = "" + cpi;
            pbs.Content = "" + cpbs;
            psm.Content = "" + cpsm;
            pms.Content = "" + cpms;
            ped.Content = "" + cped;
            total.Content = "" + list.Count;
        }
    }
}
