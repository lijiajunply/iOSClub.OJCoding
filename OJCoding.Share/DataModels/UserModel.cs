using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OJCoding.Share.DataModels;

public class UserModel
{
    [Key]
    [Column(TypeName = "varchar(256)")]
    public string Guid { get; set; }
    
    public string Name { get; set; }
    public string Password { get; set; }
    public List<LearnCourseModel> Courses { get; set; } = [];
    public override string ToString()
    {
        var builder = new StringBuilder();
        foreach (var test in Courses)
            builder.Append(test+">");
        
        return $"Name={Name};Password={Password};Courses={builder}";
    }
    
    public override bool Equals(object? obj)
    {
        if (obj is not UserModel user) return false;
        return user.Name == Name && user.Password == Password;
    }

    protected bool Equals(UserModel other)
    {
        return other.Name == Name && other.Password == Password;
    }
}

public class LearnCourseModel
{
    [Key]
    [Column(TypeName = "varchar(256)")]
    public string Guid { get; set; }
    
    public CourseModel Course { get; set; }
    public List<LearnTestModel> Schedule { get; set; } = [];
    public override string ToString()
    {
        var builder = new StringBuilder();
        foreach (var test in Schedule)
            builder.Append(test+">");
        
        return $"Course={Course};Schedule={builder}";
    }
}

public class LearnTestModel
{
    [Key]
    [Column(TypeName = "varchar(256)")]
    public string Guid { get; set; }
    
    public TestModel Test { get; set; }
    public string Data { get; set; }

    public override string ToString() => $"Test={Test};Data={Data}";
}