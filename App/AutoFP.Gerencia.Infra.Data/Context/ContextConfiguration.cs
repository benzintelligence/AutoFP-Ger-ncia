using System.Data.Entity.Migrations;

namespace AutoFP.Gerencia.Infra.Data.Context
{
    internal sealed class Configuration : DbMigrationsConfiguration<AutoFpContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    }
}