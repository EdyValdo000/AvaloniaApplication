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
        private int _currentImageIndex = 0; // �ndice da imagem atual
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
                Console.WriteLine("A pasta 'Imagens' n�o foi encontrada.");
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
            // Reproduz o �udio correspondente � imagem atual
            if (_imagePaths.Any())
            {
                string audioPath = GetAudioPathForImage(_imagePaths[_currentImageIndex]);
                if (File.Exists(audioPath))
                {
                    // Aqui voc� pode usar uma biblioteca de reprodu��o de �udio, como NAudio ou outra.
                    Console.WriteLine($"Reproduzindo �udio: {audioPath}");
                }
                else
                {
                    Console.WriteLine("�udio n�o encontrado.");
                }
            }
        }

        private async void OnNextImageClick(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            // Avan�a para a pr�xima imagem
            if (_imagePaths.Any())
            {
                _currentImageIndex = (_currentImageIndex + 1) % _imagePaths.Count;
                await LoadImageAsync(_imagePaths[_currentImageIndex]);
            }
        }

        private string GetAudioPathForImage(string imagePath)
        {
            // Obt�m o nome do arquivo de imagem (sem extens�o)
            string imageName = Path.GetFileNameWithoutExtension(imagePath);

            // Constr�i o caminho do �udio correspondente
            string audioFolder = Path.Combine(AppContext.BaseDirectory, "Audios");
            return Path.Combine(audioFolder, $"{imageName}.mp3");
        }
    }
}