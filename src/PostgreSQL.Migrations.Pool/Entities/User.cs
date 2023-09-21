namespace PostgreSQL.Migrations.Pool.Entities {

    /// <summary>
    /// User.
    /// </summary>
    public class User {

        /// <summary>
        /// Identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// User login.
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// Display name.
        /// </summary>
        public string DisplayName { get; set; } = "";

        /// <summary>
        /// Password.
        /// </summary>
        public string Password { get; set; } = "";

        /// <summary>
        /// Email.
        /// </summary>
        public string Email { get; set; } = "";

    }

}
