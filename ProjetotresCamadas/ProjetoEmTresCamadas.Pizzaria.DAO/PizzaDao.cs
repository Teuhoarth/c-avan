using Microsoft.Data.Sqlite;
using ProjetoEmTresCammadas.Pizzaria.RegraDeNegocio;

namespace ProjetoEmTresCamadas.Pizzaria.DAO;

public class PizzaDao
{
    public const string ConnectionString = "Data Source=Pizza.db";

    public PizzaDao() 
    {
        CriarBancoDeDados();
    }


    public void CriarBancoDeDados()
    {
        using (var sqlConnection = new SqliteConnection(ConnectionString))
        {
            sqlConnection.Open();
            using(var cmd = sqlConnection.CreateCommand())
            {
                cmd.CommandText = @"CREATE TABLE IF NOT EXISTS TB_PIZZA
                (
                    ID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Sabor VARCHA(50) not null,              
                    Descricao VARCHAR(100),
                    TAMANHODAPIZZA INT
                )";
                cmd.ExecuteNonQuery();
            }
        }
    }

    public void CriarPizza(Pizza1 pizzaVo)
    {
        using (var sqlConnection = new SqliteConnection(ConnectionString))
        {
            sqlConnection.Open();

            using (var command = sqlConnection.CreateCommand())
            {
                command.CommandText = @"
                INSERT INTO TB_PIZZA (Sabor, Descricao, TAMANHODAPIZZA)
                VALUES (@Sabor, @Descricao, @TAMANHODAPIZZA)";

                command.Parameters.AddWithValue("@Sabor", pizzaVo.Sabor);
                command.Parameters.AddWithValue("@Descricao", pizzaVo.Descricao);
                command.Parameters.AddWithValue("@TAMANHODAPIZZA", (int)pizzaVo.TamanhoDePizza);

                command.ExecuteNonQuery();
            }
        }
    }

    public List<Pizza1> ObterPizzas()
    {
        List<Pizza1> pizzas = new List<Pizza1>();
        using(var sqlConnection = new SqliteConnection(ConnectionString))
        {
            sqlConnection.Open();
            using(var command = sqlConnection.CreateCommand())
            {
                command.CommandText = @"SELECT * FROM TB_PIZZA";
                using(var reader = command.ExecuteReader()) 
                {
                    while (reader.Read())
                    {
                        Pizza1 pizza = new Pizza1
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Sabor = reader["Sabor"].ToString(),
                            Descricao = reader["Descricao"].ToString(),
                            TamanhoDePizza = (TamanhoDePizza)Convert.ToInt32(reader["TAMANHODAPIZZA"])
                        };
                        pizzas.Add(pizza);
                    }
                }
            }
        }
        return pizzas;
    }


}


    /*
         using (SqliteCommand command = new SqliteCommand() { Connection = connection })
         {
             command.CommandText =
                 @"CREATE TABLE IF NOT EXISTS Pizza
                  (
                     Id INTEGER PRIMARY KEY AUTOINCREMENT,
                     Sabor TEXT,
                     Descricao TEXT,
                     TamanhoDePizza INTEGER

                  )";
             command.ExecuteNonQuery();
         }
     }*/


