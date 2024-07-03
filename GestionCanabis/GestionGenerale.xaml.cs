using ClosedXML.Excel;
using Microsoft.Win32;
using OpenCvSharp.XPhoto;
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
    /// Interaction logic for GestionGenerale.xaml
    /// </summary>
    public partial class GestionGenerale : Page
    {
        private MainPanel Parent;
        public GestionGenerale(MainPanel Parent)
        {
            InitializeComponent();
            this.Parent = Parent;
        }

        private void GU_Click(object sender, RoutedEventArgs e)
        {
            Parent.ContentPage.Content = new GU(Parent);
        }

        private void GR_Click(object sender, RoutedEventArgs e)
        {
            Parent.ContentPage.Content = new GR(Parent);
        }

        private void GE_Click(object sender, RoutedEventArgs e)
        {
            Parent.ContentPage.Content = new GE(Parent);
        }

        private void GU_GotFocus(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            btn.Foreground = Brushes.Green;
            btn.Background = Brushes.White;
        }

        private void GE_LostFocus(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            btn.Background = Brushes.Green;
            btn.Foreground = Brushes.White;
        }

        private void GT_Click(object sender, RoutedEventArgs e)
        {
            Parent.ContentPage.Content = new GT(Parent);
        }

        private void Inventaire_Click(object sender, RoutedEventArgs e)
        {
            List<Plante> list = new DBConnect().listp("SELECT * from PLANTULE");
            var workbook = new XLWorkbook();
            var worksheet = workbook.AddWorksheet("Inventaire");
            worksheet.Cell(1, 1).Value = "Etat de Santé";
            worksheet.Cell(1, 2).Value = "Date D'Entrée";
            worksheet.Cell(1, 3).Value = "Identificateur";
            worksheet.Cell(1, 4).Value = "Provenance";
            worksheet.Cell(1, 5).Value = "Description";
            worksheet.Cell(1, 6).Value = "Stade";
            worksheet.Cell(1, 7).Value = "Entreposage";
            worksheet.Cell(1, 8).Value = "Activité";
            worksheet.Cell(1, 9).Value = "Date de Retrait";
            worksheet.Cell(1, 10).Value = "Raison de Retrait";
            worksheet.Cell(1, 11).Value = "Responsable";
            worksheet.Cell(1, 12).Value = "Note";
            int i = 1;
            foreach(Plante p in list)
            {
                i++;
                switch (p.ETATDESANTE)
                {
                    case "BONNE SANTE":
                        {
                            worksheet.Cell(i, 1).Value = "Bonne Santé";
                            worksheet.Cell(i, 1).Style.Font.FontColor = XLColor.White;
                            worksheet.Cell(i, 1).Style.Fill.BackgroundColor = XLColor.Green;
                            break;
                        }
                    case "SANTE MOYENNE":
                        {
                            worksheet.Cell(i, 1).Value = "Santé Moyenne";
                            worksheet.Cell(i, 1).Style.Font.FontColor = XLColor.White;
                            worksheet.Cell(i, 1).Style.Fill.BackgroundColor = XLColor.YellowGreen;
                            break;
                        }
                    case "MAUVAISE SANTE":
                        {
                            worksheet.Cell(i, 1).Value = "Mauvaise Santé";
                            worksheet.Cell(i, 1).Style.Font.FontColor = XLColor.White;
                            worksheet.Cell(i, 1).Style.Fill.BackgroundColor = XLColor.Orange;
                            break;
                        }
                    case "PLANTE EN DANGER":
                        {
                            worksheet.Cell(i, 1).Value = "Plante en Danger";
                            worksheet.Cell(i, 1).Style.Font.FontColor = XLColor.White;
                            worksheet.Cell(i, 1).Style.Fill.BackgroundColor = XLColor.Red;
                            break;
                        }
                }
                switch (p.AC)
                {
                    case "Actif":
                        {
                            worksheet.Cell(i, 8).Value = p.AC;
                            worksheet.Cell(i, 8).Style.Font.FontColor = XLColor.White;
                            worksheet.Cell(i, 8).Style.Fill.BackgroundColor = XLColor.Green;
                            break;
                        }
                    case "Inactif":
                        {
                            worksheet.Cell(i, 8).Value = p.AC;
                            worksheet.Cell(i, 8).Style.Font.FontColor = XLColor.White;
                            worksheet.Cell(i, 8).Style.Fill.BackgroundColor = XLColor.Red;
                            break;
                        }
                }
                worksheet.Cell(i, 2).Value = p.DATEENTREE.ToString();
                worksheet.Cell(i, 3).Value = p.ID;
                worksheet.Cell(i, 4).Value = p.PROVENANCE;
                worksheet.Cell(i, 5).Value = p.DESCRIPTION;
                worksheet.Cell(i, 6).Value = p.STADE;
                worksheet.Cell(i, 7).Value = p.ENTREPOSAGE;
                if (p.ACTIVITE)
                {
                    worksheet.Cell(i, 9).Value = p.DR;
                }
                else
                {
                    worksheet.Cell(i, 9).Value = p.DATERETRAIT.ToString();
                }
                worksheet.Cell(i, 10).Value = p.RAISONDERETRAIT;
                worksheet.Cell(i, 11).Value = p.RESPONSABLE;
                worksheet.Cell(i, 12).Value = p.NOTE;
                worksheet.Cell(i, 2).Style.Font.FontColor = XLColor.Black;
                worksheet.Cell(i, 3).Style.Font.FontColor = XLColor.Black;
                worksheet.Cell(i, 4).Style.Font.FontColor = XLColor.Black;
                worksheet.Cell(i, 5).Style.Font.FontColor = XLColor.Black;
                worksheet.Cell(i, 6).Style.Font.FontColor = XLColor.Black;
                worksheet.Cell(i, 7).Style.Font.FontColor = XLColor.Black;
                worksheet.Cell(i, 9).Style.Font.FontColor = XLColor.Black;
                worksheet.Cell(i, 10).Style.Font.FontColor = XLColor.Black;
                worksheet.Cell(i, 11).Style.Font.FontColor = XLColor.Black;
                worksheet.Cell(i, 12).Style.Font.FontColor = XLColor.Black;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx;*.xlsm",
                Title = "Save Excel File"
            };
            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;
                workbook.SaveAs(filePath);
                MessageBox.Show("Excel file created successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            }
        }
    }
}
