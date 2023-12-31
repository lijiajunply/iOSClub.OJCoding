using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OJCoding.Share.DataModels;

/// <summary>
/// 课程
/// </summary>
public class CourseModel
{
    [Key]
    [Column(TypeName = "varchar(256)")]
    public string Guid { get; set; }
    public string Name { get; set; }
    public string Intro { get; set; }
    public string Material { get; set; }
    public List<TestModel> Tests { get; set; } = [];
}