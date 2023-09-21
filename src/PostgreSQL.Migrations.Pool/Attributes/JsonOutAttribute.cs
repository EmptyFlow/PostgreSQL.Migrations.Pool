using Microsoft.AspNetCore.Mvc;

namespace PostgreSQL.Migrations.Pool.Attributes {

    public class JsonOutAttribute : ProducesAttribute {

        public JsonOutAttribute () : base ( "application/json" ) {
        }

    }

}
