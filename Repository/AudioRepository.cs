using AvaloniaApplication.Conection;
using AvaloniaApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication.Repository;

public class AudioRepository : ConectionDatabase
{
    // Create
    public Task<int> Save(Audio audio) => database.InsertAsync(audio);

    // Read - Todos os áudios
    public Task<List<Audio>> GetAll() => database.Table<Audio>().ToListAsync();

    // Read - Buscar áudio por ID
    public Task<Audio> GetById(int id) => database.Table<Audio>().Where(a => a.Id == id).FirstOrDefaultAsync();

    // Update
    public Task<int> Update(Audio audio) => database.UpdateAsync(audio);

    // Delete
    public Task<int> Delete(Audio audio) => database.DeleteAsync(audio);

    // Contar número de áudios
    public Task<int> GetCount() => database.Table<Audio>().CountAsync();

    // Obter os últimos áudios cadastrados
    public Task<List<Audio>> GetLasts(int limit = 5) => database.Table<Audio>().OrderByDescending(a => a.CreatedAt).Take(limit).ToListAsync();

    // Eliminar todos os áudios
    public Task<int> DeleteAll() => database.DeleteAllAsync<Audio>();

    // Buscar áudios por categoria
    public Task<List<Audio>> GetByCategoria(int categoriaId) => database.Table<Audio>().Where(a => a.CategoriaId == categoriaId).ToListAsync();

    // Buscar áudios criados após uma data específica
    public Task<List<Audio>> GetCreatedAfter(DateTime date) => database.Table<Audio>().Where(a => a.CreatedAt > date).ToListAsync();

    // Buscar áudio por nome
    public Task<Audio> GetByName(string nome) => database.Table<Audio>().Where(a => a.Nome == nome).FirstOrDefaultAsync();
}