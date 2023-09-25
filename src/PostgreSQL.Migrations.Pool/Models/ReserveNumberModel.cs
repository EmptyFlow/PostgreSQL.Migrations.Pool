namespace PostgreSQL.Migrations.Pool.Models {

    /// <summary>
    /// Reserve number model.
    /// </summary>
    public record ReserveNumberModel {

        public int? MigrationNumber { get; init; }

        public int ReleaseId { get; set; }

        public string Comment { get; init; } = "";

        public NumberStrategy NumberStrategy { get; init; } = NumberStrategy.LastNumber;

    }

}
