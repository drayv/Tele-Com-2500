using System;

namespace TeleCom.Core
{
    public class Rate : Entity<int>
    {
        public decimal Amount { get; set; }
        public Service Service { get; set; }
        public DateTime StartDate { get; set; }
    }
}