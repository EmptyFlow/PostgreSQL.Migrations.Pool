using PostgreSQL.Migrations.Client;
using System.ComponentModel;

namespace PostgreSQL.Migrations.Pool.Data.Migrations {

    [MigrationNumber ( 2, "https://github.com/EmptyFlow/PostgreSQL.Migrations/issues/1" )]
    [Description ( "Create table release" )]
    public class AddReleaseTable : MigrationScript {

        public override string Down () {
            return """
ALTER TABLE reservednumber DROP COLUMN releaseid;
DROP TABLE release;
""";
        }

        public override string Up () {
            return """
CREATE TABLE release(
    id SERIAL PRIMARY KEY,
    name text NOT NULL,
    locked bool NOT NULL DEFAULT false
);
ALTER TABLE reservednumber ADD COLUMN releaseid int4 NOT NULL;
ALTER TABLE reservednumber ADD CONSTRAINT fk_reservednumber_release FOREIGN KEY (releaseid) REFERENCES release(id);
""";
    }

    }

}
