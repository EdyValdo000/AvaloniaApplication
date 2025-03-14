using AvaloniaApplication.Conection;
using AvaloniaApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication.Repository;

public class ImagemRepository : ConectionDatabase
{
    // Create
    public Task<int> Save(Imagem imagem) => database.InsertAsync(imagem);

    // Read - Todas as imagens
    public Task<List<Imagem>> GetAll() => database.Table<Imagem>().ToListAsync();

    // Read - Buscar imagem por ID
    public Task<Imagem> GetById(int id) => database.Table<Imagem>().Where(i => i.Id == id).FirstOrDefaultAsync();

    // Update
    public Task<int> Update(Imagem imagem) => database.UpdateAsync(imagem);

    // Delete
    public Task<int> Delete(Imagem imagem) => database.DeleteAsync(imagem);

    // Contar número de imagens
    public Task<int> GetCount() => database.Table<Imagem>().CountAsync();

    // Obter as últimas imagens cadastradas
    public Task<List<Imagem>> GetLasts(int limit = 5) => database.Table<Imagem>().OrderByDescending(i => i.CreatedAt).Take(limit).ToListAsync();

    // Eliminar todas as imagens
    public Task<int> DeleteAll() => database.DeleteAllAsync<Imagem>();

    // Buscar imagens por categoria
    public Task<List<Imagem>> GetByCategoria(int categoriaId) => database.Table<Imagem>().Where(i => i.CategoriaId == categoriaId).ToListAsync();

    // Buscar imagens criadas após uma data específica
    public Task<List<Imagem>> GetCreatedAfter(DateTime date) => database.Table<Imagem>().Where(i => i.CreatedAt > date).ToListAsync();

    // Buscar imagens por nome
    public Task<Imagem> GetByName(string nome) => database.Table<Imagem>().Where(i => i.Nome == nome).FirstOrDefaultAsync();
}