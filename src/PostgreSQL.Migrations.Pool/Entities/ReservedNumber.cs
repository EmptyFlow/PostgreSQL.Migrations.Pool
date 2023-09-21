
namespace PostgreSQL.Migrations.Pool.Entities {

    /// <summary>
    /// Reserved number.
    /// </summary>
    public class ReservedNumber {

        /// <summary>
        /// Number.
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// User identifier.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Comment.
        /// </summary>
        public string Comment { get; set; } = "";

    }

}
