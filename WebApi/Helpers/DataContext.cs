
//namespace WebApi.Helpers;

//using Dapper;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Options;
//using Npgsql;
//using System.Data;
//using WebApi.Entities;

//public class DataContext : DbContext
//{
//    public DbSet<Account> Accounts { get; set; }

//    private DbSettings _dbSettings;

//    public DataContext(IOptions<DbSettings> dbSettings)
//    {
//        _dbSettings = dbSettings.Value;
//    }

//    public IDbConnection CreateConnection()
//    {
//        var connectionString = $"Host={_dbSettings.Server}; Database={_dbSettings.Database}; Username={_dbSettings.UserId}; Password={_dbSettings.Password};";
//        return new NpgsqlConnection(connectionString);
//    }

//    public async Task Init()
//    {
//        await _initDatabase();
//        await _initTables();
//    }

//    private async Task _initDatabase()
//    {
//        // create database if it doesn't exist
//        var connectionString = $"Host={_dbSettings.Server}; Database=postgres; Username={_dbSettings.UserId}; Password={_dbSettings.Password};";
//        using var connection = new NpgsqlConnection(connectionString);
//        var sqlDbCount = $"SELECT COUNT(*) FROM pg_database WHERE datname = '{_dbSettings.Database}';";
//        var dbCount = await connection.ExecuteScalarAsync<int>(sqlDbCount);
//        if (dbCount == 0)
//        {
//            var sql = $"CREATE DATABASE \"{_dbSettings.Database}\"";
//            await connection.ExecuteAsync(sql);
//        }
//    }

//    private async Task _initTables()
//    {
//        // create tables if they don't exist
//        using var connection = CreateConnection();
//        //await _initUsers();

//        async Task _initUsers()
//        {
//            var sql = """
//                CREATE TABLE IF NOT EXISTS Users (
//                    Id SERIAL PRIMARY KEY,
//                    Title VARCHAR,
//                    FirstName VARCHAR,
//                    LastName VARCHAR,
//                    Email VARCHAR,
//                    Role INTEGER,
//                    PasswordHash VARCHAR
//                );
//            """;
//            await connection.ExecuteAsync(sql);
//        }
//    }
//}



using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.Helpers;
public class DataContext : DbContext
{
    public DbSet<Account> Accounts { get; set; }

    private readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
    }

}
