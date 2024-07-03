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
    /// Interaction logic for PDFViewerWindow.xaml
    /// </summary>
    public partial class PDFViewerWindow : Window
    {
        private GestionPlantules gps;
        private string path;
        public PDFViewerWindow(GestionPlantules gp,string paths)
        {
            gps = gp;
            InitializeComponent();
            path = paths;
            var uri = new Uri(path);
            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(path, UriKind.Absolute);
            bitmap.EndInit();
            imagebox.Source = bitmap;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            gps.PDFVIEWERCLOSED();
        }
    }
}
