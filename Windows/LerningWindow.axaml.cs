using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AvaloniaApplication
{
    public partial class LerningWindow : Window
    {
        private List<string> _imagePaths; // Lista de caminhos das imagens
        private Random _random = new();

        public LerningWindow()
        {
            _imagePaths = [];
            InitializeComponent();
            LoadItemsAsync();
        }

        private void LoadItemsAsync()
        {
            // Caminho relativo para a pasta de imagens
            string imagesFolder = Path.Combine(AppContext.BaseDirectory, "Imagens");

            // Verifica se a pasta existe
            if (!Directory.Exists(imagesFolder))
            {
                Console.WriteLine("A pasta 'Imagens' não foi encontrada.");
                return;
            }

            // Carrega todas as imagens da pasta
            _imagePaths = [.. Directory.GetFiles(imagesFolder, "*.jpg")];

            // Exibe as primeiras 12 imagens
            for (int i = 0; i < 12 && i < _imagePaths.Count; i++)
            {
                AddImageToPanel(_imagePaths[i]);
            }
        }

        private void AddImageToPanel(string imagePath)
        {
            var image = new Image
            {
                Source = new Bitmap(imagePath),
                Width = 150,
                Height = 150,
                Margin = new Thickness(10),
                Cursor = new Cursor(StandardCursorType.Hand)
            };

            // Adiciona evento de clique
            image.PointerPressed += OnImageClicked;

            ItemsWrapPanel.Children.Add(image);
        }

        private async void OnImageClicked(object sender, PointerPressedEventArgs e)
        {
            if (sender is Image image)
            {
                // Animação de aumento e redução
                await RunAnimation(image, 200, 200, runs: 5, frames:30);

                // Substitui a imagem por uma nova
                string? newImagePath = GetRandomImagePath();
                image.Source = new Bitmap(newImagePath!);
            }
        }
        
        private static async Task RunAnimation(Image image, double targetWidth, double targetHeight, int frames = 30, int runs = 1)
        {
            for (int x = 0; x<=runs; x++)
            {
                await AnimateImageSizeAsync(image, targetWidth, targetWidth, 60); // Aumenta para 200x200
                await AnimateImageSizeAsync(image, targetWidth-50, targetWidth-50, 60); // Reduz para 150x150
            }
        }

        private static async Task AnimateImageSizeAsync(Image image, double targetWidth, double targetHeight, int frames = 30)
        {
            double initialWidth = image.Width;
            double initialHeight = image.Height;

            //int frames = 30;  Número de frames para a animação
            int delayBetweenFrames = 10; // Atraso entre os frames (em milissegundos)

            for (int i = 0; i <= frames; i++)
            {
                double progress = (double)i / frames; // Progresso da animação (0 a 1)

                // Interpolação linear para suavizar a animação
                image.Width = initialWidth + (targetWidth - initialWidth) * progress;
                image.Height = initialHeight + (targetHeight - initialHeight) * progress;

                // Aguarda um curto período para criar o efeito de frame
                await Task.Delay(delayBetweenFrames);
            }
        }

        private string? GetRandomImagePath()
        {
            // Retorna um caminho de imagem aleatório da lista
            if (_imagePaths.Count == 0) return null;
            return _imagePaths[_random.Next(_imagePaths.Count)];
        }
    }
}