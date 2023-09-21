using Microsoft.AspNetCore.Mvc;

namespace PostgreSQL.Migrations.Pool.Attributes {

    public class JsonInAttribute : ConsumesAttribute {

        public JsonInAttribute () : base ( "application/json" ) {
        }

    }

}
