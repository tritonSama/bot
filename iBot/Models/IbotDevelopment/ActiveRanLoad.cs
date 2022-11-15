using MessagePack;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace iBot.Models.IbotDevelopment
{
    
    public partial class ActiveRanLoad
    {
        
        public string? Ran { get; set; }
        public string? Customer { get; set; }
        public string? TechPoc { get; set; }
        public string? WbsElement { get; set; }
        public string? Fund { get; set; }
        public bool Labor { get; set; }
        public bool Travel { get; set; }
        public bool Procurement { get; set; }
        public string? Active { get; set; }
        public string? Projectcode { get; set; }
    }
}
