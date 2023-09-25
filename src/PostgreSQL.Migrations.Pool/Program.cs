using PostgreSQL.Migrations.Pool;

var builder = WebApplication.CreateBuilder ( args );

Dependencies.Resolve ( builder.Services );

var app = builder.Build ();

if ( !app.Environment.IsDevelopment () ) app.UseExceptionHandler ( "/Error" );

app.UseStaticFiles ();

app.UseRouting ();

app.Run ();
