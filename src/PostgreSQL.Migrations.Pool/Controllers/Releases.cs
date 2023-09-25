using Microsoft.AspNetCore.Mvc;
using PostgreSQL.Migrations.Pool.Attributes;
using PostgreSQL.Migrations.Pool.Entities;
using PostgreSQL.Migrations.Pool.Models;
using PostgreSQL.Migrations.Pool.Storage;
using SqlKata;

namespace PostgreSQL.Migrations.Pool.Controllers {

    [ApiController, JsonIn, JsonOut, Route ( "/api/releases" )]
    public class Releases {

        private readonly IStorageContext m_storageContext;

        public Releases ( IStorageContext storageContext ) => m_storageContext = storageContext ?? throw new ArgumentNullException ( nameof ( storageContext ) );

        [HttpPost ( "create" )]
        public async Task CreateRelease ( [FromBody, RequiredParameter] ReleaseModel model ) {
            var release = new Release {
                Name = model.Name,
                Locked = false
            };

            await m_storageContext.AddOrUpdate ( release );
        }

        [HttpPut ( "update/{id}" )]
        public async Task UpdateRelease ( [FromRoute, RequiredParameter] int id, [FromBody, RequiredParameter] ReleaseModel model ) {
            await m_storageContext.MakeNoResult<Release> (
                new Query ().Where ( "id", id ).AsUpdate ( new { name = model.Name } )
            );
        }

    }

}
