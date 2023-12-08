using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Aula05
{

    //    ** Exercício: Sistema de Gerenciamento de Música**
    //Você está desenvolvendo um sistema de gerenciamento de música e precisa implementar a
    //funcionalidade de salvar e carregar dados de músicas usando JSON.
    //Para isso, você deve utilizar a biblioteca `System.Text.Json` do C#.
    //1. **Crie uma classe `Music`**:
    //   - A classe deve ter propriedades como `Title`, `Artist`, `Album`, `Genre`, `Year`, etc.
    //   - Inclua anotações de atributo para personalizar a serialização/desserialização.
    //2. **Crie uma classe `MusicLibrary`**:
    //   - A classe deve conter uma lista de músicas (`List<Music>`).
    //   - Implemente métodos para adicionar e listar músicas na biblioteca.
    //3. ** Serialização**:
    //   - Crie um método que recebe uma lista de músicas e serializa para JSON.
    //   - Salve o JSON resultante em um arquivo chamado "musicLibrary.json".
    //4. ** Desserialização**:
    //   - Crie um método que lê um arquivo JSON("musicLibrary.json") e desserializa as músicas de volta para uma lista.
    //5. ** Teste**:
    //   - Crie algumas instâncias de músicas e adicione-as à sua biblioteca.
    //   - Serialize a biblioteca para JSON e salve no arquivo.
    //   - Limpe a biblioteca e depois desserialize as músicas do arquivo.
    //   - Liste as músicas para verificar se a desserialização foi bem-sucedida.

    //** Dicas:**
    //- Use a biblioteca `System.Text.Json.JsonSerializer`.
    //- Utilize o `File.WriteAllText` e `File.ReadAllText` para salvar e ler arquivos.
    //** Desafio Adicional:**
    //- Implemente um menu simples no console para permitir que o usuário adicione, liste e salve músicas através do programa.



    public class Music
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
    }

    public class MusicLibrary
    {
        public List<Music> Songs { get; set; }
        public MusicLibrary() 
        {
            Songs = new List<Music>();
        }
        public void AddMusic(Music music)
        {
            Songs.Add(music);
        }

        public void ListMusic()
        {
            foreach (var music in Songs)
            {
                Console.WriteLine($"{music.Title} - {music.Artist} ({music.Year})");
            }
        }

        public void SerializeToJson(List<Music> musicList)
        {
            string jsonString = JsonSerializer.Serialize(musicList, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText("musicLibrary.json", jsonString);
        }

        public List<Music> DeserializeFromJson()
        {
            List<Music> musicList = new List<Music>();

            if (File.Exists("musicLibrary.json"))
            {
                string jsonString = File.ReadAllText("musicLibrary.json");
                musicList = JsonSerializer.Deserialize<List<Music>>(jsonString);
            }

            return musicList;
        }

    }

    public class GerenciadorDeMusica
    {
        static void Main()
        {
            MusicLibrary library = new MusicLibrary();

            // Teste
            // Adicione algumas músicas à biblioteca
            library.AddMusic(new Music { Title = "Song 1", Artist = "Artist 1", Album = "Album 1", Genre = "Genre 1", Year = 2020 });
            library.AddMusic(new Music { Title = "Song 2", Artist = "Artist 2", Album = "Album 2", Genre = "Genre 2", Year = 2021 });

            // Serialize e salve no arquivo
            library.SerializeToJson(library.Songs);

            // Limpe a biblioteca
            library.Songs.Clear();

            // Desserialize do arquivo
            library.Songs = library.DeserializeFromJson();

            // Liste as músicas para verificar se a desserialização foi bem-sucedida
            Console.WriteLine("Músicas após desserialização:");
            library.ListMusic();

            // Desafio adicional: Implemente um menu no console
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Adicionar Música");
                Console.WriteLine("2. Listar Músicas");
                Console.WriteLine("3. Salvar e Sair");
                Console.Write("Escolha uma opção: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Write("Digite o título da música: ");
                        string title = Console.ReadLine();
                        Console.Write("Digite o nome do artista: ");
                        string artist = Console.ReadLine();
                        Console.Write("Digite o nome do álbum: ");
                        string album = Console.ReadLine();
                        Console.Write("Digite o gênero da música: ");
                        string genre = Console.ReadLine();
                        Console.Write("Digite o ano de lançamento: ");
                        int year = int.Parse(Console.ReadLine());

                        library.AddMusic(new Music { Title =  title, Artist = artist, Album = album, Genre = genre, Year = year });
                        Console.WriteLine("Música adicionada com sucesso!");
                        break;

                    case "2":
                        library.ListMusic();
                        break;

                    case "3":
                        library.SerializeToJson(library.Songs);
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }
    }
}