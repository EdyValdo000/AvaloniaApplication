using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication.Model;

public partial class Coisa
{
    [PrimaryKey, AutoIncrement] public int Id { get; set; } // Chave primária
    public string? Nome { get; set; }
    public string? Categoria { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Data de criação  
}
