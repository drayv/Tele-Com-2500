using System;

namespace TeleCom.Core
{
    public class Rate : Entity<int>
    {
        public decimal Amount { get; set; }
        public int Service { get; set; }
        public DateTime StartDate { get; set; }
    }
}