using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OJBlazor.Share.DataModels;

public class UserModel
{
    public string Name { get; set; }
    public string Identity { get; set; }
    
    [Key]
    [Column(TypeName = "varchar(256)")]
    public string Id { get; set; }

    public string LearnCourses { get; set; } = "";
}