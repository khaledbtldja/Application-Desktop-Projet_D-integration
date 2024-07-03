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
    /// Interaction logic for GU.xaml
    /// </summary>
    public partial class GU : Page
    {
        DBConnect db;
        List<Utilisateur> users;
        private Utilisateur temp;
        private bool uncheckbool = false;
        private MainPanel parent;
        public GU(MainPanel Parent)
        {
            parent = Parent;
            temp = null;
            db = new DBConnect();
            users = db.listu("SELECT * FROM USER");
            InitializeComponent();
            DataGridP.ItemsSource = null;
            DataGridP.ItemsSource = users;
        }

        private void btnmodifier_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var rowdata = (string)button.Tag;
            string id = rowdata;
            foreach(Utilisateur ut in users)
            {
                if (ut.username == id)
                {
                    temp = ut;
                }
            }
            un.Text = temp.username;
            pwd.Password = temp.password;
            nom.Text = temp.nom;
            prenom.Text = temp.prenom;
            adresse.Text = temp.adresse;
            telephone.Text = temp.telephone;
            uncheckbool = true;
            uncheck.Content = "";
            boutonajout.IsEnabled = false;
            boutonmodification.IsEnabled = true;
            annulermodification.IsEnabled = true;
        }

        private void btnsupprimer_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Êtes Vous Sur de Vouloir Supprimer?", "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                var button = sender as Button;
                var rowdata = (string)button.Tag;
                string id = rowdata;
                db.NRQ("DELETE FROM USER WHERE USERNAME='" + id + "'");
                MessageBox.Show("Suppression Terminée");
                un.Text = "";
                pwd.Password = "";
                nom.Text = "";
                prenom.Text = "";
                adresse.Text = "";
                telephone.Text = "";
                uncheck.Content = "";
                users = db.listu("SELECT * FROM USER");
                DataGridP.ItemsSource = null;
                DataGridP.ItemsSource = users;

            }
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (un.Text.Length<4)
            {
                uncheck.Foreground = Brushes.Red;
                uncheck.Content = "Le Nom D'Utilisateur doit avoir au moins 4 Caractères";
                uncheckbool = false;
            }
            else
            {
                foreach(Utilisateur ut in users)
                {
                    if (un.Text == ut.username )
                    {
                        if(boutonmodification.IsEnabled && un.Text == temp.username)
                        {
                            uncheck.Content = "";
                            uncheckbool = true;
                        }
                        else
                        {
                            uncheck.Foreground = Brushes.Red;
                            uncheck.Content = "Nom d'Utilisateur Indisponible";
                            uncheckbool = false;
                        }
                    }
                    else
                    {
                        uncheck.Foreground = Brushes.Green;
                        uncheck.Content = "Nom d'Utilisateur Disponible";
                        uncheckbool = true;
                    }
                }
            }
        }

        private void boutonajout_Click(object sender, RoutedEventArgs e)
        {
            if(uncheckbool && pwd.Password!="" && nom.Text!="" && prenom.Text!=""&&adresse.Text!="" && telephone.Text != "")
            {
                db.NRQ("INSERT INTO USER VALUES('"+un.Text+"','"+pwd.Password+"','"+nom.Text+"','"+prenom.Text+"','"+adresse.Text+"','"+telephone.Text+"')");
                un.Text = "";
                pwd.Password = "";
                nom.Text = "";
                prenom.Text = "";
                adresse.Text = "";
                telephone.Text = "";
                uncheck.Content = "";
                MessageBox.Show("Ajout Terminé");
                users = db.listu("SELECT * FROM USER");
                DataGridP.ItemsSource = null;
                DataGridP.ItemsSource = users;
            }
            else
            {
                MessageBox.Show("Remplissez Tout les Champs!");
            }
        }

        private void boutonmodification_Click(object sender, RoutedEventArgs e)
        {
            if (uncheckbool && pwd.Password != "" && nom.Text != "" && prenom.Text != "" && adresse.Text != "" && telephone.Text != "")
            {
                if (un.Text == temp.username)
                {
                    db.NRQ("UPDATE USER SET PASSWORD='"+pwd.Password+"' , NOM='"+nom.Text+"' , PRENOM='"+prenom.Text+"' , ADRESSE='"+adresse.Text+"', TELEPHONE='"+telephone.Text+"' WHERE USERNAME='"+un.Text+"'");
                    un.Text = "";
                    pwd.Password = "";
                    nom.Text = "";
                    prenom.Text = "";
                    adresse.Text = "";
                    telephone.Text = "";
                    uncheck.Content = "";
                    MessageBox.Show("Modification Terminée");
                    boutonmodification.IsEnabled = false;
                    annulermodification.IsEnabled = false;
                    boutonajout.IsEnabled = true;
                    users = db.listu("SELECT * FROM USER");
                    DataGridP.ItemsSource = null;
                    DataGridP.ItemsSource = users;
                }
                else
                {
                    db.NRQ("UPDATE USER SET USERNAME='"+un.Text+"' , PASSWORD='" + pwd.Password + "' , NOM='" + nom.Text + "' , PRENOM='" + prenom.Text + "' , ADRESSE='" + adresse.Text + "', TELEPHONE='" + telephone.Text + "' WHERE USERNAME='" + temp.username + "'");
                    un.Text = "";
                    pwd.Password = "";
                    nom.Text = "";
                    prenom.Text = "";
                    adresse.Text = "";
                    telephone.Text = "";
                    uncheck.Content = "";
                    MessageBox.Show("Modification Terminée");
                    boutonmodification.IsEnabled = false;
                    annulermodification.IsEnabled = false;
                    boutonajout.IsEnabled = true;
                    users = db.listu("SELECT * FROM USER");
                    DataGridP.ItemsSource = null;
                    DataGridP.ItemsSource = users;
                }
            }
            else
            {
                MessageBox.Show("Remplissez Tout les Champs!");
            }
        }

        private void annulermodification_Click(object sender, RoutedEventArgs e)
        {
            un.Text = "";
            pwd.Password = "";
            nom.Text = "";
            prenom.Text = "";
            adresse.Text = "";
            telephone.Text = "";
            uncheck.Content = "";
            boutonmodification.IsEnabled = false;
            annulermodification.IsEnabled = false;
            boutonajout.IsEnabled = true;
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            parent.ContentPage.Content = new GestionGenerale(parent);
        }
    }
}
