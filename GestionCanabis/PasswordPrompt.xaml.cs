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
    /// Interaction logic for PasswordPrompt.xaml
    /// </summary>
    public partial class PasswordPrompt : Page
    {
        private MainPanel parent;
        public PasswordPrompt(MainPanel p)
        {
            parent = p;
            InitializeComponent();
            pwd.Focus();
        }

        private void adminbutton_Click(object sender, RoutedEventArgs e)
        {
            if (pwd.Password != "")
            {
                DBConnect db = new DBConnect();
                if (db.pwdcheck("SELECT * from ADMINPWD WHERE PWD='" + pwd.Password + "'"))
                {
                    parent.ContentPage.Content = new GestionGenerale(parent);
                }
                else
                {
                    MessageBox.Show("Mot de Passe Incorret!");
                }
            }
            else
            {
                MessageBox.Show("Entrez un Mot de Passe");
            }
        }

        private void pwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                adminbutton_Click(sender, e);
            }
        }
    }
}
