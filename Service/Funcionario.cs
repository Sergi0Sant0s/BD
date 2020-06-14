using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Service
{
    public class Funcionario
    {
        public static DataTable GetAllFuncionarios()
        {
            try
            {
                DataTable dt = new DataTable();

                using (NpgsqlConnection pgsqlConnection = new NpgsqlConnection(Config.cs))
                {

                    // abre a conexão com o PgSQL e define a instrução SQL
                    pgsqlConnection.Open();
                    string cmdSeleciona = "select cli.id,cli.nome,cli.telemovel,cli.email,cli.morada,cli.created_at,sec.nome as seccao from cliente cli "
                    + "inner join funcionario fun on cli.id = fun.id "
                    + "inner join seccao sec on fun.id_seccao = sec.id order by cli.id";

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

        public static bool DeleteFuncionario(int id)
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
                    foreach(var com in commands)
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

        public static bool NewFuncionario(string nome, string telemovel, string email, string morada, DateTime created_at,string idSeccao)
        {
            NpgsqlTransaction transact = null;
            NpgsqlConnection pgsqlConnection = new NpgsqlConnection(Config.cs);
            pgsqlConnection.Open();
            List<NpgsqlCommand> commands = new List<NpgsqlCommand>();
            string query1 = string.Format("insert into cliente(nome, telemovel, email, morada, created_at) values('{0}', '{1}', '{2}', '{3}', '{4}');", nome, telemovel, email, morada, string.Format("{0:dd/MM/yyyy}", created_at));
            string query2 = string.Format("insert into funcionario(id,id_seccao) values({0},{1});",Clients.GetNewId(), idSeccao);

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

        public static bool UpdateFuncionario(int id, string nome, string telemovel, string email, string morada, string idSeccao)
        {
            NpgsqlTransaction transact = null;
            NpgsqlConnection pgsqlConnection = new NpgsqlConnection(Config.cs);
            pgsqlConnection.Open();
            List<NpgsqlCommand> commands = new List<NpgsqlCommand>();
            string query1 = string.Format("UPDATE cliente SET nome = '{0}', telemovel = '{1}', email = '{2}', morada = '{3}' where id = {4};", nome, telemovel, email, morada, id);
            string query2 = string.Format("UPDATE funcionario SET id_seccao = {0} where id = {1}", idSeccao, id);

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
                catch (NpgsqlException)
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public static bool CheckIfExists(int id)
        {
            try
            {
                DataTable dt = new DataTable();

                using (NpgsqlConnection pgsqlConnection = new NpgsqlConnection(Config.cs))
                {

                    // abre a conexão com o PgSQL e define a instrução SQL
                    pgsqlConnection.Open();
                    string cmdSeleciona = string.Format("select * from funcionario where id = {0};",id);

                    using (NpgsqlDataAdapter Adpt = new NpgsqlDataAdapter(cmdSeleciona, pgsqlConnection))
                    {
                        Adpt.Fill(dt);
                    }
                }
                if (dt.Rows.Count == 1)
                    return true;
                else return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static DataTable Filter(string nome, string telemovel, string morada, string seccao)
        {
            try
            {
                StringBuilder build = new StringBuilder();
                build.Append("select cli.id,cli.nome,cli.telemovel,cli.email,cli.morada,cli.created_at,sec.nome as seccao from cliente cli ");
                build.Append("inner join funcionario func on cli.id = func.id ");
                build.Append("inner join seccao sec on func.id_seccao = sec.id where ");
                if (nome != string.Empty) build.Append(string.Format("UPPER(cli.nome) LIKE UPPER('%{0}%') AND ", nome));
                if (telemovel != string.Empty) build.Append(string.Format("UPPER(cli.telemovel) LIKE UPPER('{0}%') AND ", telemovel));
                if (morada != string.Empty) build.Append(string.Format("UPPER(cli.morada) LIKE UPPER('%{0}%') AND ", morada));
                if (seccao != string.Empty) build.Append(string.Format("sec.nome = '{0}' ", seccao));
                if (build.ToString().Substring(build.Length - 4) == "AND ")
                    build.Length -= 4;
                else if (build.ToString().Substring(build.Length - 6) == "where ")
                    build.Length -= 6;
                build.Append("order by cli.id;");
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
    }
}
