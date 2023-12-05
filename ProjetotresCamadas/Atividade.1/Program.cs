// See https://aka.ms/new-console-template for more information

using static System.Net.Mime.MediaTypeNames;

Console.WriteLine("Qual é seu nome?");
string nome = Console.ReadLine();

Console.WriteLine("Como você esta hoje?");
string comoEsta = Console.ReadLine();


File.Create("como_esta_vc_DD_MM_YYYY_hh_mm_sns.txt").Dispose();

EscreverEmArquivo($"{nome}",$"{comoEsta}" , "como_esta_vc_DD_MM_YYYY_hh_mm_sns.txt");

static void EscreverEmArquivo(string nome,string comoEsta, string como_esta_vc_DD_MM_YYYY_hh_mm_snstxt) 
{ 
    File.AppendAllText(como_esta_vc_DD_MM_YYYY_hh_mm_snstxt, nome);
}

var ConteudoDoArquivo = LerArquivo;

static string LerArquivo(string como_esta_vc_DD_MM_YYYY_hh_mm_snstxt)
{
    string conteudoArquivo = File.ReadAllText(como_esta_vc_DD_MM_YYYY_hh_mm_snstxt);
    return conteudoArquivo;
}