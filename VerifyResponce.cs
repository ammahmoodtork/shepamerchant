using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShepaMerchant
{
    public class VerifyResponce
    {
        public bool success { get; set; }
        public string[] error { get; set; }
        public Verify result { get; set; }
    }
}
