// See https://aka.ms/new-console-template for more information
using ProjetoEmTresCamadas.Pizzaria.DAO;
using ProjetoEmTresCammadas.Pizzaria.RegraDeNegocio;

var pizzaDao = new PizzaDao();

var pizzas = pizzaDao.ObterPizzas(); 


Console.WriteLine("Bem vindo a pizzaria");
Console.WriteLine("Gostaria de uma pizza, S para sim e N para não?");
var resposta = Console.ReadLine();

if (resposta == "S")
{
    var pizza = new Pizza1();
    Console.WriteLine("Qual o sabor da pizza, calabresa 'C', frango 'F'?");
    var sabor = Console.ReadLine();
    Console.WriteLine($"O sabor escolhido foi {pizza.DefinirSabor(sabor)}");
    Console.WriteLine("Qual o tamanho da pizza pequena 'P',media 'M', grande 'G'?");
    var tamanho = Console.ReadLine();   
    Console.WriteLine($"O tamanho escolhido foi {pizza.DefinirTamanho(tamanho)}");

    pizzaDao.CriarPizza(pizza);
    Console.WriteLine($"Sua pizza é {pizza}");

}


Console.WriteLine("Fim");