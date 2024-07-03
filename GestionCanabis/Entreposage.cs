using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCanabis
{
    public class Entreposage
    {
        public Entreposage(string ID,string Description)
        {
            this.ID = ID;
            this.Description = Description;
        }
        public string ID
        {
            get;set;
        }
        public string Description
        {
            get;set;
        }
    }
}
