using efCoreSqlLiteInMemory;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;


var connection = new SqliteConnection("DataSource=:memory:");
connection.Open();
var options = new DbContextOptionsBuilder<MyDbContext>()
    .UseSqlite(connection)
    .Options;
using var context = new MyDbContext(options);
context.Database.EnsureCreated();