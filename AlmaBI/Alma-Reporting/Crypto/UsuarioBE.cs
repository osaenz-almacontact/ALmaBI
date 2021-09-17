using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alma_Reporting.Crypto
{
    public class UsuarioBE
    {
        public string Usuario { get; set; }
        public byte[] Password { get; set; }
        public byte[] Salt { get; set; }
        public UsuarioBE()
        {

        }
    }
}