using PostgreSQL.Migrations.Pool.Services;

namespace PostgreSQL.Migrations.Pool {

    /// <summary>
    /// Resolve dependencies.
    /// </summary>
    public static class Dependencies {

        public static void Resolve ( IServiceCollection collection ) {
            collection.AddTransient<IConfigurationService, ConfigurationService> ();
            collection.AddTransient<IReserveNumberService, ReserveNumberService> ();
        }

    }

}
