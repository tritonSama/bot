using MessagePack;
using System;
using System.Collections.Generic;

namespace iBot.Models.IbotDevelopment
{
    public partial class AdmActiveDocumentsDefault
    {
        
        public string DocumentNum { get; set; }
        public string? Vendor { get; set; }
        public string? EndDate { get; set; }
    }
}
