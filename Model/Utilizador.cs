using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication.Model;

public class Utilizador
{
    [PrimaryKey, AutoIncrement] public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Genero { get; set; } // "M" ou "F"
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}