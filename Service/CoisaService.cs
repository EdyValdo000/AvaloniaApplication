using AvaloniaApplication.Model;
using AvaloniaApplication.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication.Service;

public class CoisaService
{
    private readonly CoisaRepository repositore;

    public CoisaService(CoisaRepository repositore)
    {
        this.repositore = repositore;
    }

    // Salvar um novo coisa
    public Task<int> Save(Coisa coisa) => repositore.Save(coisa);

    // Obter todos os alarmes
    public Task<List<Coisa>> GetAll() => repositore.GetAll();

    // Obter coisa por ID
    public Task<Coisa> GetById(int id) => repositore.GetById(id);

    // Atualizar um coisa
    public Task<int> Update(Coisa coisa) => repositore.Update(coisa);

    // Deletar um coisa
    public Task<int> Delete(Coisa coisa) => repositore.Delete(coisa);
    
    // Contar número de alarmes cadastrados
    public Task<int> GetCount() => repositore.GetCount();

    // Obter os últimos alarmes cadastrados
    public Task<List<Coisa>> GetLast(int limit = 5) => repositore.GetLasts(limit);

    // Eliminar todos os alarmes
    public Task<int> DeleteAll() => repositore.DeleteAll();
}