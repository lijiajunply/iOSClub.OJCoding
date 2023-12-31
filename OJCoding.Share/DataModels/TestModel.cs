using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OJCoding.Share.DataModels;

public class TestModel
{
    [Key]
    [Column(TypeName = "varchar(256)")]
    public string Guid { get; set; }

    public string Intro { get; set; }
    public List<string> Arg { get; set; }
    public string Code { get; set; }
}

/// <summary>
/// Type:Name:Value
/// </summary>
/// <param name="Arg">Arg代码</param>
public record ArgRecord(string Arg)
{
    public string Type => Arg.Split(":")[0];
    public string Value => Arg.Split(":")[2];
    public string Name => Arg.Split(":")[1];

    public static ArgRecord[] GetArray(string arg) => arg.Split(";").Select(x => new ArgRecord(x)).ToArray();
}