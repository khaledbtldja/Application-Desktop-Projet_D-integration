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
using System.Windows.Shapes;

namespace GestionCanabis
{
    /// <summary>
    /// Interaction logic for MainPanel.xaml
    /// </summary>
    public partial class MainPanel : Window
    {
        private string loggedinusername;
        public List<Button> listb = new List<Button>();
        public MainPanel(string u)
        {
            InitializeComponent();
            ContentPage.Content = new Accueil();
            loggedinusername = u;
            listb.Add(btnAccueil);
            listb.Add(btnGP);
            listb.Add(btnGG);
            listb.Add(btnHistorique);
            listb.Add(btnDeconnexion);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            switch((sender as Button).Name)
            {
                case "btnAccueil":
                    {
                        
                        foreach(Button b in listb)
                        {
                            b.Background = Brushes.Black;
                        }
                        btnAccueil.Background = Brushes.White;
                        ContentPage.Content = new Importation(this);
                        break; 
                    }
                case "btnGP":
                    {
                        foreach (Button b in listb)
                        {
                            b.Background = Brushes.Black;
                        }
                        btnGP.Background = Brushes.White;
                        ContentPage.Content = new GestionPlantules(this);
                        break;
                    }
                case "btnGG":
                    {
                        foreach (Button b in listb)
                        {
                            b.Background = Brushes.Black;
                        }
                        btnGG.Background = Brushes.White;
                        ContentPage.Content = new PasswordPrompt(this);
                        break;
                    }
                case "btnHistorique":
                    {
                        foreach (Button b in listb)
                        {
                            b.Background = Brushes.Black;
                        }
                        btnHistorique.Background = Brushes.White;
                        ContentPage.Content = new Historique();
                        break;
                    }
                case "btnDeconnexion":
                    {
                        foreach (Button b in listb)
                        {
                            b.Background = Brushes.Black;
                        }
                        btnDeconnexion.Background = Brushes.White;
                        Login w = new Login();
                        this.Close();
                        w.Show();
                        break;
                    }
            }
        }
        public string user()
        {
            return loggedinusername;
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        public void deactivation()
        {
            this.IsEnabled = false;
        }
        public void activation()
        {
            this.IsEnabled = true;
        }

        private void homebutton_Click(object sender, RoutedEventArgs e)
        {
            foreach (Button b in listb)
            {
                b.Background = Brushes.Black;
            }
            ContentPage.Content = new Accueil();
        }
    }
}
