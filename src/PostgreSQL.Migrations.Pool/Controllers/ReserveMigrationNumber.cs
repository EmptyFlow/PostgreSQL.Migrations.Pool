using Microsoft.AspNetCore.Mvc;
using PostgreSQL.Migrations.Pool.Attributes;
using PostgreSQL.Migrations.Pool.Entities;
using PostgreSQL.Migrations.Pool.Models;
using PostgreSQL.Migrations.Pool.Storage;
using SqlKata;

namespace PostgreSQL.Migrations.Pool.Controllers {

    /// <summary>
    /// Reserve migration number.
    /// </summary>
    [ApiController, JsonIn, JsonOut, Route ( "/api/reservation" )]
    public class ReserveMigrationNumber {

        private readonly IStorageContext m_storageContext;

        public ReserveMigrationNumber ( IStorageContext storageContext ) => m_storageContext = storageContext;

        [HttpPost ( "reservenumber" )]
        public Task ReserveNumber ( [FromBody, RequiredParameter] ReserveNumberModel model ) {
            if ( model == null ) throw new ArgumentNullException ( nameof ( model ) );

            return m_storageContext.MakeInTransaction (
                async () => {
                    int migrationNumber;
                    if ( model.MigrationNumber.HasValue ) {
                        var numberItems = await m_storageContext.GetAsync<int> (
                            new Query ( "reservednumber" )
                                .Where ( "number", model.MigrationNumber.Value )
                                .OrderByDesc ( "number" )
                        );
                        if ( numberItems.Any () ) throw new ArgumentException ( $"Number {numberItems} already reserved!" );
                        migrationNumber = model.MigrationNumber.Value;
                    } else {
                        var lastNumberItems = await m_storageContext.GetAsync<int> (
                            new Query ( "reservednumber" )
                                .OrderByDesc ( "number" )
                                .Limit ( 1 )
                                .Select ( "number" )
                        );
                        migrationNumber = lastNumberItems.Any () ? lastNumberItems.First () + 1 : 1;
                    }
                    var reserverNumber = new ReservedNumber {
                        Number = migrationNumber,
                        UserId = 0,
                        Comment = model.Comment
                    };

                    await m_storageContext.AddOrUpdate ( reserverNumber );
                }
            );
        }

    }

}
