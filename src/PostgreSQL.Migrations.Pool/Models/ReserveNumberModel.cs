namespace PostgreSQL.Migrations.Pool.Models {

    /// <summary>
    /// Reserve number model.
    /// </summary>
    public record ReserveNumberModel {

        public int? MigrationNumber { get; init; }

        public string Comment { get; init; } = "";

    }

}
