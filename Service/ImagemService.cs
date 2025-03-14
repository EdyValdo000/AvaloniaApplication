using AvaloniaApplication.Model;
using AvaloniaApplication.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication.Service;

public class ImagemService
{
    private readonly ImagemRepository repository;

    public ImagemService(ImagemRepository repository)
    {
        this.repository = repository;
    }

    public Task<int> Save(Imagem imagem) => repository.Save(imagem);
    public Task<List<Imagem>> GetAll() => repository.GetAll();
    public Task<Imagem> GetById(int id) => repository.GetById(id);
    public Task<int> Update(Imagem imagem) => repository.Update(imagem);
    public Task<int> Delete(Imagem imagem) => repository.Delete(imagem);
    public Task<int> GetCount() => repository.GetCount();
    public Task<List<Imagem>> GetLasts(int limit = 5) => repository.GetLasts(limit);
    public Task<int> DeleteAll() => repository.DeleteAll();
    public Task<List<Imagem>> GetByCategoria(int categoriaId) => repository.GetByCategoria(categoriaId);
    public Task<List<Imagem>> GetCreatedAfter(DateTime date) => repository.GetCreatedAfter(date);
    public Task<Imagem> GetByName(string nome) => repository.GetByName(nome);
}
