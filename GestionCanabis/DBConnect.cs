using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Collections.ObjectModel;

namespace GestionCanabis
{
    public class DBConnect
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public DBConnect()
        {
            Initialize();
        }

        public MySqlConnection Connection { get => connection; set => connection = value; }

        //Initialize values
        private void Initialize()
        {
            server = "mysql-ea2707-mohamedtaleb123456-9c14.aivencloud.com";
            database = "gestioncanabis";
            uid = "avnadmin";
            password = "AVNS_crD7FiLrzkR1SAFLsIq";
            var connString = "Server=" + server + ";User ID=" + uid + ";Password=" + password + ";Database=" + database+";Port=14499;SSL Mode=Required;";
            

            Connection = new MySqlConnection(connString);
        }
#pragma warning disable IDE0051 // Remove unused private members
        
        public void NRQ(string query)
        {
            Connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            Connection.Close();
            
        }

        public  int Count(string query)
        {
            int Count = -1;
            Connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            Count = int.Parse(cmd.ExecuteScalar() + "");
            Connection.Close();
            return Count;
            
        }
        public List<Plante> listp(string query)
        {
            Connection.Open();
            List<Plante> listp = new List<Plante>();
            Plante d ;
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader =  cmd.ExecuteReader();
            while ( dataReader.Read())
            {
                d = new Plante(null, new DateTime(), null, null, null, null, null, false, new DateTime(), null, null, null);
                d.ETATDESANTE = dataReader.GetString("ETATDESANTE");
                d.DATEENTREE = dataReader.GetDateTime("DATEENTREE");
                d.ID = dataReader.GetString("ID");
                d.PROVENANCE = dataReader.GetString("PROVENANCE");
                d.DESCRIPTION = dataReader.GetString("DESCRIPTION");
                d.STADE = dataReader.GetString("STADE");
                d.ENTREPOSAGE = dataReader.GetString("ENTREPOSAGE");
                d.ACTIVITE = dataReader.GetBoolean("ACTIVITE");
                d.RESPONSABLE = dataReader.GetString("RESPONSABLE");
                try
                {
                    d.DATERETRAIT = dataReader.GetDateTime("DATERETRAIT");
                    d.RAISONDERETRAIT = dataReader.GetString("RAISONRETRAIT");
                    d.NOTE = dataReader.GetString("NOTE");
                }catch(Exception exc)
                {

                }
                d.datesetter();
                listp.Add(d);
            }
            dataReader.Close();
            Connection.Close();
            return listp;
        }
        public List<string> entreposages()
        {
            Connection.Open();
            List<string> list = new List<string>();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM ENTREPOSAGE", connection);
            MySqlDataReader d = cmd.ExecuteReader();
            while (d.Read())
            {
                list.Add(d.GetString("ID"));
            }
            d.Close();
            Connection.Close();
            return list;
        }
        public List<HistoriqueP> listh(string query)
        {
            Connection.Open();
            List<HistoriqueP> listp = new List<HistoriqueP>();
            HistoriqueP d = new HistoriqueP(null, new DateTime());
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                d = new HistoriqueP(null, new DateTime());
                d.TS = dataReader.GetDateTime("TS");
                d.CHANGEMENT = dataReader.GetString("CHANGEMENT");
                listp.Add(d);
            }
            dataReader.Close();
            Connection.Close();
            return listp;
        }
        public List<Utilisateur> listu(string query)
        {
            Connection.Open();
            List<Utilisateur> listp = new List<Utilisateur>();
            Utilisateur d = new Utilisateur(null, null,null,null,null,null);
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                d = new Utilisateur(null, null, null, null, null, null);
                d.username = dataReader.GetString("USERNAME");
                d.password = dataReader.GetString("PASSWORD");
                d.nom = dataReader.GetString("NOM");
                d.prenom = dataReader.GetString("PRENOM");
                d.adresse = dataReader.GetString("ADRESSE");
                d.telephone = dataReader.GetString("TELEPHONE");
                listp.Add(d);
            }
            dataReader.Close();
            Connection.Close();
            return listp;
        }
        public List<Entreposage> liste(string query)
        {
            Connection.Open();
            List<Entreposage> listp = new List<Entreposage>();
            Entreposage d = new Entreposage(null, null);
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                d = new Entreposage(null, null);
                d.ID = dataReader.GetString("ID");
                d.Description = dataReader.GetString("DESCRIPTION");
                listp.Add(d);
            }
            dataReader.Close();
            Connection.Close();
            return listp;
        }
        public bool login(string query)
        {
            Connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.Read())
            {
                Connection.Close();
                return true;
            }
            else
            {
                Connection.Close();
                return false;
            }
            
        }
        public List<string> GetEnumValues(string enumColumnName)
        {
            List<string> enumValues = new List<string>();

            Connection.Open();

                string query = $@"
                SELECT COLUMN_TYPE 
                FROM information_schema.COLUMNS 
                WHERE TABLE_NAME = 'PLANTULE' 
                  AND COLUMN_NAME = '{enumColumnName}' 
                  AND TABLE_SCHEMA = 'gestioncanabis';";

                MySqlCommand cmd = new MySqlCommand(query, connection);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string columnType = reader.GetString("COLUMN_TYPE");
                        enumValues = ParseEnumValues(columnType);
                    }
                }
            Connection.Close();
            return enumValues;
        }

        static List<string> ParseEnumValues(string columnType)
        {
            List<string> values = new List<string>();

            if (columnType.StartsWith("enum('") && columnType.EndsWith("')"))
            {
                string valuesString = columnType.Substring(6, columnType.Length - 8);
                values.AddRange(valuesString.Split("','"));
            }

            return values;
        }
        public bool pwdcheck(string query)
        {
            Connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.Read())
            {
                Connection.Close();
                return true;
            }
            else
            {
                Connection.Close();
                return false;
            }
        }
        public List<Type> listtype(string query)
        {
            Connection.Open();
            List<Type> listp = new List<Type>();
            Type d = new Type(null, null);
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                d = new Type(null, null);
                d.DESCRIPTION = dataReader.GetString("DESCRIPTION");
                d.ABBREV = dataReader.GetString("ABBREV");
                listp.Add(d);
            }
            dataReader.Close();
            Connection.Close();
            return listp;
        }
    }
}
