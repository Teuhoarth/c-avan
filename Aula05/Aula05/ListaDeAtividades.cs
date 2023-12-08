using System;
using System.Collections.Generic;
using System.IO;

namespace Aula05
{
    //  Escreva um programa, para gerenciar as atividades do dia e semana:
    //1 Pergunte o título da atividade
    //1.1 Não deve permitir repetir a mesma atividade
    //2 Pergunte a descrição dela
    //3 Grave as respostas em um único arquivo por dia
    //4 O nome do arquivo deve ser no formato  “atividades_DD_MM_YYYY_.txt”

    //    Escreva outro programa que leia o arquivo feito no primeiro programa e tenha a seguintes regras:
    //1 Mostrar os atividades
    //2 Busque as atividades por dia
    //3 Busque as atividades por mês
    //4 Gera uma versão do arquivo em json


    public class ListaDeAtividades
    {
        static void Main()
        {
            Console.WriteLine("### Gerenciador de Atividades do Dia e Semana ###");

            // Pergunta o título da atividade
            Console.Write("Digite o título da atividade: ");
            string title = Console.ReadLine();

            // Pergunta a descrição da atividade
            Console.Write("Digite a descrição da atividade: ");
            string description = Console.ReadLine();

            // Gera o nome do arquivo com base na data atual
            string fileName = $"atividades_{DateTime.Now:dd_MM_yyyy}.txt";

            // Verifica se a atividade já existe no arquivo
            if (ActivityExists(fileName, title))
            {
                Console.WriteLine("Atividade já registrada para hoje. Não é permitido repetir a mesma atividade.");
            }
            else
            {
                // Grava as respostas em um arquivo
                RecordActivity(fileName, title, description);
                Console.WriteLine("Atividade registrada com sucesso para hoje!");
            }
        }

        static void RecordActivity(string fileName, string title, string description)
        {
            using (StreamWriter sw = File.AppendText(fileName))
            {
                sw.WriteLine($"Título: {title}");
                sw.WriteLine($"Descrição: {description}");
                sw.WriteLine(new string('-', 30));
            }
        }

        static bool ActivityExists(string fileName, string title)
        {
            if (File.Exists(fileName))
            {
                string[] lines = File.ReadAllLines(fileName);
                foreach (string line in lines)
                {
                    if (line.Contains($"Título: {title}"))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}