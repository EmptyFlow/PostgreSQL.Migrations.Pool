namespace PostgreSQL.Migrations.Pool.Models {
    
    /// <summary>
    /// Number strategy.
    /// </summary>
    public enum NumberStrategy {

        Unknown = 0,

        /// <summary>
        /// Take plus one from the maximum number.
        /// </summary>
        LastNumber = 1,

        /// <summary>
        /// Take any from not reserved.
        /// </summary>
        AnyFree = 2,

        /// <summary>
        /// Timestamp become part of number.
        /// </summary>
        TimeStampNumber = 3,

    };

}