using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Service
{
    public class Clients
    {
        public static DataTable GetAllClientes()
        {
            try
            {
                DataTable dt = new DataTable();

                using (NpgsqlConnection pgsqlConnection = new NpgsqlConnection(Config.cs))
                {

                    // abre a conexão com o PgSQL e define a instrução SQL
                    pgsqlConnection.Open();
                    string cmdSeleciona = "select * from cliente order by id";

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

        public static int GetNewId()
        {
            try
            {
                DataTable dt = new DataTable();

                using (NpgsqlConnection pgsqlConnection = new NpgsqlConnection(Config.cs))
                {

                    // abre a conexão com o PgSQL e define a instrução SQL
                    pgsqlConnection.Open();
                    string cmdSeleciona = "SELECT last_value+1 FROM cliente_id_seq;";

                    using (NpgsqlDataAdapter Adpt = new NpgsqlDataAdapter(cmdSeleciona, pgsqlConnection))
                    {
                        Adpt.Fill(dt);
                    }
                }
                return Convert.ToInt32(dt.Rows[0].ItemArray[0]);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static bool DeleteCliente(int id)
        {
            try
            {
                if (!Funcionario.CheckIfExists(id))
                {
                    string query = string.Format("Delete from cliente where id = {0};", id);
                    NpgsqlConnection pgsqlConnection = new NpgsqlConnection(Config.cs);
                    pgsqlConnection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand(query, pgsqlConnection);
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    return reader.RecordsAffected != 0 ? true : false;
                }
                else
                {
                    NpgsqlTransaction transact = null;
                    NpgsqlConnection pgsqlConnection = new NpgsqlConnection(Config.cs);
                    pgsqlConnection.Open();
                    List<NpgsqlCommand> commands = new List<NpgsqlCommand>();
                    string query1 = string.Format("Delete from cliente where id = {0};", id);
                    string query2 = string.Format("Delete from funcionario where id = {0};", id);

                    using (var transaction = pgsqlConnection.BeginTransaction(IsolationLevel.Serializable))
                    {
                        commands.Add(new NpgsqlCommand(query1, pgsqlConnection, transact) { CommandTimeout = 120 });
                        commands.Add(new NpgsqlCommand(query2, pgsqlConnection, transact) { CommandTimeout = 120 });

                        try
                        {
                            foreach (var com in commands)
                                com.ExecuteNonQuery();
                            transaction.Commit();
                            return true;
                        }
                        catch (NpgsqlException ex)
                        {
                            transaction.Rollback();
                            return false;
                        }
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool NewCliente(string nome,string telemovel,string email,string morada,DateTime created_at)
        {
            try
            {
                string query = string.Format("insert into cliente(nome, telemovel, email, morada, created_at) values('{0}', '{1}', '{2}', '{3}', '{4}');", nome,telemovel,email,morada,string.Format("{0:dd/MM/yyyy}",created_at));
                NpgsqlConnection pgsqlConnection = new NpgsqlConnection(Config.cs);
                pgsqlConnection.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, pgsqlConnection);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                return reader.RecordsAffected != 0 ? true : false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool UpdateCliente(int id, string nome, string telemovel, string email, string morada)
        {
            try
            {
                string query = string.Format("UPDATE cliente SET nome = '{0}', telemovel = '{1}', email = '{2}', morada = '{3}' where id = {4};", nome, telemovel, email, morada, id);
                NpgsqlConnection pgsqlConnection = new NpgsqlConnection(Config.cs);
                pgsqlConnection.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, pgsqlConnection);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                return reader.RecordsAffected != 0 ? true : false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
