using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoInter.Models;

public class ClientServiceViewModel : ClientService
{
    public DateTime Time { get; set; }
}