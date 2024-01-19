using System.ComponentModel;

namespace PostgreSQL.Migrations.Pool.Data.Migrations {

    [Description ( "Create tables: user and reservednumber" )]
    public class Migration1 {

        public static int MigrationNumber => 1;

        public static string Issue => "https://github.com/EmptyFlow/PostgreSQL.Migrations/issues/1";

        public string Down () {
            return """
DROP TABLE reservednumber;
DROP TABLE pooluser;
""";
        }

        public string Up () {
            return """
CREATE TABLE pooluser(
    id SERIAL PRIMARY KEY,
    name text NOT NULL,
    displayName text NOT NULL,
    password text NOT NULL,
    email text NOT NULL
);
CREATE TABLE reservednumber(
    number int4 UNIQUE PRIMARY KEY,
    userid int4 NOT NULL,
    comment text NOT NULL,
    CONSTRAINT fk_reservednumber_user FOREIGN KEY (userid) REFERENCES pooluser(id)
);
""";
        }

    }

}
