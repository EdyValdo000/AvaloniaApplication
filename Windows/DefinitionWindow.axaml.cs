using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Collections.ObjectModel;
using System.Linq;

namespace AvaloniaApplication
{
    public partial class DefinitionWindow : Window
    {
        // Listas observáveis para categorias e fotos
        public ObservableCollection<CategoriaDto> Categorias { get; set; }
        public ObservableCollection<ImagemDto> Fotos { get; set; }

        public DefinitionWindow()
        {
            InitializeComponent();
            DataContext = this; // Define o DataContext para a janela
            LoadData();
        }

        private void LoadData()
        {
            // Inicializa as listas observáveis
            Categorias = new ObservableCollection<CategoriaDto>
            {
                new CategoriaDto { Id = 1, Nome = "Animais" },
                new CategoriaDto { Id = 2, Nome = "Frutas" }
            };

            Fotos = new ObservableCollection<ImagemDto>
            {
                new ImagemDto { Id = 1, Nome = "Gato", CategoriaId = 1, CaminhoFoto = "caminho/para/gato.png" },
                new ImagemDto { Id = 2, Nome = "Cachorro", CategoriaId = 1, CaminhoFoto = "caminho/para/cachorro.png" },
                new ImagemDto { Id = 3, Nome = "Maçã", CategoriaId = 2, CaminhoFoto = "caminho/para/maca.png" }
            };

            // Define as fontes de dados para as ListBox
            CategoryListBox.ItemsSource = Categorias;
            PhotoListBox.ItemsSource = Fotos;
        }

        private void OnCategorySelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Atualiza a lista de fotos quando uma categoria é selecionada
            if (CategoryListBox.SelectedItem is CategoriaDto selectedCategory)
            {
                var fotosDaCategoria = Fotos.Where(f => f.CategoriaId == selectedCategory.Id).ToList();
                PhotoListBox.ItemsSource = fotosDaCategoria;
                DetailsTextBlock.Text = $"Categoria selecionada: {selectedCategory.Nome}";
            }
        }

        private void OnPhotoSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Exibe os detalhes da foto selecionada
            if (PhotoListBox.SelectedItem is ImagemDto selectedPhoto)
            {
                DetailsTextBlock.Text = $"Foto selecionada: {selectedPhoto.Nome}";
            }
        }

        private void OnAddCategoryClick(object sender, RoutedEventArgs e)
        {
            // Lógica para adicionar uma nova categoria
            var novaCategoria = new CategoriaDto { Id = Categorias.Count + 1, Nome = "Nova Categoria" };
            Categorias.Add(novaCategoria);
        }

        private void OnEditCategoryClick(object sender, RoutedEventArgs e)
        {
            // Lógica para editar a categoria selecionada
            if (CategoryListBox.SelectedItem is CategoriaDto selectedCategory)
            {
                selectedCategory.Nome = "Categoria Editada";
            }
        }

        private void OnDeleteCategoryClick(object sender, RoutedEventArgs e)
        {
            // Lógica para excluir a categoria selecionada
            if (CategoryListBox.SelectedItem is CategoriaDto selectedCategory)
            {
                Categorias.Remove(selectedCategory);
            }
        }

        private void OnAddPhotoClick(object sender, RoutedEventArgs e)
        {
            // Lógica para adicionar uma nova foto
            if (CategoryListBox.SelectedItem is CategoriaDto selectedCategory)
            {
                var novaFoto = new ImagemDto { Id = Fotos.Count + 1, Nome = "Nova Foto", CategoriaId = selectedCategory.Id, CaminhoFoto = "caminho/para/nova_foto.png" };
                Fotos.Add(novaFoto);
                PhotoListBox.ItemsSource = Fotos.Where(f => f.CategoriaId == selectedCategory.Id).ToList();
            }
        }

        private void OnEditPhotoClick(object sender, RoutedEventArgs e)
        {
            // Lógica para editar a foto selecionada
            if (PhotoListBox.SelectedItem is ImagemDto selectedPhoto)
            {
                selectedPhoto.Nome = "Foto Editada";
            }
        }

        private void OnDeletePhotoClick(object sender, RoutedEventArgs e)
        {
            // Lógica para excluir a foto selecionada
            if (PhotoListBox.SelectedItem is ImagemDto selectedPhoto)
            {
                Fotos.Remove(selectedPhoto);
            }
        }
    }

    // Classes de modelo (simplificadas)
    public class CategoriaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }

    public class ImagemDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CategoriaId { get; set; }
        public string CaminhoFoto { get; set; }
    }
}