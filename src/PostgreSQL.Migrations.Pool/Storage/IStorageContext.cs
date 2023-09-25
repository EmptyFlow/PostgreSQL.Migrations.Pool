﻿using SqlKata;

namespace PostgreSQL.Migrations.Pool.Storage {

    /// <summary>
    /// Storage context.
    /// </summary>
    public interface IStorageContext {

        /// <summary>
        /// Add or update item declared in generic type.
        /// </summary>
        /// <param name="item">Item for saving process.</param>
        public Task AddOrUpdate<T> ( T item );

        /// <summary>
        /// Add or update items declared in generic type.
        /// </summary>
        /// <param name="item">Item collection for saving process.</param>
        public Task MultiAddOrUpdate<T> ( IEnumerable<T> items );

        /// <summary>
        /// Get items from database.
        /// </summary>
        /// <typeparam name="T">Type of return model.</typeparam>
        /// <param name="query">Query.</param>
        /// <returns>Collection of items.</returns>
        public Task<IEnumerable<T>> GetAsync<T> ( Query query ) where T : new();

        /// <summary>
        /// Get single item from database.
        /// </summary>
        /// <typeparam name="T">Type of return model.</typeparam>
        /// <param name="query">Query.</param>
        /// <returns>Collection of items.</returns>
        public Task<T> GetSingleAsync<T> ( Query query ) where T : new();

        /// <summary>
        /// Get items from database.
        /// </summary>
        /// <typeparam name="T">Type of return model.</typeparam>
        /// <param name="query">Query.</param>
        /// <returns>Collection of items.</returns>
        public IEnumerable<T> Get<T> ( Query query ) where T : new();

        /// <summary>
        /// Make a request without result.
        /// </summary>
        /// <param name="query">Query.</param>
        public Task MakeNoResult<T> ( Query query ) where T : new();

        /// <summary>
        /// Make queries containing in `action` in single transaction.
        /// </summary>
        /// <param name="action">Action for transaction.</param>
        public Task MakeInTransaction ( Func<Task> action );

    }

}
