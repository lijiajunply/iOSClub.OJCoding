using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OJBlazor.Share.DataModels;

public class TestModel
{
    [Key]
    [Column(TypeName = "varchar(256)")]
    public string HashName { get; set; }

    public string Name { get; set; }
    public string Intro { get; set; }
    public string TestCode { get; set; }
    public string Code { get; set; }
    public string Language { get; set; }

    public override string ToString()
    {
        return $"Name={Name};Intro={Intro};Code={Code};TestCode={TestCode};Language={Language};";
    }
}