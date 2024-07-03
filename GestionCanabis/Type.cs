using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCanabis
{
    public class Type
    {
        public Type(string dESCRIPTION, string aBBREV)
        {
            DESCRIPTION = dESCRIPTION;
            ABBREV = aBBREV;
        }

        public string DESCRIPTION
        {
            get;set;
        }
        public string ABBREV
        {
            get;set;
        }
    }
}
