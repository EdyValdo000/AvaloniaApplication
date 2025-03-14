using AvaloniaApplication.Model;
using AvaloniaApplication.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication.Service;

public class CategoriaService
{
    private readonly CategoriaRepository repository;

    public CategoriaService(CategoriaRepository repository)
    {
        this.repository = repository;
    }

    public Task<int> Save(Categoria categoria) => repository.Save(categoria);
    public Task<List<Categoria>> GetAll() => repository.GetAll();
    public Task<Categoria> GetById(int id) => repository.GetById(id);
    public Task<int> Update(Categoria categoria) => repository.Update(categoria);
    public Task<int> Delete(Categoria categoria) => repository.Delete(categoria);
    public Task<int> GetCount() => repository.GetCount();
    public Task<List<Categoria>> GetLasts(int limit = 5) => repository.GetLasts(limit);
    public Task<int> DeleteAll() => repository.DeleteAll();
    public Task<Categoria> GetByName(string nome) => repository.GetByName(nome);
    public Task<List<Categoria>> GetWithMoreThanXImages(int x) => repository.GetWithMoreThanXImages(x);
    public Task<List<Categoria>> GetCreatedAfter(DateTime date) => repository.GetCreatedAfter(date);
}