using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace OJBlazor.Share.DataModels;

public sealed class OJContext : DbContext
{
    public DbSet<UserModel> UserModels { get; set; }
    public DbSet<CourseModel> CourseModels { get; set; }
    public DbSet<TestModel> TestModels { get; set; }

    public OJContext(DbContextOptions<OJContext> options)
        : base(options)
    {
        UserModels = Set<UserModel>();
        CourseModels = Set<CourseModel>();
        TestModels = Set<TestModel>();
    }
}

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<OJContext>
{
    public OJContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<OJContext>();
        optionsBuilder.UseSqlite("Data Source=Data.db");
        return new OJContext(optionsBuilder.Options);
    }
}

public static class HashStatic
{
    public static string GetHash(this string s)
    {
        s += DateTime.Now.ToString("s");
        return Convert.ToBase64String(SHA512.HashData(Encoding.UTF8.GetBytes(s))).ToUpper();
    }
}