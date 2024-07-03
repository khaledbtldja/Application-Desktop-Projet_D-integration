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
    /// Interaction logic for GR.xaml
    /// </summary>
    public partial class GR : Page
    {
        private MainPanel parent;
        private DBConnect db;
        private List<StringWrapper> list;
        private string temp;
        public GR(MainPanel Parent)
        {
            parent = Parent;
            db = new DBConnect();
            list = new List<StringWrapper>();
            foreach(string s in db.GetEnumValues("RESPONSABLE"))
            {
                list.Add(new StringWrapper(s));
            }
            InitializeComponent();
            DataGridP.ItemsSource = null;
            DataGridP.ItemsSource = list;
        }
        private void btnmodifier_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var rowdata = (string)button.Tag;
            string id = rowdata;
            nom.Text = id;
            temp = id;
            boutonmodification.IsEnabled = true;
            annulermodification.IsEnabled = true;
            boutonajout.IsEnabled = false;

        }

        private void btnsupprimer_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Êtes Vous Sur de Vouloir Supprimer?", "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                var button = sender as Button;
                var rowdata = (string)button.Tag;
                string id = rowdata;
                string query = "ENUM('";
                foreach (StringWrapper sw in list)
                {
                    if (sw.a != id)
                    {
                        query = query + sw.a + "','";
                    }
                        
                }
                string en = query.Substring(0, query.Length - 3);
                db.NRQ("ALTER TABLE PLANTULE MODIFY COLUMN RESPONSABLE "+en+"')");
                MessageBox.Show("Suppression Terminée");
                nom.Text = "";
                boutonmodification.IsEnabled = false;
                annulermodification.IsEnabled = false;
                boutonajout.IsEnabled = true;
                list = new List<StringWrapper>();
                foreach (string s in db.GetEnumValues("RESPONSABLE"))
                {
                    list.Add(new StringWrapper(s));
                }
                DataGridP.ItemsSource = null;
                DataGridP.ItemsSource = list;
            }
        }

        

        private void boutonajout_Click(object sender, RoutedEventArgs e)
        {
            if (nom.Text != "")
            {
                string query = "ENUM('";
                foreach (StringWrapper sw in list)
                {
                        query = query + sw.a + "','";
                }
                db.NRQ("ALTER TABLE PLANTULE MODIFY COLUMN RESPONSABLE " + query +nom.Text+ "')");
                MessageBox.Show("Ajout Terminé");
                nom.Text = "";
                list = new List<StringWrapper>();
                foreach (string s in db.GetEnumValues("RESPONSABLE"))
                {
                    list.Add(new StringWrapper(s));
                }
                DataGridP.ItemsSource = null;
                DataGridP.ItemsSource = list;
            }
            else
            {
                MessageBox.Show("Remplissez Tout les Champs!");
            }
        }

        private void boutonmodification_Click(object sender, RoutedEventArgs e)
        {
            if (nom.Text!=temp)
            {
                if (nom.Text != "")
                {
                    string query = "ENUM('";
                    foreach (StringWrapper sw in list)
                    {
                        if (sw.a != temp)
                        {
                            query = query + sw.a + "','";
                        }
                        else
                        {
                            query = query + nom.Text + "','";
                        }

                    }
                    string en = query.Substring(0, query.Length - 3);
                    db.NRQ("ALTER TABLE PLANTULE MODIFY COLUMN RESPONSABLE " + en + "')");
                    MessageBox.Show("Modification Terminée");
                    nom.Text = "";
                    boutonmodification.IsEnabled = false;
                    annulermodification.IsEnabled = false;
                    boutonajout.IsEnabled = true;
                    list = new List<StringWrapper>();
                    foreach (string s in db.GetEnumValues("RESPONSABLE"))
                    {
                        list.Add(new StringWrapper(s));
                    }
                    DataGridP.ItemsSource = null;
                    DataGridP.ItemsSource = list;
                }
                else
                {
                    MessageBox.Show("Remplissez Tout les Champs!");
                }
            }
            else
            {
                MessageBox.Show("Modification Terminée");
                nom.Text = "";
                boutonmodification.IsEnabled = false;
                annulermodification.IsEnabled = false;
                boutonajout.IsEnabled = true;
            }
        }

        private void annulermodification_Click(object sender, RoutedEventArgs e)
        {
            nom.Text = "";
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
