using PostgreSQL.Migrations.Pool.Models;
using PostgreSQL.Migrations.Pool.Storage;
using SqlKata;

namespace PostgreSQL.Migrations.Pool.Services {

    public class ReserveNumberService : IReserveNumberService {

        private readonly IStorageContext m_storageContext;

        public ReserveNumberService ( IStorageContext storageContext ) => m_storageContext = storageContext;

        public async Task<int> GetNewNumber ( NumberStrategy numberStrategy ) {
            switch ( numberStrategy ) {
                case NumberStrategy.LastNumber: return await GetLastNumber ();
                case NumberStrategy.AnyFree: return await GetAnyFree ();
                case NumberStrategy.TimeStampNumber: return await GetTimeStampNumber ();
                default: throw new NotSupportedException ();
            }
        }

        private async Task<int> GetLastNumber () {
            var lastNumberItems = await m_storageContext.GetAsync<int> (
                new Query ( "reservednumber" )
                    .OrderByDesc ( "number" )
                    .Limit ( 1 )
                    .Select ( "number" )
            );
            return lastNumberItems.Any () ? lastNumberItems.First () + 1 : 1;
        }

        private async Task<int> GetAnyFree () {
            var numbers = await m_storageContext.GetAsync<int> (
                new Query ( "reservednumber" )
                    .OrderBy ( "number" )
                    .Select ( "number" )
            );
            if ( !numbers.Any () ) return 1;

            var previousNumber = numbers.First ();
            var freeNumber = -1;
            foreach ( var number in numbers ) {
                if ( previousNumber - number > 1 ) {
                    freeNumber = previousNumber + 1;
                    break;
                }
            }
            return freeNumber;
        }

        private async Task<int> GetTimeStampNumber () {
            var now = DateTime.UtcNow;
            var numbers = Enumerable
                .Repeat ( 1, 1000 ) // 1000 migrations per day is enough? at least that's what I think :)
                .Select ( ( a, index ) => Convert.ToInt32 ( $"{now.Year}{now.Month}{now.Day}{index}" ) )
                .ToList ();
            var reservedNumber = await m_storageContext.GetAsync<int> (
                new Query ( "reservednumber" )
                    .WhereIn ( "number", numbers )
                    .OrderByDesc ( "number" )
                    .Select ( "number" )
            );

            return numbers.First ( a => !reservedNumber.Contains ( a ) );
        }

        public async Task<bool> CheckNumberIsFree ( int number ) {
            var existsNumber = await m_storageContext.GetAsync<int> (
                new Query ( "reservednumber" )
                    .Where ( "number", number )
                    .Limit ( 1 )
            );
            return !existsNumber.Any();
        }

    }

}
