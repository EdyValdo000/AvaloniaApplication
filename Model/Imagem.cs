using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication.Model;

public class Imagem
{
    [PrimaryKey, AutoIncrement] public int Id { get; set; }
    public string? Nome { get; set; }
    public int CategoriaId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}