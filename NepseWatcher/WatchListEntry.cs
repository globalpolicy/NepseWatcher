using System;
using System.Collections.Generic;
using System.Text;

namespace NepseWatcher
{
    
    public class WatchListEntry
    {
        public string Symbol { get; set; }
        public string FullName { get; set; }
        public string Sector { get; set; }
        public DateTime EntryDate { get; set; }
        public float EntryPrice { get; set; }
        public int Quantity { get; set; }
    }
}
