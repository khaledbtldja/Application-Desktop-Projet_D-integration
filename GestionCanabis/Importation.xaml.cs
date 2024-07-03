using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office2013.Word;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for Importation.xaml
    /// </summary>
    public partial class Importation : System.Windows.Controls.Page
    {
        public MainPanel parent;
        private List<Plante> list;
        public Importation(MainPanel parent)
        {
            this.parent = parent;
            InitializeComponent();
        }
        private void browse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel Files|*.xls;*.xlsx;*.xlsm",
                Title = "Select an Excel File"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                nom.IsReadOnly = false;
                nom.Text = openFileDialog.FileName;
                nom.IsReadOnly = true;
                PopulateSheetNames(nom.Text);
                sheetcombobox.Visibility = Visibility.Visible;
                sheetlabel.Visibility = Visibility.Visible;
            }
        }

        private void Import_Click(object sender, RoutedEventArgs e)
        {
            List<Type> temp = new DBConnect().listtype("SELECT * FROM TYPE");
            List<Plante> temp2 = new DBConnect().listp("SELECT * from PLANTULE");
            List<Entreposage> temp3 = new DBConnect().liste("SELECT * FROM ENTREPOSAGE");
            List<string> temp4 = new DBConnect().GetEnumValues("RESPONSABLE");
            if (nom.Text!="")
            {
                List<Plante> listimportation = new List<Plante>();
                try
                {
                    using (var workbook = new XLWorkbook(nom.Text))
                    {
                        var worksheet = workbook.Worksheet(sheetcombobox.Text);
                        bool firstRow = true;
                        int counter = -1;

                        foreach (var row in worksheet.RowsUsed())
                        {
                            int idcounter = 1;
                            if (firstRow)
                            {
                                firstRow = false;
                            }
                            else
                            {
                                counter++;
                                string id = "";
                                foreach(Type ty in temp)
                                {
                                    if(ty.DESCRIPTION== row.Cell(5).GetString().Trim())
                                    {
                                        id = id + ty.ABBREV;
                                    }
                                }
                                foreach(Plante pppp in temp2 )
                                {
                                    if (pppp.ID.Contains(id))
                                    {
                                        idcounter++;
                                    }
                                }
                                foreach (Plante pppp in listimportation)
                                {
                                    if (pppp.ID.Contains(id))
                                    {
                                        idcounter++;
                                    }
                                }
                                string raisonderetrait = "", etatdesante="", stade="", responsable="", entreposage="";
                                if (row.Cell(1).GetString().Replace('é', 'e').ToUpper()== "BONNE SANTE"|| row.Cell(1).GetString().Replace('é', 'e').ToUpper() == "PLANTE EN DANGER"|| row.Cell(1).GetString().Replace('é', 'e').ToUpper() == "SANTE MOYENNE"|| row.Cell(1).GetString().Replace('é', 'e').ToUpper() == "MAUVAISE SANTE")
                                {
                                    etatdesante = row.Cell(1).GetString().Replace('é', 'e').ToUpper();
                                }
                                if (row.Cell(6).GetString().ToUpper() == "INITIATION" || row.Cell(6).GetString().ToUpper() == "MICRO DISSECTION" || row.Cell(6).GetString().ToUpper() == "HYDROPONIE" || row.Cell(6).GetString().ToUpper() == "MAGENTA" || row.Cell(6).GetString().ToUpper() == "DOUBLE MAGENTA")
                                {
                                    stade = row.Cell(6).GetString().ToUpper();
                                }
                                foreach(Entreposage en in temp3)
                                {
                                    if(row.Cell(7).GetString().ToUpper().Trim() == en.ID )
                                    {
                                        entreposage = en.ID;
                                    }
                                }
                                foreach(string stri in temp4)
                                {
                                    if(row.Cell(11).GetString().ToUpper().Trim() == stri)
                                    {
                                        responsable = stri;
                                    }
                                }
                                if(row.Cell(10).GetString().ToUpper().Trim() == "DESTRUCTION PAR AUTOCLAVE" || row.Cell(10).GetString().ToUpper().Trim() == "TRANSFERT CLIENT" || row.Cell(10).GetString().ToUpper().Trim() == "TRANSFERT AUTRE CENTRE" || row.Cell(10).GetString().ToUpper().Trim() == "TRANSFERT POUR ANALYSE" || row.Cell(10).GetString().ToUpper().Trim() == "ANALYSE" || row.Cell(10).GetString().ToUpper().Trim() == "CONTAMINATION" || row.Cell(10).GetString().ToUpper().Trim() == "LIMITATION DE LICENCE" || row.Cell(10).GetString().ToUpper().Trim() == "PERTE DE L ECHANTILLON" || row.Cell(10).GetString().ToUpper().Trim() == "PLANTULES N ONT PAS SURVECU A L EXPERIENCE" || row.Cell(10).GetString().ToUpper().Trim() == "AUTRE" )
                                {
                                        raisonderetrait = row.Cell(10).GetString().ToUpper().Trim();
                                }
                                id = id + idcounter;
                                DateTime de, dr;
                                de = dateextractor(row.Cell(2).GetString());
                                dr = dateextractor(row.Cell(9).GetString());
                                bool activite =!( row.Cell(12).GetString().ToLower().Equals("inactif") || dr!=new DateTime());
                                Plante p;
                                if (dr!=new DateTime())
                                {
                                    p = new Plante(etatdesante, de, id, row.Cell(4).GetString(), row.Cell(5).GetString(), stade, entreposage, activite, dr, raisonderetrait, responsable, row.Cell(12).GetString());

                                }
                                else
                                {
                                    p = new Plante(etatdesante, de, id, row.Cell(4).GetString(), row.Cell(5).GetString(), stade, entreposage, activite, new DateTime(), null, responsable, null);

                                }
                                p.Rownumber = counter;
                                p.datesetter();
                                if (p.ID != ""+idcounter)
                                {
                                    listimportation.Add(p);
                                }

                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error reading Excel file: " + ex.Message);
                    MessageBox.Show(ex.StackTrace);
                }
                DataImport di = new DataImport(this, listimportation);
                di.Show();
                deactivation();
            }
            else
            {
                MessageBox.Show("Aucun Fichier Choisi");
            }
        }
        private DateTime dateextractor (string s)
        {
            if (s.Trim() != "")
            {
                string ch;
                if (s.Contains("/"))
                {
                    ch = "/";
                }
                else
                {
                    ch = "-";
                }
                List<string> liststr = new List<string>();
                DateTime test = new DateTime();
                try
                {
                    liststr.AddRange((s.Substring(0, s.Length - 8).TrimEnd()).Split(" ")[0].Split(ch));
                    test = new DateTime(int.Parse(liststr[0]), int.Parse(liststr[1]), int.Parse(liststr[2]));
                }
                catch(Exception exc)
                {
                    return test;
                }
                return test;
            }
            else
            {
                return new DateTime();
            }
        }
        private void PopulateSheetNames(string filePath)
        {
            try
            {
                using (var workbook = new XLWorkbook(filePath))
                {
                    sheetcombobox.Items.Clear();
                    foreach (var worksheet in workbook.Worksheets)
                    {
                        sheetcombobox.Items.Add(worksheet.Name);
                    }

                    if (sheetcombobox.Items.Count > 0)
                    {
                        sheetcombobox.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading Excel file: " + ex.Message);
            }
        }
        public void activation()
        {
            parent.activation();
        }
        public void deactivation()
        {
            parent.deactivation();
        }
    }
}
