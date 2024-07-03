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
    public partial class GT : Page
    {
        private List<Type> list;
        private DBConnect db;
        private MainPanel Parent;
        private Type temp;
        public GT(MainPanel parent)
        {
            db = new DBConnect();
            Parent = parent;
            InitializeComponent();
            list = db.listtype("SELECT * FROM TYPE");
            DataGridP.ItemsSource = null;
            DataGridP.ItemsSource = list;
        }
        private void btnmodifier_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var rowdata = (string)button.Tag;
            string id = rowdata;
            foreach (Type en in list)
            {
                if (en.ABBREV == id)
                {
                    temp = en;
                }
            }
            nom.Text = temp.DESCRIPTION;
            description.Text = temp.ABBREV;
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
                db.NRQ("DELETE FROM TYPE WHERE ABBREV='" + id + "'");
                MessageBox.Show("Suppression Terminée");
                nom.Text = "";
                description.Text = "";
                boutonmodification.IsEnabled = false;
                annulermodification.IsEnabled = false;
                boutonajout.IsEnabled = true;
                list = db.listtype("SELECT * FROM TYPE");
                DataGridP.ItemsSource = null;
                DataGridP.ItemsSource = list;
            }
        }



        private void boutonajout_Click(object sender, RoutedEventArgs e)
        {
            if (nom.Text != "" && description.Text != "")
            {

                db.NRQ("INSERT INTO TYPE(DESCRIPTION,ABBREV) VALUES('" + nom.Text + "','" + description.Text + "')");
                MessageBox.Show("Ajout Terminé");
                nom.Text = "";
                description.Text = "";
                list = db.listtype("SELECT * FROM TYPE");
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
            if (nom.Text != "" && description.Text != "")
            {
                if (description.Text == temp.ABBREV)
                {
                    db.NRQ("UPDATE TYPE SET DESCRIPTION='" + nom.Text + "' WHERE ID='" + temp.ABBREV + "' ");
                    MessageBox.Show("Modification Terminée");
                    nom.Text = "";
                    description.Text = "";
                    list = db.listtype("SELECT * FROM TYPE");
                    DataGridP.ItemsSource = null;
                    DataGridP.ItemsSource = list;
                }
                else
                {
                    db.NRQ("UPDATE TYPE SET ABBREV='" + description.Text + "', DESCRIPTION='" + nom.Text + "' WHERE ID='" + temp.ABBREV + "' ");
                    MessageBox.Show("Modification Terminée");
                    nom.Text = "";
                    description.Text = "";
                    list = db.listtype("SELECT * FROM TYPE");
                    DataGridP.ItemsSource = null;
                    DataGridP.ItemsSource = list;
                }
            }
            else
            {
                MessageBox.Show("Remplissez Tout les Champs!");
            }

        }

        private void annulermodification_Click(object sender, RoutedEventArgs e)
        {
            nom.Text = "";
            description.Text = "";
            boutonmodification.IsEnabled = false;
            annulermodification.IsEnabled = false;
            boutonajout.IsEnabled = true;
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Parent.ContentPage.Content = new GestionGenerale(Parent);
        }
    }
}
