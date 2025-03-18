using SQLite;
using System;

namespace AvaloniaApplication.Model;

public class Imagem
{
    [PrimaryKey, AutoIncrement] public int Id { get; set; } // Chave primária
    public string? Nome { get; set; } // Nome da imagem
    public int CategoriaId { get; set; } // ID da categoria associada
    public string? CaminhoFoto { get; set; } // Caminho completo da foto no sistema de arquivos
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Data de criação
}