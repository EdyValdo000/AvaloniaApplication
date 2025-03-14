using SQLite;
using System;

namespace AvaloniaApplication.Model;

public partial class Coisa
{
    [PrimaryKey, AutoIncrement] public int Id { get; set; } // Chave primária
    public string? Nome { get; set; }
    public string? CategoriaId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Data de criação  
}
