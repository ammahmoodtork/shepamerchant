using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShepaMerchant
{
    public class Verify
    {
        public DateTime date { get; set; }
        public string refid { get; set; }
        public string card_pan { get; set; }
        public Int64 amount { get; set; }
        public Int64 transaction_id { get; set; }
        public bool isDuplicate { get; set; }
    }
}
