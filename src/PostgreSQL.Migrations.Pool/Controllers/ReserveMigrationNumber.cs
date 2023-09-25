using Microsoft.AspNetCore.Mvc;
using PostgreSQL.Migrations.Pool.Attributes;
using PostgreSQL.Migrations.Pool.Entities;
using PostgreSQL.Migrations.Pool.Models;
using PostgreSQL.Migrations.Pool.Services;
using PostgreSQL.Migrations.Pool.Storage;
using SqlKata;

namespace PostgreSQL.Migrations.Pool.Controllers {

    /// <summary>
    /// Reserve migration number.
    /// </summary>
    [ApiController, JsonIn, JsonOut, Route ( "/api/reservation" )]
    public class ReserveMigrationNumber {

        private readonly IStorageContext m_storageContext;

        private readonly IReserveNumberService m_reserveNumberService;

        public ReserveMigrationNumber ( IStorageContext storageContext, IReserveNumberService reserveNumberService ) {
            m_storageContext = storageContext ?? throw new ArgumentNullException ( nameof ( storageContext ) );
            m_reserveNumberService = reserveNumberService ?? throw new ArgumentNullException ( nameof ( reserveNumberService ) );
        }

        [HttpPost ( "reservenumber" )]
        public Task ReserveNumber ( [FromBody, RequiredParameter] ReserveNumberModel model ) {
            if ( model == null ) throw new ArgumentNullException ( nameof ( model ) );

            return m_storageContext.MakeInTransaction (
                async () => {
                    int migrationNumber;
                    if ( model.MigrationNumber.HasValue ) {
                        if ( !await m_reserveNumberService.CheckNumberIsFree ( model.MigrationNumber.Value ) ) throw new ArgumentException ( $"Number {model.MigrationNumber.Value} already reserved!" );
                        migrationNumber = model.MigrationNumber.Value;
                    } else {
                        migrationNumber = await m_reserveNumberService.GetNewNumber ( model.NumberStrategy );
                    }
                    var reserverNumber = new ReservedNumber {
                        Number = migrationNumber,
                        UserId = 0,
                        ReleaseId = model.ReleaseId,
                        Comment = model.Comment
                    };

                    await m_storageContext.AddOrUpdate ( reserverNumber );
                }
            );
        }

        [HttpDelete ( "cancelreservation" )]
        public Task CancelReservation ( [FromQuery, RequiredParameter] int migrationNumber ) {
            if ( migrationNumber < 1 ) throw new ArgumentOutOfRangeException ( nameof ( migrationNumber ) );

            return m_storageContext.MakeNoResult<ReservedNumber> (
                new Query ()
                    .Where ( "number", migrationNumber )
                    .AsDelete ()
            );
        }

    }

}
