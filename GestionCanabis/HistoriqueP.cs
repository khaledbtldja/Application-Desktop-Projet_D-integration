using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCanabis
{
    public class HistoriqueP
    {
        public HistoriqueP(string cHANGEMENT, DateTime tIMESTAMP)
        {
            CHANGEMENT = cHANGEMENT;
            TS = tIMESTAMP;
        }
        public string CHANGEMENT
        {
            get;
            set;
        }
        public DateTime TS
        {
            get;
            set;
        }
        public string text()
        {
            return (TS+"\n"+CHANGEMENT);
        }
    }
}
