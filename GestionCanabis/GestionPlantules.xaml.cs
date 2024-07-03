using IronBarCode;
using Aspose.Pdf;
using Aspose.Words;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
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
using System.Windows.Xps.Packaging;
using Aspose.Words.Pdf2Word.FixedFormats;
using System.Printing;
using System.Windows.Xps;
using Aspose.Pdf.Text;
using Microsoft.Win32;

namespace GestionCanabis
{
    /// <summary>
    /// Interaction logic for GestionPlantules.xaml
    /// </summary>
    public partial class GestionPlantules : System.Windows.Controls.Page
    {
        DBConnect db;
        List<Plante> listp,checkedplants;
        List<String> responsables, entreposages;
        List<Type> listt;
        Plante temp;
        private MainPanel Parent;
        public GestionPlantules(MainPanel parent)
        {
            Parent = parent;
            db = new DBConnect();
            checkedplants = new List<Plante>();
            listp = db.listp("SELECT * FROM PLANTULE");
            listt = db.listtype("SELECT * FROM TYPE");
            InitializeComponent();
            responsables = db.GetEnumValues("RESPONSABLE");
            entreposages = db.entreposages();
            ENTREPOSAGE.ItemsSource = entreposages;
            RESPONSABLE.ItemsSource = responsables;
            TYPE.ItemsSource = listt;
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
            DataGridP.ItemsSource = listp;
        }

