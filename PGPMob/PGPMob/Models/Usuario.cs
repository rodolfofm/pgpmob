using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGPMob.Models
{
    public class Usuario
    {
        public int UCIDUSER { get; set; }
        public string UCUSERNAME { get; set; }
        public string UCLOGIN { get; set; }
        public string UCPASSWORD { get; set; }
        public string UCEMAIL { get; set; }
        public int UCPRIVILEGED { get; set; }
        public string UCTYPEREC { get; set; }
        public int UCPROFILE { get; set; }
        public string UCKEY { get; set; }
        public int FUN_CODIGO { get; set; }
    }
}
