using AvaloniaApplication.Conection;
using AvaloniaApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication.Repository;

public class UtilizadorRepository : ConectionDatabase
{
    // Create
    public Task<int> Save(Utilizador utilizador) => database.InsertAsync(utilizador);

    // Read - Buscar utilizador por ID
    public Task<Utilizador> GetById(int id) => database.Table<Utilizador>().Where(u => u.Id == id).FirstOrDefaultAsync();

    // Update
    public Task<int> Update(Utilizador utilizador) => database.UpdateAsync(utilizador);

    // Delete
    public Task<int> Delete(Utilizador utilizador) => database.DeleteAsync(utilizador);

    // Buscar utilizador atual
    public Task<Utilizador> GetCurrentUser() => database.Table<Utilizador>().FirstOrDefaultAsync();    

    // Eliminar todos os utilizadores
    public Task<int> DeleteAll() => database.DeleteAllAsync<Utilizador>();

    // Buscar utilizador por nome
    public Task<Utilizador> GetByName(string nome) => database.Table<Utilizador>().Where(u => u.Nome == nome).FirstOrDefaultAsync();

    // Buscar utilizador por género
    public Task<Utilizador> GetByGenero(string genero) => database.Table<Utilizador>().Where(u => u.Genero == genero).FirstOrDefaultAsync();
}