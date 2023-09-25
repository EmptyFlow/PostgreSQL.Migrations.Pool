namespace PostgreSQL.Migrations.Pool.Services {

    /// <summary>
    /// Configuration service.
    /// </summary>
    public interface IConfigurationService {

        /// <summary>
        /// Database connection string.
        /// </summary>
        string DatabaseConnectionString ();

    }

}
