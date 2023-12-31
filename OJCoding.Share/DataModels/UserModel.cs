using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OJCoding.Share.DataModels;

public class UserModel
{
    [Key]
    [Column(TypeName = "varchar(256)")]
    public string Guid { get; set; }
    
    public string Name { get; set; }
    public string Password { get; set; }
    public List<LearnCourseModel> Courses { get; set; } = [];
}

public class LearnCourseModel
{
    [Key]
    [Column(TypeName = "varchar(256)")]
    public string Guid { get; set; }
    
    public CourseModel Course { get; set; }
    public List<LearnTestModel> Schedule { get; set; } = [];
}

public class LearnTestModel
{
    [Key]
    [Column(TypeName = "varchar(256)")]
    public string Guid { get; set; }
    
    public TestModel Test { get; set; }
    public string Data { get; set; }
}