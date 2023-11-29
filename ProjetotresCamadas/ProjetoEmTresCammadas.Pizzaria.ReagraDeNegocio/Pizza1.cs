using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEmTresCammadas.Pizzaria.RegraDeNegocio
{
    public enum TamanhoDePizza
    {
        Pequena = 0, 
        Media = 1,
        Grande = 2

    }

    public class Pizza1
    {
        public string Sabor { get; set; }
        public TamanhoDePizza TamanhoDePizza { get; set; }
        public string Descricao { get; set; }
        public Pizza1()
        {    
        }
        public Pizza1 CriarPizza(string sabor, TamanhoDePizza tamanhoDePizza, string descircao = "")
        {
            Sabor = sabor;
            TamanhoDePizza = tamanhoDePizza;
            if (string.IsNullOrEmpty(descircao))
            {
                Descricao = descircao;
            }
            return this;
        }
    }
}
