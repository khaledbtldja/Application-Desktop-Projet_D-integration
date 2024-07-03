using IronBarCode;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Printing;
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
using System.Windows.Xps.Packaging;
using System.Windows.Xps;
using Google.Protobuf.WellKnownTypes;
using DocumentFormat.OpenXml.Office2010.Excel;

namespace GestionCanabis
{
    /// <summary>
    /// Interaction logic for DataImport.xaml
    /// </summary>
    public partial class DataImport : Window
    {
        DBConnect db;
        List<String> responsables, entreposages;
        Plante temp;
        private Importation parent;
        private List<Plante> list;
        private bool crazy = true;
        public DataImport(Importation Parent,List<Plante> list)
        {
            parent = Parent;
            this.list = list;
            InitializeComponent();
            db = new DBConnect();
            responsables = db.GetEnumValues("RESPONSABLE");
            entreposages = db.entreposages();
            ENTREPOSAGE.ItemsSource = entreposages;
            RESPONSABLE.ItemsSource = responsables;
            STADE.Items.Add("INITIATION");
            STADE.Items.Add("MICRO DISSECTION");
            STADE.Items.Add("MAGENTA");
            STADE.Items.Add("DOUBLE MAGENTA");
            STADE.Items.Add("HYDROPONIE");
            ETATDESANTE.Items.Add("BONNE SANTE");
            ETATDESANTE.Items.Add("SANTE MOYENNE");
            ETATDESANTE.Items.Add("MAUVAISE SANTE");
            ETATDESANTE.Items.Add("PLANTE EN DANGER");
            ACTIVITE.Items.Add("Actif");
            ACTIVITE.Items.Add("Inactif");
            RAISONRETRAIT.Items.Add("DESTRUCTION PAR AUTOCLAVE");
            RAISONRETRAIT.Items.Add("TRANSFERT CLIENT");
            RAISONRETRAIT.Items.Add("TRANSFERT AUTRE CENTRE");
            RAISONRETRAIT.Items.Add("TRANSFERT POUR ANALYSE");
            RAISONRETRAIT.Items.Add("ANALYSE");
            RAISONRETRAIT.Items.Add("CONTAMINATION");
            RAISONRETRAIT.Items.Add("LIMITATION DE LICENCE");
            RAISONRETRAIT.Items.Add("PERTE DE L ECHANTILLON");
            RAISONRETRAIT.Items.Add("PLANTULES N ONT PAS SURVECU A L EXPERIENCE");
            RAISONRETRAIT.Items.Add("AUTRE");
            DataGridP.ItemsSource = null;
            DataGridP.ItemsSource = list;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            parent.activation();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton== MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        
        private void ModifierButton_Click(object sender, RoutedEventArgs e)
        {
            if (ETATDESANTE.SelectedValue != null && RESPONSABLE.SelectedValue != null && STADE.SelectedValue != null && DATEENTREE.SelectedDate.HasValue && DESCRIPTION.Document != new FlowDocument() && ENTREPOSAGE.SelectedValue != null && ACTIVITE.SelectedValue != null && PROVENANCE.Text != "")
            {
                if (DATERETRAIT.SelectedDate.HasValue)
                {
                    if (RAISONRETRAIT.SelectedValue != null)
                    {
                        if (RAISONRETRAIT.SelectedValue == "AUTRE" && NOTE.Text == "")
                        {
                            MessageBox.Show("Raison de Retrait Choisie: Autre -- Mais Note Vide!");
                        }
                        else
                        {
                            ACTIVITE.SelectedValue = "Inactif";
                            Plante PP = new Plante(ETATDESANTE.Text, DATEENTREE.SelectedDate.Value, temp.ID, PROVENANCE.Text, new TextRange(DESCRIPTION.Document.ContentStart, DESCRIPTION.Document.ContentEnd).Text.Trim(), STADE.Text, ENTREPOSAGE.Text, false, DATERETRAIT.SelectedDate.Value, RAISONRETRAIT.Text, RESPONSABLE.Text, NOTE.Text);
                            foreach (Plante PPL in list)
                            {
                                if (PPL.Rownumber == temp.Rownumber)
                                {
                                    PPL.ETATDESANTE = PP.ETATDESANTE;
                                    PPL.DATEENTREE = PP.DATEENTREE;
                                    PPL.ID = PP.ID;
                                    PPL.PROVENANCE = PP.PROVENANCE;
                                    PPL.DESCRIPTION = PP.DESCRIPTION;
                                    PPL.STADE = PP.STADE;
                                    PPL.ENTREPOSAGE = PP.ENTREPOSAGE;
                                    PPL.ACTIVITE = PP.ACTIVITE;
                                    PPL.DATERETRAIT = PP.DATERETRAIT;
                                    PPL.RAISONDERETRAIT = PP.RAISONDERETRAIT;
                                    PPL.RESPONSABLE = PP.RESPONSABLE;
                                    PPL.NOTE = PP.NOTE;
                                }
                            }
                            MessageBox.Show("Modification Terminée");
                            ETATDESANTE.Text = "";
                            DATEENTREE.SelectedDate = null;
                            PROVENANCE.Text = "";
                            DESCRIPTION.Document = new FlowDocument();
                            STADE.Text = "";
                            ENTREPOSAGE.Text = "";
                            ACTIVITE.Text = "";
                            DATERETRAIT.SelectedDate = null;
                            RAISONRETRAIT.Text = "";
                            NOTE.Text = "";
                            RESPONSABLE.Text = "";
                            boutonmodification.IsEnabled = false;
                            annulermodification.IsEnabled = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Date Retrait Choisie -- Mais Aucune Raison de Retrait");
                    }
                }
                else
                {
                    Plante PP = new Plante(ETATDESANTE.Text, DATEENTREE.SelectedDate.Value, temp.ID, PROVENANCE.Text, new TextRange(DESCRIPTION.Document.ContentStart, DESCRIPTION.Document.ContentEnd).Text.Trim(), STADE.Text, ENTREPOSAGE.Text, ACTIVITE.Text.Equals("Actif"), new DateTime(), null, RESPONSABLE.Text, null);
                    foreach (Plante PPL in list)
                    {
                        if (PPL.Rownumber == temp.Rownumber)
                        {
                            PPL.ETATDESANTE = PP.ETATDESANTE;
                            PPL.DATEENTREE = PP.DATEENTREE;
                            PPL.ID = PP.ID;
                            PPL.PROVENANCE = PP.PROVENANCE;
                            PPL.DESCRIPTION = PP.DESCRIPTION;
                            PPL.STADE = PP.STADE;
                            PPL.ENTREPOSAGE = PP.ENTREPOSAGE;
                            PPL.ACTIVITE = PP.ACTIVITE;
                            PPL.DATERETRAIT = PP.DATERETRAIT;
                            PPL.RAISONDERETRAIT = PP.RAISONDERETRAIT;
                            PPL.RESPONSABLE=PP.RESPONSABLE;
                            PPL.NOTE = PP.NOTE;
                        }
                    }
                    MessageBox.Show("Modification Terminée");
                    ETATDESANTE.Text = "";
                    DATEENTREE.SelectedDate = null;
                    PROVENANCE.Text = "";
                    DESCRIPTION.Document = new FlowDocument();
                    STADE.Text = "";
                    ENTREPOSAGE.Text = "";
                    ACTIVITE.Text = "";
                    DATERETRAIT.SelectedDate = null;
                    RAISONRETRAIT.Text = "";
                    NOTE.Text = "";
                    RESPONSABLE.Text = "";
                    boutonmodification.IsEnabled = false;
                    annulermodification.IsEnabled = false;
                }
            }
            else
            {
                MessageBox.Show("Champs Incomplets!");
            }
            DataGridP.ItemsSource = null;
            DataGridP.ItemsSource = list;
        }


        private void btnmodifier_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var rowdata = (int)button.Tag;
            int id = rowdata;
            Plante ptemp = null;
            foreach (Plante p in list)
            {
                if (p.Rownumber == id)
                {
                    ptemp = p;
                }
            }
            if (ptemp != null)
            {
                ETATDESANTE.SelectedValue = ptemp.ETATDESANTE;
                DATEENTREE.SelectedDate = ptemp.DATEENTREE.Date;
                DESCRIPTION.Document = new FlowDocument(new System.Windows.Documents.Paragraph(new System.Windows.Documents.Run(ptemp.DESCRIPTION)));
                STADE.SelectedValue = ptemp.STADE;
                PROVENANCE.Text = ptemp.PROVENANCE;
                ENTREPOSAGE.SelectedValue = ptemp.ENTREPOSAGE;
                if (ptemp.ACTIVITE)
                {
                    ACTIVITE.SelectedValue = "Actif";
                }
                else
                {
                    ACTIVITE.SelectedValue = "Inactif";
                }
                RESPONSABLE.SelectedValue = ptemp.RESPONSABLE;
                if (ptemp.DATERETRAIT != new DateTime())
                {
                    DATERETRAIT.SelectedDate = ptemp.DATERETRAIT.Date;
                }
                if (ptemp.RAISONDERETRAIT != null)
                {
                    RAISONRETRAIT.SelectedValue = ptemp.RAISONDERETRAIT;
                }
                if (ptemp.NOTE != null)
                {
                    NOTE.Text = ptemp.NOTE;
                }
                boutonmodification.IsEnabled = true;
                annulermodification.IsEnabled = true;
                temp = ptemp;
            }
        }

        private void annulermodification_Click(object sender, RoutedEventArgs e)
        {
            ETATDESANTE.Text = "";
            DATEENTREE.SelectedDate = null;
            PROVENANCE.Text = "";
            DESCRIPTION.Document = new FlowDocument();
            STADE.Text = "";
            ENTREPOSAGE.Text = "";
            ACTIVITE.Text = "";
            DATERETRAIT.SelectedDate = null;
            RAISONRETRAIT.Text = "";
            NOTE.Text = "";
            RESPONSABLE.Text = "";
            boutonmodification.IsEnabled = false;
            annulermodification.IsEnabled = false;
        }

        

        private void btnsupprimer_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Êtes Vous Sur de Vouloir Supprimer?", "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                var button = sender as Button;
                
                var rowdata = (int)button.Tag;
                int id = rowdata;
                for(int i = id + 1; i < list.Count; i++)
                {
                    list[i].Rownumber--;
                }
                list.RemoveAt(id);
                DataGridP.ItemsSource = null;
                DataGridP.Items.Clear();
                DataGridP.ItemsSource = list;

            }
        }

