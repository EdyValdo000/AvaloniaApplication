using AvaloniaApplication.Conection;
using AvaloniaApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication.Repository;

public class CategoriaRepository : ConectionDatabase
{
    // Create
    public Task<int> Save(Categoria categoria) => database.InsertAsync(categoria);

    // Read - Todas as categorias
    public Task<List<Categoria>> GetAll() => database.Table<Categoria>().ToListAsync();

    // Read - Buscar categoria por ID
    public Task<Categoria> GetById(int id) => database.Table<Categoria>().Where(c => c.Id == id).FirstOrDefaultAsync();

    // Update
    public Task<int> Update(Categoria categoria) => database.UpdateAsync(categoria);

    // Delete
    public Task<int> Delete(Categoria categoria) => database.DeleteAsync(categoria);

    // Contar número de categorias
    public Task<int> GetCount() => database.Table<Categoria>().CountAsync();

    // Obter as últimas categorias cadastradas
    public Task<List<Categoria>> GetLasts(int limit = 5) => database.Table<Categoria>().OrderByDescending(c => c.CreatedAt).Take(limit).ToListAsync();

    // Eliminar todas as categorias
    public Task<int> DeleteAll() => database.DeleteAllAsync<Categoria>();

    // Buscar categoria por nome
    public Task<Categoria> GetByName(string nome) => database.Table<Categoria>().Where(c => c.Nome == nome).FirstOrDefaultAsync();

    // Buscar categorias com mais de X imagens
    public Task<List<Categoria>> GetWithMoreThanXImages(int x) => database.QueryAsync<Categoria>(
        "SELECT c.* FROM Categoria c JOIN Imagem i ON c.Id = i.CategoriaId GROUP BY c.Id HAVING COUNT(i.Id) > ?", x);

    // Buscar categorias criadas após uma data específica
    public Task<List<Categoria>> GetCreatedAfter(DateTime date) => database.Table<Categoria>().Where(c => c.CreatedAt > date).ToListAsync();
}