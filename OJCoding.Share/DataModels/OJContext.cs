using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace OJCoding.Share.DataModels;

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

public static class ContextGuidStatic
{
    public static string CourseGuid(this CourseModel model) => model.ToString().GetGuid();
    public static string UserGrid(this UserModel model) => model.ToString().GetGuid();
    public static string TestGrid(this TestModel model) => model.ToString().GetGuid();
    public static string LearnCourseGrid(this LearnCourseModel model) => model.ToString().GetGuid();
    public static string LearnTestGrid(this LearnTestModel model) => model.ToString().GetGuid();

    public static string GetGuid(this string s) => new Guid(s).ToString();
}