        private void importation_Click(object sender, RoutedEventArgs e)
        {
            bool checker=true;
            foreach(Plante ppp in list)
            {
                ppp.importverification();
                if (!ppp.verified)
                {
                    checker = false;
                }
            }
            if (checker)
            {
                progressbar.Maximum = list.Count;
                foreach (Plante PP in list)
                {
                    if (PP.DATERETRAIT != new DateTime())
                    {
                        try
                        {
                            int boolvalue = 0;
                            if (PP.ACTIVITE)
                            {
                                boolvalue = 1;
                            }
                            db.NRQ("INSERT INTO PLANTULE values ('" + PP.ETATDESANTE + "','" + PP.DATEENTREE.Date.Year + "-" + PP.DATEENTREE.Month + "-" + PP.DATEENTREE.Day + "','" + PP.ID + "','" + PP.PROVENANCE + "','" + PP.DESCRIPTION + "','" + PP.STADE + "','" + PP.ENTREPOSAGE + "'," + boolvalue + ",'" + PP.DATERETRAIT.Date.Year + "-" + PP.DATERETRAIT.Date.Month + "-" + PP.DATERETRAIT.Date.Day + "','" + PP.RAISONDERETRAIT + "','" + PP.RESPONSABLE + "','" + PP.NOTE + "')");
                            db.NRQ("INSERT INTO HISTORIQUE (CHANGEMENT,TS) VALUES('Plante " + PP.ID + " Ajoutée par " + parent.parent.user() + " ',NOW())");
                            string pdfPath = "QR\\" + PP.ID + ".pdf";
                            string pngPath = "QR\\" + PP.ID + ".png";
                            QRCodeLogo logo = new QRCodeLogo("logo.png");
                            var qrCode = QRCodeWriter.CreateQrCodeWithLogo(PP.ID, logo, 300);
                            qrCode.SaveAsPdf(pdfPath);
                            qrCode.SaveAsPng(pngPath);
                        }
                        catch (Exception exce)
                        {

                        }
                    }
                    else
                    {
                        try
                        {
                            int boolvalue = 0;
                            if (PP.ACTIVITE)
                            {
                                boolvalue = 1;
                            }
                            db.NRQ("INSERT INTO PLANTULE values ('" + PP.ETATDESANTE + "','" + PP.DATEENTREE.Date.Year + "-" + PP.DATEENTREE.Month + "-" + PP.DATEENTREE.Day + "','" + PP.ID + "','" + PP.PROVENANCE + "','" + PP.DESCRIPTION + "','" + PP.STADE + "','" + PP.ENTREPOSAGE + "'," + boolvalue + "," + "null" + "," + "null" + ",'" + PP.RESPONSABLE + "'," + "null" + ")");
                            db.NRQ("INSERT INTO HISTORIQUE (CHANGEMENT,TS) VALUES('Plante " + PP.ID + " Ajoutée par " + parent.parent.user() + " ',NOW())");
                            string pdfPath = "QR\\" + PP.ID + ".pdf";
                            string pngPath = "QR\\" + PP.ID + ".png";
                            QRCodeLogo logo = new QRCodeLogo("logo.png");
                            var qrCode = QRCodeWriter.CreateQrCodeWithLogo(PP.ID, logo, 300);
                            qrCode.SaveAsPdf(pdfPath);
                            qrCode.SaveAsPng(pngPath);
                        }
                        catch (Exception exce)
                        {

                        }
                    }
                    progressbar.Value++;
                }
                MessageBox.Show("Importation Terminée");
                this.Close();
            }
            else
            {
                DataGridP.ItemsSource = null;
                DataGridP.ItemsSource = list;
                MessageBox.Show("Il y a des champs manquants");
            }
        }

        private void btnannulerretrait_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Êtes Vous Sur de Vouloir Annuler le retrait de cette plante?", "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                var button = sender as Button;
                var rowdata = (int)button.Tag;
                int id = rowdata;
                foreach (Plante PPL in list)
                {
                    if (PPL.Rownumber == id)
                    {
                        PPL.ACTIVITE = true;
                        PPL.DATERETRAIT = new DateTime();
                        PPL.RAISONDERETRAIT = null;
                        PPL.NOTE = null;
                    }
                }
                DataGridP.ItemsSource = null;
                DataGridP.ItemsSource = list;
            }
        }



        
    }
}
