using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OJBlazor.Share.DataModels;

public class TestModel
{
    [Key]
    [Column(TypeName = "varchar(256)")]
    public string HashName { get; set; }

    public string Name { get; set; }
    public string Intro { get; set; }
    public string Arg { get; set; }
    public string Code { get; set; }

    public override string ToString()
    {
        return $"Name={Name};Intro={Intro};Code={Code};Arg={Arg}";
    }
}

/// <summary>
/// Type:Name:Value
/// </summary>
/// <param name="Arg">Arg代码</param>
public class ArgRecord
{
    public string Type { get; set; } = "";
    public string Value { get; set; } = "";
    public string Name { get; set; } = "";

    public ArgRecord(string Arg)
    {
        Type = Arg.Split(":")[0];
        Value = Arg.Split(":")[2];
        Name = Arg.Split(":")[1];
    }
    
    public ArgRecord(){}

    public static ArgRecord[] GetArray(string arg) => arg.Split(";").Select(x => new ArgRecord(x)).ToArray();
    public override string ToString() => $"类型:{Type} 变量名称:{Name} 变量值:{Value}";
}