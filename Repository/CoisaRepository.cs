using AvaloniaApplication.Conection;
using AvaloniaApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication.Repository;

public class CoisaRepository : ConectionDatabase
{   
    // Create
    public Task<int> Save(Coisa coisa)
    {
        return database.InsertAsync(coisa);
    }

    // Read - Todos os alarmes
    public Task<List<Coisa>> GetAll()
    {
        return database.Table<Coisa>().ToListAsync();
    }

    // Read - Buscar coisa por ID
    public Task<Coisa> GetById(int id)
    {
        return database.Table<Coisa>().Where(a => a.Id == id).FirstOrDefaultAsync();
    }

    // Update
    public Task<int> Update(Coisa alarme)
    {
        return database.UpdateAsync(alarme);
    }

    // Delete
    public Task<int> Delete(Coisa alarme)
    {
        return database.DeleteAsync(alarme);
    }    

    // Extra 2 - Contar número de alarmes cadastrados
    public Task<int> GetCount()
    {
        return database.Table<Coisa>().CountAsync();
    }

    // Extra 3 - Obter os últimos alarmes cadastrados (limit 5)
    public Task<List<Coisa>> GetLasts(int limit = 5)
    {
        return database.Table<Coisa>().OrderByDescending(coisa => coisa.CreatedAt).Take(limit).ToListAsync();
    }

    // Extra 4 - Eliminar todos os alarmes
    public Task<int> DeleteAll()
    {
        return database.DeleteAllAsync<Coisa>();
    }
}