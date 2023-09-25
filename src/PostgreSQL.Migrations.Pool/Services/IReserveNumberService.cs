using PostgreSQL.Migrations.Pool.Models;

namespace PostgreSQL.Migrations.Pool.Services {

    /// <summary>
    /// Service for take new migration number from free number range.
    /// </summary>
    public interface IReserveNumberService {

        /// <summary>
        /// Check number if free.
        /// </summary>
        /// <param name="number">Number for check.</param>
        /// <returns>Number is free or not.</returns>
        Task<bool> CheckNumberIsFree ( int number );

        /// <summary>
        /// Get new number.
        /// </summary>
        /// <param name="numberStrategy">Number strategy.</param>
        /// <returns>New free number.</returns>
        Task<int> GetNewNumber ( NumberStrategy numberStrategy );

    }

}
