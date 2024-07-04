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
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;
using System.IO;
using System.Drawing.Imaging;

namespace GestionCanabis
{
    /// <summary>
    /// Interaction logic for Historique.xaml
    /// </summary>
    public partial class Historique : Page
    {
        private bool iscamerarunning = false;
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
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
            if (!iscamerarunning)
            {
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                if (videoDevices.Count > 0)
                {
                    videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
                    videoSource.NewFrame += new NewFrameEventHandler(FPS);
                    videoSource.Start();
                }
                else
                {
                    MessageBox.Show("No video devices found.");
                }
            }
            else
            {
                videoSource.Stop();
            }
        }
        private async void FPS(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            BitmapImage bitmapImage = BitmapToBitmapImage(bitmap);
            this.Dispatcher.Invoke(() => CameraFeed.Source = bitmapImage);

            string result="";
            this.Dispatcher.Invoke(() => result = BarcodeReader.QuicklyReadOneBarcode(bitmap, BarcodeEncoding.QRCode).Text);
            if (result != "")
            {
                listh = db.listh("SELECT * from HISTORIQUE WHERE CHANGEMENT LIKE '%" + result + "%'");

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
                    TextBlocksItemsControl.ItemsSource = null;
                    TextBlocksItemsControl.Items.Clear();
                    TextBlocksItemsControl.ItemsSource = null;
                    TextBlocksItemsControl.ItemsSource = listt;
                }
            }

            bitmap.Dispose();
        }
        private BitmapImage BitmapToBitmapImage(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapImage = new BitmapImage();
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
