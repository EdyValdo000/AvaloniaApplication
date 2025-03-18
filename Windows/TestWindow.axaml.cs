using Avalonia;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AvaloniaApplication
{
    public partial class TestWindow : Window
    {
        private List<string> _imagePaths; // Lista de caminhos das imagens
        private int _currentImageIndex = 0; // Índice da imagem atual
        private Random _random = new Random();

        public TestWindow()
        {
            InitializeComponent();
            LoadImagesAsync();
        }

        private async void LoadImagesAsync()
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
            _imagePaths = Directory.GetFiles(imagesFolder, "*.jpg").ToList();

            // Exibe a primeira imagem
            if (_imagePaths.Any())
            {
                await LoadImageAsync(_imagePaths[_currentImageIndex]);
            }
        }

        private async Task LoadImageAsync(string imagePath)
        {
            // Carrega a imagem no controle Image
            TestImage.Source = new Bitmap(imagePath);
        }

        private async void OnPlayAudioClick(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            // Reproduz o áudio correspondente à imagem atual
            if (_imagePaths.Any())
            {
                string audioPath = GetAudioPathForImage(_imagePaths[_currentImageIndex]);
                if (File.Exists(audioPath))
                {
                    // Aqui você pode usar uma biblioteca de reprodução de áudio, como NAudio ou outra.
                    Console.WriteLine($"Reproduzindo áudio: {audioPath}");
                }
                else
                {
                    Console.WriteLine("Áudio não encontrado.");
                }
            }
        }

        private async void OnNextImageClick(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            // Avança para a próxima imagem
            if (_imagePaths.Any())
            {
                _currentImageIndex = (_currentImageIndex + 1) % _imagePaths.Count;
                await LoadImageAsync(_imagePaths[_currentImageIndex]);
            }
        }

        private string GetAudioPathForImage(string imagePath)
        {
            // Obtém o nome do arquivo de imagem (sem extensão)
            string imageName = Path.GetFileNameWithoutExtension(imagePath);

            // Constrói o caminho do áudio correspondente
            string audioFolder = Path.Combine(AppContext.BaseDirectory, "Audios");
            return Path.Combine(audioFolder, $"{imageName}.mp3");
        }
    }
}