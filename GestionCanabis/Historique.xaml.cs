using OpenCvSharp;
using OpenCvSharp.Extensions;
using IronBarCode;
using OpenCvSharp.WpfExtensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Windows.Threading;
using System.Windows.Media.Animation;

namespace GestionCanabis
{
    /// <summary>
    /// Interaction logic for Historique.xaml
    /// </summary>
    public partial class Historique : Page
    {
        List<HistoriqueP> listh;
        List<string> listt;
        private DBConnect db;
        private VideoCapture capture;
        private Mat frame;
        private Bitmap image;
        private bool isCameraRunning = false;
        private DispatcherTimer timer;

        public Historique()
        {
            db = new DBConnect();
            listt = new List<string>();
            listh = new List<HistoriqueP>();
            InitializeComponent();
        }
        public Historique(string ID)
        {
            db = new DBConnect();
            listt = new List<String>();
            listh = db.listh("SELECT * from HISTORIQUE WHERE CHANGEMENT LIKE '%"+ID+"%'");
            foreach(HistoriqueP hp in listh)
            {
                listt.Add(hp.text());
            }
            InitializeComponent();
            TextBlocksItemsControl.ItemsSource = listt;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            listh = db.listh("SELECT * from HISTORIQUE WHERE CHANGEMENT LIKE '%" + IDP.Text + "%'");

            if (listh.Count == 0)
            {
                MessageBox.Show("Plante Inexistante!");
            }
            else
            {
                foreach (HistoriqueP hp in listh)
                {
                    listt.Add(hp.text());
                }
                TextBlocksItemsControl.Items.Clear();
                TextBlocksItemsControl.ItemsSource = null;
                TextBlocksItemsControl.ItemsSource = listt;
            }
        }

        private void startCamera_Click(object sender, RoutedEventArgs e)
        {
            if (!isCameraRunning)
            {
                capture = new VideoCapture(0);
                frame = new Mat();
                isCameraRunning = true;
                
                timer = new DispatcherTimer();
                timer.Tick += new EventHandler(FPS);
                timer.Tick += new EventHandler(CaptureFrame);
                timer.Interval = TimeSpan.FromMilliseconds(30);
                timer.Start();
            }
        }
        private async void FPS(object sender, EventArgs e)
        {
            try
            {
                if (capture.IsOpened())
                {
                    capture.Read(frame);
                    CameraFeed.Source = BitmapToImageSource(frame.ToBitmap());
                }
            }catch(Exception exc)
            {

            }
        }
        private void CaptureFrame(object sender, EventArgs e)
        {
            if (capture.IsOpened())
            {
                if (!frame.Empty())
                {
                    image = frame.ToBitmap();
                    var result = BarcodeReader.QuicklyReadOneBarcode(image, BarcodeEncoding.QRCode);
                    if (result != null)
                    {
                        timer.Stop();
                        listh = db.listh("SELECT * from HISTORIQUE WHERE CHANGEMENT LIKE '%" + result+ "%'");

                        if (listh.Count == 0)
                        {
                            MessageBox.Show("Plante Inexistante!");
                        }
                        else
                        {
                            isCameraRunning = false;
                            capture = null;
                            image = frame.ToBitmap();
                            frame = null;
                            foreach (HistoriqueP hp in listh)
                            {
                                listt.Add(hp.text());
                            }
                            TextBlocksItemsControl.Items.Clear();
                            TextBlocksItemsControl.ItemsSource = null;
                            TextBlocksItemsControl.ItemsSource = listt;
                        }
                    }
                }
            }
        }
        private BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            using (var memory = new System.IO.MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                return bitmapImage;
            }
        }
        private void Border_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Border border = sender as Border;
            TextBlock textBlock = border.Child as TextBlock;

            if (border != null && textBlock != null)
            {
                textBlock.Measure(new System.Windows.Size(border.ActualWidth, double.PositiveInfinity));
                double desiredHeight = textBlock.DesiredSize.Height;

                DoubleAnimation heightAnimation = new DoubleAnimation
                {
                    To = desiredHeight+30,
                    Duration = new Duration(TimeSpan.FromSeconds(0.2))
                };
                border.BeginAnimation(Border.HeightProperty, heightAnimation);
            }
        }

        private void IDP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Button_Click(sender, e);
            }
        }
    }
}
