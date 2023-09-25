using PostgreSQL.Migrations.Pool.Attributes;

namespace PostgreSQL.Migrations.Pool.Entities {

    [TableName("release")]
    public class Release {

        public int Id { get; init; }

        public string Name { get; init; } = "";

        public bool Locked { get; init; }

    }

}
