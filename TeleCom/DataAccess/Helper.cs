namespace TeleCom.DataAccess
{
    public static class Helper
    {
        private const string Cs =
            @"Data Source=DRAYV-NOTEBOOK\SQLEXPRESS; Initial Catalog=TeleCom; Integrated Security=SSPI;";

        public static string GetConnectionString()
        {
            return Cs;
        }
    }
}