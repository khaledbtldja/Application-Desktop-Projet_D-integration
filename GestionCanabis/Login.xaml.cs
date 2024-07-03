using System.Text;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            try
            {
                InitializeComponent();
                un.Focus();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool login = (new DBConnect()).login("SELECT * FROM USER WHERE USERNAME='" + un.Text + "' and PASSWORD='" +pwd.Password+ "'");
            if (login)
            {
                MainPanel mp = new MainPanel(un.Text);
                this.Close();
                mp.Show();
            }
            else
            {
                MessageBox.Show("Identifiants Invalide!");
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton== MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void un_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                pwd.Focus();
            }
        }

        private void pwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Button_Click(sender, e);
            }
        }
    }
}