using PostgreSQL.Migrations.Client;
using System.ComponentModel;

namespace PostgreSQL.Migrations.Pool.Data.Migrations {

    [MigrationNumber ( 1, "https://github.com/EmptyFlow/PostgreSQL.Migrations/issues/1" )]
    [Description ( "Create tables: user and reservednumber" )]
    public class Migration1 : MigrationScript {

        public override string Down () {
            return """
DROP TABLE reservednumber;
DROP TABLE user;
""";
        }

        public override string Up () {
            return """
CREATE TABLE user(
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
    FOREIGN KEY (userid) REFERENCES user(id),
    ADD CONSTRAINT fk_reservednumber_user FOREIGN KEY (userid) REFERENCES user(id)
);
""";
        }

    }

}
