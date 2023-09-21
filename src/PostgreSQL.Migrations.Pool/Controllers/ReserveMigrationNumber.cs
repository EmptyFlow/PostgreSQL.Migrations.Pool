using Microsoft.AspNetCore.Mvc;
using PostgreSQL.Migrations.Pool.Attributes;

namespace PostgreSQL.Migrations.Pool.Controllers {

    /// <summary>
    /// Reserve migration number.
    /// </summary>
    [ApiController, JsonIn, JsonOut, Route ( "/api/reservation" )]
    public class ReserveMigrationNumber {



    }

}
