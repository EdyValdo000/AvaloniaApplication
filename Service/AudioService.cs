using AvaloniaApplication.Model;
using AvaloniaApplication.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication.Service; public class AudioService
{
    private readonly AudioRepository repository;

    public AudioService(AudioRepository repository)
    {
        this.repository = repository;
    }

    public Task<int> Save(Audio audio) => repository.Save(audio);
    public Task<List<Audio>> GetAll() => repository.GetAll();
    public Task<Audio> GetById(int id) => repository.GetById(id);
    public Task<int> Update(Audio audio) => repository.Update(audio);
    public Task<int> Delete(Audio audio) => repository.Delete(audio);
    public Task<int> GetCount() => repository.GetCount();
    public Task<List<Audio>> GetLasts(int limit = 5) => repository.GetLasts(limit);
    public Task<int> DeleteAll() => repository.DeleteAll();
    public Task<List<Audio>> GetByCategoria(int categoriaId) => repository.GetByCategoria(categoriaId);
    public Task<List<Audio>> GetCreatedAfter(DateTime date) => repository.GetCreatedAfter(date);
    public Task<Audio> GetByName(string nome) => repository.GetByName(nome);
}
