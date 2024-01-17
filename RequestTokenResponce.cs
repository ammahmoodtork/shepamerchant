using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShepaMerchant
{
    public class RequestTokenResponce
    {
        public bool success { get; set; }
        public string[] error { get; set; }
        public Token result { get; set; }
    }
}
