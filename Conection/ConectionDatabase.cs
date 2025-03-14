using AvaloniaApplication.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication.Conection;

public partial class ConectionDatabase
{
    public readonly SQLiteAsyncConnection database;

    public ConectionDatabase()
    {
        var local = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "mari.db3");
        database = new SQLiteAsyncConnection(local);

        database.CreateTableAsync<Coisa>().Wait();
        
        database.CreateTableAsync<Audio>().Wait();
        database.CreateTableAsync<Categoria>().Wait();
        database.CreateTableAsync<Imagem>().Wait();
        database.CreateTableAsync<Utilizador>().Wait();
    }
}
