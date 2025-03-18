using SQLite;
using System;

namespace AvaloniaApplication.Model;

public class Categoria
{
    [PrimaryKey, AutoIncrement] public int Id { get; set; }
    public string? Nome { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}