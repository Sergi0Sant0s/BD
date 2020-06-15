using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text;

namespace Service
{
    public class Stock
    {
        public static DataTable GetAllStocks(int id)
        {
            try
            {
                DataTable dt = new DataTable();

                using (NpgsqlConnection pgsqlConnection = new NpgsqlConnection(Config.cs))
                {

                    // abre a conexão com o PgSQL e define a instrução SQL
                    pgsqlConnection.Open();
                    string cmdSeleciona =
                    string.Format("select sto.id,sto.quantidade,forn.nome as fornecedor, sto.custo_venda, sto.custo_compra, sto.id_fornecedor from stock sto "
                    + "inner join fornecedor forn on sto.id_fornecedor = forn.id where id_peca = {0} order by id;",id);

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
                    string cmdSeleciona = "SELECT last_value+1 FROM stock_id_seq;";

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

        public static bool DeleteStock(int id)
        {
            NpgsqlTransaction transact = null;
            NpgsqlConnection pgsqlConnection = new NpgsqlConnection(Config.cs);
            pgsqlConnection.Open();
            List<NpgsqlCommand> commands = new List<NpgsqlCommand>();
            string query1 = string.Format("delete from stock",id);
            string query2 = string.Format("delete from stock_history",id);

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

        public static bool NewStock(int id_peca,int quantidade,int id_fornecedor, double custo_venda,double custo_compra)
        {
            NpgsqlTransaction transact = null;
            NpgsqlConnection pgsqlConnection = new NpgsqlConnection(Config.cs);
            pgsqlConnection.Open();
            List<NpgsqlCommand> commands = new List<NpgsqlCommand>();
            string query1 = string.Format("insert into stock(id_peca,quantidade,id_fornecedor,custo_venda,custo_compra) values('{0}', '{1}', '{2}', '{3}', '{4}');", id_peca,quantidade,id_fornecedor,custo_venda,custo_compra);
            string query2 = string.Format("insert into stock_history(id_peca,quantidade,id_fornecedor,custo_venda,custo_compra) values('{0}', '{1}', '{2}', '{3}', '{4}');", id_peca, quantidade, id_fornecedor, custo_venda, custo_compra);

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

        public static bool UpdateStock(int id, int id_fornecedor, string custo_venda, string custo_compra)
        {
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ".";
            NpgsqlTransaction transact = null;
            NpgsqlConnection pgsqlConnection = new NpgsqlConnection(Config.cs);
            pgsqlConnection.Open();
            List<NpgsqlCommand> commands = new List<NpgsqlCommand>();
            string query1 = string.Format("update stock set id_fornecedor = {0}, custo_venda = {1}, custo_compra = {2} where id = {3};", id_fornecedor, double.Parse(custo_venda.ToString(nfi), CultureInfo.CurrentCulture), double.Parse(custo_compra.ToString(nfi), CultureInfo.CurrentCulture), id);
            string query2 = string.Format("update stock_history set id_fornecedor = {0}, custo_venda = {1}, custo_compra = {2} where id = {3};", id_fornecedor, double.Parse(custo_venda.ToString(nfi), CultureInfo.CurrentCulture), double.Parse(custo_compra.ToString(nfi), CultureInfo.CurrentCulture), id);

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

        public static DataTable Filter(int id, int fornecedores)
        {
            try
            {
                StringBuilder build = new StringBuilder();
                build.Append("select sto.id,sto.quantidade,forn.nome as fornecedor, sto.custo_venda, sto.custo_compra, sto.id_fornecedor from stock sto ");
                build.Append("inner join fornecedor forn on sto.id_fornecedor = forn.id where ");
                if (fornecedores != -1) build.Append(string.Format("id_fornecedor = {0} AND ", fornecedores));
                build.Append(string.Format("id_peca = {0} order by id;", id));
                //

                DataTable dt = new DataTable();

                using (NpgsqlConnection pgsqlConnection = new NpgsqlConnection(Config.cs))
                {

                    // abre a conexão com o PgSQL e define a instrução SQL
                    pgsqlConnection.Open();

                    using (NpgsqlDataAdapter Adpt = new NpgsqlDataAdapter(build.ToString(), pgsqlConnection))
                    {
                        Adpt.Fill(dt);
                    }
                }
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static DataRow GetPecaById(int id)
        {
            try
            {
                DataTable dt = new DataTable();

                using (NpgsqlConnection pgsqlConnection = new NpgsqlConnection(Config.cs))
                {

                    // abre a conexão com o PgSQL e define a instrução SQL
                    pgsqlConnection.Open();
                    string cmdSeleciona = string.Format("select * from peca where id = {0};",id);

                    using (NpgsqlDataAdapter Adpt = new NpgsqlDataAdapter(cmdSeleciona, pgsqlConnection))
                    {
                        Adpt.Fill(dt);
                    }
                }
                return dt.Rows[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetFornecedoresByPecaId(int id)
        {
            try
            {
                DataTable dt = new DataTable();

                using (NpgsqlConnection pgsqlConnection = new NpgsqlConnection(Config.cs))
                {

                    // abre a conexão com o PgSQL e define a instrução SQL
                    pgsqlConnection.Open();
                    StringBuilder build = new StringBuilder();
                    build.Append("select f.id,f.nome from fornecedor f ");
                    build.Append("inner join stock s on f.id = s.id_fornecedor ");
                    build.Append(string.Format("where s.id_peca = {0} ",id));
                    build.Append("order by f.nome");

                    using (NpgsqlDataAdapter Adpt = new NpgsqlDataAdapter(build.ToString(), pgsqlConnection))
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