        private void AjouterButton_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Ajout");
            if (ETATDESANTE.SelectedValue != null && RESPONSABLE.SelectedValue != null && STADE.SelectedValue != null && DATEENTREE.SelectedDate.HasValue && DESCRIPTION.Document != new FlowDocument() && TYPE.SelectedValue != null && ENTREPOSAGE.SelectedValue != null && ACTIVITE.SelectedValue != null && PROVENANCE.Text != "" && TYPE.Text != "")
            {
                string ID=(string) TYPE.SelectedValue;
                int counter=1;
                foreach(Plante pl in listp)
                {
                    if (pl.ID.Contains(ID))
                    {
                        counter++;
                    }
                }
                ID=ID+(""+counter);
                if(DATERETRAIT.SelectedDate.HasValue)
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
                            Plante PP = new Plante(ETATDESANTE.Text, DATEENTREE.SelectedDate.Value, ID, PROVENANCE.Text, new TextRange(DESCRIPTION.Document.ContentStart, DESCRIPTION.Document.ContentEnd).Text.Trim(), STADE.Text, ENTREPOSAGE.Text, false, DATERETRAIT.SelectedDate.Value, RAISONRETRAIT.Text, RESPONSABLE.Text, NOTE.Text);
                            int boolvalue = 0;
                            if (PP.ACTIVITE)
                            {
                                boolvalue = 1;
                            }
                            db.NRQ("INSERT INTO PLANTULE values ('"+PP.ETATDESANTE+"','"+ PP.DATEENTREE.Date.Year + "-" + PP.DATEENTREE.Month + "-" + PP.DATEENTREE.Day + "','"+PP.ID+"','"+PP.PROVENANCE+"','"+PP.DESCRIPTION+"','"+PP.STADE+"','"+PP.ENTREPOSAGE+"',"+boolvalue+",'"+PP.DATERETRAIT.Date.Year+"-"+PP.DATERETRAIT.Date.Month+"-"+PP.DATERETRAIT.Date.Day + "','"+PP.RAISONDERETRAIT+"','"+PP.RESPONSABLE+"','"+PP.NOTE+"')");
                            db.NRQ("INSERT INTO HISTORIQUE (CHANGEMENT,TS) VALUES('Plante "+PP.ID+" Ajoutée par "+Parent.user()+" ',NOW())");
                            string pdfPath = "QR\\" + ID + ".pdf";
                            QRCodeLogo logo = new QRCodeLogo("logo.png");
                            var qrCode = QRCodeWriter.CreateQrCodeWithLogo(ID, logo, 300);
                            qrCode.SaveAsPdf(pdfPath);
                            MessageBox.Show("Ajout Terminé");
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
                            TYPE.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Date Retrait Choisie -- Mais Aucune Raison de Retrait");
                    }
                }
                else
                {
                    Plante PP = new Plante(ETATDESANTE.Text, DATEENTREE.SelectedDate.Value, ID, PROVENANCE.Text, new TextRange(DESCRIPTION.Document.ContentStart, DESCRIPTION.Document.ContentEnd).Text.Trim(), STADE.Text, ENTREPOSAGE.Text, ACTIVITE.Text.Equals("Actif"), new DateTime(), RAISONRETRAIT.Text, RESPONSABLE.Text, NOTE.Text);
                    int boolvalue = 0;
                    if (PP.ACTIVITE)
                    {
                        boolvalue = 1;
                    }
                    db.NRQ("INSERT INTO PLANTULE values ('" + PP.ETATDESANTE + "','" + PP.DATEENTREE.Date.Year + "-" + PP.DATEENTREE.Month + "-" + PP.DATEENTREE.Day + "','" + PP.ID + "','" + PP.PROVENANCE + "','" + PP.DESCRIPTION + "','" + PP.STADE + "','" + PP.ENTREPOSAGE + "',"+boolvalue+"," + "null"+ "," + "null"+ ",'" + PP.RESPONSABLE + "'," + "null" + ")");
                    db.NRQ("INSERT INTO HISTORIQUE (CHANGEMENT,TS) VALUES('Plante "+PP.ID+" Ajoutée par "+Parent.user()+" ',NOW())");
                    string pdfPath = "QR\\" + ID + ".pdf";
                    string pngPath = "QR\\" + ID + ".png";
                    QRCodeLogo logo = new QRCodeLogo("logo.png");
                    var qrCode = QRCodeWriter.CreateQrCodeWithLogo(ID, logo, 300);
                    qrCode.SaveAsPdf(pdfPath);
                    qrCode.SaveAsPng(pngPath);
                    MessageBox.Show("Ajout Terminée");
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
                    TYPE.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Champs Incomplets!");
            }
            listp = db.listp("SELECT * FROM PLANTULE");
            DataGridP.ItemsSource = null;
            DataGridP.ItemsSource = listp;
        }

        private void ModifierButton_Click(object sender, RoutedEventArgs e)
        {
            if(ETATDESANTE.SelectedValue!=null && RESPONSABLE.SelectedValue != null && STADE.SelectedValue != null && DATEENTREE.SelectedDate.HasValue && DESCRIPTION.Document!= new FlowDocument() && ENTREPOSAGE.SelectedValue!=null && ACTIVITE.SelectedValue!=null && PROVENANCE.Text!="")
            {
                if (DATERETRAIT.SelectedDate.HasValue)
                {
                    if(RAISONRETRAIT.SelectedValue!=null)
                    {
                        if(RAISONRETRAIT.SelectedValue=="AUTRE" && NOTE.Text == "")
                        {
                            MessageBox.Show("Raison de Retrait Choisie: Autre -- Mais Note Vide!");
                        }
                        else
                        {
                            ACTIVITE.SelectedValue = "Inactif";
                            Plante PP = new Plante(ETATDESANTE.Text,DATEENTREE.SelectedDate.Value,temp.ID,PROVENANCE.Text,new TextRange(DESCRIPTION.Document.ContentStart,DESCRIPTION.Document.ContentEnd).Text.Trim(),STADE.Text,ENTREPOSAGE.Text,false,DATERETRAIT.SelectedDate.Value,RAISONRETRAIT.Text,RESPONSABLE.Text,NOTE.Text);
                            string Changement = temp.Changement(PP,Parent.user());
                            db.NRQ("UPDATE PLANTULE SET ETATDESANTE='"+PP.ETATDESANTE+"' , DATEENTREE='"+ PP.DATEENTREE.Date.Year + "-" + PP.DATEENTREE.Month + "-" + PP.DATEENTREE.Day + "' , PROVENANCE='"+PP.PROVENANCE+"', DESCRIPTION='"+PP.DESCRIPTION+"' , STADE='"+PP.STADE+"' , ENTREPOSAGE='"+PP.ENTREPOSAGE+"' , DATERETRAIT='"+ PP.DATERETRAIT.Date.Year + "-" + PP.DATERETRAIT.Date.Month + "-" + PP.DATERETRAIT.Date.Day + "' , RAISONRETRAIT='"+PP.RAISONDERETRAIT+"' , NOTE='"+PP.NOTE+"' , ACTIVITE=0,RESPONSABLE='"+PP.RESPONSABLE+"' WHERE ID='"+PP.ID+"'");
                            if (Changement != "Plante " + PP.ID + "\nChangement de \n" + "\n\n\n***FIN DU CHANGEMENT***")
                            {
                                db.NRQ("INSERT INTO HISTORIQUE (CHANGEMENT,TS) VALUES('" + Changement + "',NOW())");
                            }
                            MessageBox.Show("Modification Terminée");
                            ETATDESANTE.Text = "";
                            DATEENTREE.SelectedDate=null ;
                            PROVENANCE.Text = "";
                            DESCRIPTION.Document = new FlowDocument();
                            STADE.Text = "";
                            ENTREPOSAGE.Text = "";
                            ACTIVITE.Text = "";
                            DATERETRAIT.SelectedDate = null;
                            RAISONRETRAIT.Text = "";
                            NOTE.Text = "";
                            RESPONSABLE.Text = "";
                            TYPE.IsEnabled = true;
                            TYPE.Text = "";
                            boutonmodification.IsEnabled = false;
                            annulermodification.IsEnabled = false;
                            boutonajout.IsEnabled = true;
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
                    string CHangement = temp.Changement(PP,Parent.user());
                    Boolean b = PP.ACTIVITE.Equals("Actif");
                    db.NRQ("UPDATE PLANTULE SET ETATDESANTE='" + PP.ETATDESANTE + "' , DATEENTREE='" + PP.DATEENTREE.Date.Year+"-"+PP.DATEENTREE.Month+"-"+PP.DATEENTREE.Day + "' , PROVENANCE='" + PP.PROVENANCE + "', DESCRIPTION='" + PP.DESCRIPTION + "' , STADE='" + PP.STADE + "' , ENTREPOSAGE='" + PP.ENTREPOSAGE + "' , RESPONSABLE='" + PP.RESPONSABLE+ "' , ACTIVITE=1 WHERE ID='" + PP.ID + "'");
                    if (CHangement != "Plante "+PP.ID+"\nChangement de \n"+"\n\n\n***FIN DU CHANGEMENT***")
                    {
                        db.NRQ("INSERT INTO HISTORIQUE (CHANGEMENT,TS) VALUES('" + CHangement + "',NOW())");
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
                    TYPE.IsEnabled = true;
                    TYPE.Text = "";
                    boutonmodification.IsEnabled = false;
                    annulermodification.IsEnabled = false;
                    boutonajout.IsEnabled = true;
                }
            }
            else
            {
                MessageBox.Show("Champs Incomplets!");
            }
            listp = db.listp("SELECT * FROM PLANTULE");
            DataGridP.ItemsSource = null;
            DataGridP.ItemsSource = listp;
        }


        private void btnmodifier_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var rowdata = (string)button.Tag;
            string id = rowdata;
            Plante ptemp = null;
            foreach(Plante p in listp)
            {
                if (p.ID == id)
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
                boutonajout.IsEnabled = false;
                temp = ptemp;
                TYPE.IsEnabled = false;
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
            TYPE.IsEnabled = true;
            TYPE.Text = "";
            boutonmodification.IsEnabled = false;
            annulermodification.IsEnabled = false;
            boutonajout.IsEnabled = true;
        }

        private void QRPRINTER_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var rowdata = (string)button.Tag;
            string id = rowdata;
            string pdfPath = "QR\\" + id + ".pdf";
            var Document = new Aspose.Words.Document(pdfPath);
            string xpsPath = "GeneratedQRCode.xps";
            Document.Save(xpsPath);
            PrintXPS(xpsPath);
            File.Delete(xpsPath);
        }

        private void btnsupprimer_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Êtes Vous Sur de Vouloir Supprimer?", "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                var button = sender as Button;
                var rowdata = (string)button.Tag;
                string id = rowdata;
                db.NRQ("DELETE FROM PLANTULE WHERE ID='" + id + "'");
                db.NRQ("INSERT INTO HISTORIQUE (CHANGEMENT,TS) VALUES('PLANTE "+id+" SUPPRIMEE par "+Parent.user()+"',NOW())");
                listp = db.listp("SELECT * FROM PLANTULE");
                DataGridP.ItemsSource = null;
                DataGridP.ItemsSource = listp;

            }
        }

        private void btnannulerretrait_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Êtes Vous Sur de Vouloir Annuler le retrait de cette plante?", "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                var button = sender as Button;
                var rowdata = (string)button.Tag;
                string id = rowdata;
                db.NRQ("UPDATE PLANTULE SET ACTIVITE=1 ,                     DATERETRAIT=null,RAISONRETRAIT=null,NOTE=null where ID='"+id+"'");
                db.NRQ("INSERT INTO HISTORIQUE(CHANGEMENT,TS) VALUES('RETRAIT ANNULÉ POUR LA PLANTE "+id+" par "+Parent.user()+" ',NOW())");
                listp = db.listp("SELECT * FROM PLANTULE");
                DataGridP.ItemsSource = null;
                DataGridP.ItemsSource = listp;
            }
        }

        private void View_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var rowdata = (string)button.Tag;
            string id = rowdata;
            string pngFilePath = "\\QR\\"+id+".png";
            PDFViewerWindow pdfViewerWindow = new PDFViewerWindow(this, (Environment.CurrentDirectory+pngFilePath).Replace("\\","/"));
            Parent.deactivation();
            pdfViewerWindow.Show();
        }

        public void PDFVIEWERCLOSED()
        {
            Parent.activation();
        }

        private void btnhistorique_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var rowdata = (string)button.Tag;
            string id = rowdata;
            foreach (Button b in Parent.listb)
            {
                b.Background = System.Windows.Media.Brushes.Black;
            }
            Parent.btnHistorique.Background = System.Windows.Media.Brushes.White;
            Parent.ContentPage.Content = new Historique(id);
            
        }

        private void btnexport_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var rowdata = (string)button.Tag;
            string id = rowdata;
            Plante pp = new Plante(null, new DateTime(), null, null, null, null, null, false, new DateTime(), null, null, null);
            foreach (Plante p in listp)
            {
                if (p.ID == id)
                {
                    pp = p;
                }
            }
            Aspose.Pdf.Document pdfDocument = new Aspose.Pdf.Document();
            Aspose.Pdf.Page page = pdfDocument.Pages.Add();
            TextFragment textfr = new TextFragment("Plante " + pp.ID);
            textfr.TextState.FontSize = 12;
            textfr.TextState.Font = FontRepository.FindFont("Arial");
            textfr.TextState.HorizontalAlignment = Aspose.Pdf.HorizontalAlignment.Center;
            page.Paragraphs.Add(textfr);
            Aspose.Pdf.Image image = new Aspose.Pdf.Image();
            string imageFilePath = Environment.CurrentDirectory+"\\QR\\" + id + ".png";
            image.File = imageFilePath;
            image.FixHeight = 200;
            image.FixWidth = 200;
            image.HorizontalAlignment = Aspose.Pdf.HorizontalAlignment.Center;
            image.VerticalAlignment = Aspose.Pdf.VerticalAlignment.Center;
            page.Paragraphs.Add(image);
            if (pp.ACTIVITE)
            {
                textfr = new TextFragment("Etat de Sante : " + pp.ETATDESANTE + "\nDate Entree : " + pp.DE + "\nProvenance : " + pp.PROVENANCE + "\nDescription : " + pp.DESCRIPTION + "\nStade : " + pp.STADE + "\nEntreposage : " + pp.ENTREPOSAGE + "\nActivité : " + pp.AC + "\nResponsable : " + pp.RESPONSABLE);
                textfr.TextState.FontSize = 12;
                textfr.TextState.Font = FontRepository.FindFont("Arial");
                textfr.TextState.HorizontalAlignment = Aspose.Pdf.HorizontalAlignment.Center;
            }
            else
            {
                textfr = new TextFragment("Etat de Sante : " + pp.ETATDESANTE + "\nDate Entree : " + pp.DE + "\nProvenance : " + pp.PROVENANCE + "\nDescription : " + pp.DESCRIPTION + "\nStade : " + pp.STADE + "\nEntreposage : " + pp.ENTREPOSAGE + "\nActivité : " + pp.AC + "\nResponsable : " + pp.RESPONSABLE + "\nDate de Retrait : " + pp.DR + "\nRaison de Retrait : " + pp.RAISONDERETRAIT + "\nNote : " + pp.NOTE);
                textfr.TextState.FontSize = 12;
                textfr.TextState.Font = FontRepository.FindFont("Arial");
                textfr.TextState.HorizontalAlignment = Aspose.Pdf.HorizontalAlignment.Center;
            }
            page.Paragraphs.Add(textfr);
            List<HistoriqueP> listhtemp = db.listh("SELECT * from HISTORIQUE WHERE CHANGEMENT LIKE'%"+id+"%'");
            Aspose.Pdf.Page page2 = pdfDocument.Pages.Add();
            page2.Paragraphs.Add(new TextFragment("Historique de La Plante\n"));
            foreach (HistoriqueP hist in listhtemp)
            {
                textfr = new TextFragment(hist.TS.ToString()+"\n" + hist.CHANGEMENT+"\n");
                textfr.TextState.FontSize = 12;
                textfr.TextState.Font = FontRepository.FindFont("Arial");
                textfr.TextState.HorizontalAlignment = Aspose.Pdf.HorizontalAlignment.Center;
                page2.Paragraphs.Add(textfr);
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF files (*.pdf)|*.pdf",
                Title = "Save PDF File"
            };
            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;
                pdfDocument.Save(filePath);

                MessageBox.Show("PDF file created successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            }
        }

        private void RedoQR_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var rowdata = (string)button.Tag;
            string ID = rowdata;
            string pdfPath = "QR\\" + ID + ".pdf";
            string pngPath = "QR\\" + ID + ".png";
            QRCodeLogo logo = new QRCodeLogo("logo.png");
            var qrCode = QRCodeWriter.CreateQrCodeWithLogo(ID, logo, 300);
            qrCode.SaveAsPdf(pdfPath);
            qrCode.SaveAsPng(pngPath);
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            var button = sender as CheckBox;
            var rowdata = (string)button.Tag;
            string id = rowdata;
            foreach (Plante pppp in listp)
            {
                if (pppp.ID == id)
                {
                    checkedplants.Add(pppp);
                }
            }
            boutonexportation.IsEnabled = true;
            boutonreparationqr.IsEnabled = true;
            boutonimpression.IsEnabled = true;
        }

        private void boutonexportation_Click(object sender, RoutedEventArgs e)
        {
            prbar.Maximum = checkedplants.Count;
            foreach(Plante ppp in checkedplants)
            {
                Aspose.Pdf.Document pdfDocument = new Aspose.Pdf.Document();
                Aspose.Pdf.Page page = pdfDocument.Pages.Add();
                TextFragment textfr = new TextFragment("Plante " + ppp.ID);
                textfr.TextState.FontSize = 12;
                textfr.TextState.Font = FontRepository.FindFont("Arial");
                textfr.TextState.HorizontalAlignment = Aspose.Pdf.HorizontalAlignment.Center;
                page.Paragraphs.Add(textfr);
                Aspose.Pdf.Image image = new Aspose.Pdf.Image();
                string imageFilePath = Environment.CurrentDirectory + "\\QR\\" + ppp.ID + ".png";
                image.File = imageFilePath;
                image.FixHeight = 200;
                image.FixWidth = 200;
                image.HorizontalAlignment = Aspose.Pdf.HorizontalAlignment.Center;
                image.VerticalAlignment = Aspose.Pdf.VerticalAlignment.Center;
                page.Paragraphs.Add(image);
                if (ppp.ACTIVITE)
                {
                    textfr = new TextFragment("Etat de Sante : " + ppp.ETATDESANTE + "\nDate Entree : " + ppp.DE + "\nProvenance : " + ppp.PROVENANCE + "\nDescription : " + ppp.DESCRIPTION + "\nStade : " + ppp.STADE + "\nEntreposage : " + ppp.ENTREPOSAGE + "\nActivité : " + ppp.AC + "\nResponsable : " + ppp.RESPONSABLE);
                    textfr.TextState.FontSize = 12;
                    textfr.TextState.Font = FontRepository.FindFont("Arial");
                    textfr.TextState.HorizontalAlignment = Aspose.Pdf.HorizontalAlignment.Center;
                }
                else
                {
                    textfr = new TextFragment("Etat de Sante : " + ppp.ETATDESANTE + "\nDate Entree : " + ppp.DE + "\nProvenance : " + ppp.PROVENANCE + "\nDescription : " + ppp.DESCRIPTION + "\nStade : " + ppp.STADE + "\nEntreposage : " + ppp.ENTREPOSAGE + "\nActivité : " + ppp.AC + "\nResponsable : " + ppp.RESPONSABLE + "\nDate de Retrait : " + ppp.DR + "\nRaison de Retrait : " + ppp.RAISONDERETRAIT + "\nNote : " + ppp.NOTE);
                    textfr.TextState.FontSize = 12;
                    textfr.TextState.Font = FontRepository.FindFont("Arial");
                    textfr.TextState.HorizontalAlignment = Aspose.Pdf.HorizontalAlignment.Center;
                }
                page.Paragraphs.Add(textfr);
                List<HistoriqueP> listhtemp = db.listh("SELECT * from HISTORIQUE WHERE CHANGEMENT LIKE'%" + ppp.ID + "%'");
                Aspose.Pdf.Page page2 = pdfDocument.Pages.Add();
                page2.Paragraphs.Add(new TextFragment("Historique de La Plante\n"));
                foreach (HistoriqueP hist in listhtemp)
                {
                    textfr = new TextFragment(hist.TS.ToString() + "\n" + hist.CHANGEMENT + "\n");
                    textfr.TextState.FontSize = 12;
                    textfr.TextState.Font = FontRepository.FindFont("Arial");
                    textfr.TextState.HorizontalAlignment = Aspose.Pdf.HorizontalAlignment.Center;
                    page2.Paragraphs.Add(textfr);
                }
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "PDF files (*.pdf)|*.pdf",
                    Title = "Save PDF File"
                };
                if (saveFileDialog.ShowDialog() == true)
                {
                    string filePath = saveFileDialog.FileName;
                    pdfDocument.Save(filePath);
                }
                ppp.rowchecked = false;
                prbar.Value++;
            }
            checkedplants.Clear();
            boutonexportation.IsEnabled = false;
            boutonreparationqr.IsEnabled = false;
            boutonimpression.IsEnabled = false;
        }

        private void boutonreparationqr_Click(object sender, RoutedEventArgs e)
        {
            prbar.Maximum = checkedplants.Count;
            foreach (Plante ppp in checkedplants)
            {
                string pdfPath = "QR\\" + ppp.ID + ".pdf";
                string pngPath = "QR\\" + ppp.ID + ".png";
                QRCodeLogo logo = new QRCodeLogo("logo.png");
                var qrCode = QRCodeWriter.CreateQrCodeWithLogo(ppp.ID, logo, 300);
                qrCode.SaveAsPdf(pdfPath);
                qrCode.SaveAsPng(pngPath);
                ppp.rowchecked = false;
                prbar.Value++;
            }
            checkedplants.Clear();
            boutonexportation.IsEnabled = false;
            boutonreparationqr.IsEnabled = false;
            boutonimpression.IsEnabled = false;
        }

        private void annulerimpression_Click(object sender, RoutedEventArgs e)
        {
            prbar.Maximum = checkedplants.Count;
            foreach(Plante ppp in checkedplants)
            {
                string pdfPath = "QR\\" + ppp.ID + ".pdf";
                var Document = new Aspose.Words.Document(pdfPath);
                string xpsPath = "GeneratedQRCode.xps";
                Document.Save(xpsPath);
                PrintXPS(xpsPath);
                File.Delete(xpsPath);
                ppp.rowchecked = false;
                prbar.Value++;
            }
            checkedplants.Clear();
            boutonexportation.IsEnabled = false;
            boutonreparationqr.IsEnabled = false;
            boutonimpression.IsEnabled = false;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            var button = sender as CheckBox;
            var rowdata = (string)button.Tag;
            string id = rowdata;
            foreach (Plante pppp in listp)
            {
                if (pppp.ID == id)
                {
                    checkedplants.Remove(pppp);
                }
            }
            if (checkedplants.Count == 0)
            {
                boutonexportation.IsEnabled = false;
                boutonreparationqr.IsEnabled = false;
                boutonimpression.IsEnabled = false;
            }
        }

        public void PrintXPS(string filePath)
        {
            try
            {
                using (XpsDocument xpsDocument = new XpsDocument(filePath, FileAccess.Read))
                {
                    PrintQueue printQueue = LocalPrintServer.GetDefaultPrintQueue();

                    PrintTicket printTicket = printQueue.DefaultPrintTicket;

                    FixedDocumentSequence fixedDocSeq = xpsDocument.GetFixedDocumentSequence();

                    PrintDocumentImageableArea ia = null;
                    XpsDocumentWriter writer = PrintQueue.CreateXpsDocumentWriter(ref ia);
                    try
                    {
                        writer.Write(fixedDocSeq, printTicket);
                    }catch(NullReferenceException exc)
                    {

                    }
                   

                    MessageBox.Show("Document Envoyé à l'Imprimante.", "Printing", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
            }
        }

    }
}
