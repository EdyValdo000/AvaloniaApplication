using AvaloniaApplication.Model;
using AvaloniaApplication.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication.Service;

public class UtilizadorService
{
    private readonly UtilizadorRepository repository;

    public UtilizadorService(UtilizadorRepository repository)
    {
        this.repository = repository;
    }

    public Task<int> Save(Utilizador utilizador) => repository.Save(utilizador);
    public Task<Utilizador> GetById(int id) => repository.GetById(id);
    public Task<int> Update(Utilizador utilizador) => repository.Update(utilizador);
    public Task<int> Delete(Utilizador utilizador) => repository.Delete(utilizador);
    public Task<Utilizador> GetCurrentUser() => repository.GetCurrentUser(); 
    public Task<int> DeleteAll() => repository.DeleteAll();
    public Task<Utilizador> GetByName(string nome) => repository.GetByName(nome);
    public Task<Utilizador> GetByGenero(string genero) => repository.GetByGenero(genero);
}
