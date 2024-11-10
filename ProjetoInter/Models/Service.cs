using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoInter.Models;

[Table("Service")]
public class Service
{
    // [Key]
    public int ServiceId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string PathFoto { get; set; }
    public string Duration { get; set; }

}