using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Service
{
    public class Veiculos
    {
        public static DataTable GetAllVeiculos()
        {
            try
            {
                var cs = "Server=localhost;Database=oficina2;User Id=postgres;Password=1234";
                DataTable dt = new DataTable();

                using (NpgsqlConnection pgsqlConnection = new NpgsqlConnection(cs))
                {

                    // abre a conexão com o PgSQL e define a instrução SQL
                    pgsqlConnection.Open();
                    string cmdSeleciona = 
                    "select matricula , marca , modelo , ano , cli.Nome as Cliente from veiculo "+
                    "inner join Cliente cli on veiculo.cliente_id = cli.id;";

                    using (NpgsqlDataAdapter Adpt = new NpgsqlDataAdapter(cmdSeleciona, pgsqlConnection))
                    {
                        Adpt.Fill(dt);
                    }
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

    }
}
