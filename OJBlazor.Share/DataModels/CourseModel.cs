using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OJBlazor.Share.DataModels;

/// <summary>
/// 课程
/// </summary>
public class CourseModel
{
    [Key]
    [Column(TypeName = "varchar(256)")]
    public string Name { get; set; }
    public string Intro { get; set; }
    public string Material { get; set; }
    public List<TestModel> Tests { get; set; } = new();
    public override string ToString()
    {
        var builder = new StringBuilder();
        foreach (var test in Tests)
            builder.Append(test+">");
        
        return $"Name={Name};Intro={Intro};Material={Material};Tests={builder}";
    }
}