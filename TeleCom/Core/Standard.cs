namespace TeleCom.Core
{
    public class Standard : Entity<int>
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public Service Service { get; set; }
    }
}