namespace TeleCom.Core
{
    public class Service : Entity<int>
    {
        public string Name { get; set; }
        public decimal CurAmount { get; set; }
    }
}