using Microsoft.AspNetCore.Mvc;
using PostgreSQL.Migrations.Pool.Attributes;
using PostgreSQL.Migrations.Pool.Entities;
using PostgreSQL.Migrations.Pool.Models;

namespace PostgreSQL.Migrations.Pool.Controllers {

    /// <summary>
    /// Reserve migration number.
    /// </summary>
    [ApiController, JsonIn, JsonOut, Route ( "/api/reservation" )]
    public class ReserveMigrationNumber {

        [HttpPost("reservenumber")]
        public Task ReserveNumber ( [FromBody, RequiredParameter] ReserveNumberModel model ) {
            return Task.CompletedTask;
        }

    }

}
