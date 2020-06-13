using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Service
{
    public class Fornecedores
    {

        public static DataTable GetAllFornecedores()
        {
            try
            {
                DataTable dt = new DataTable();

                using (NpgsqlConnection pgsqlConnection = new NpgsqlConnection(Config.cs))
                {

                    // abre a conexão com o PgSQL e define a instrução SQL
                    pgsqlConnection.Open();
                    string cmdSeleciona = "select * from fornecedor order by id";

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
                    string cmdSeleciona = "SELECT last_value+1 FROM fornecedor_id_seq;";

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

        public static bool DeleteFornecedor(int id)
        {
            try
            {
                string query = string.Format("Delete from fornecedor where id = {0};", id);
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

        public static bool NewFornecedor(string nome, string telefone, string email, string morada)
        {
            try
            {
                string query = string.Format("insert into fornecedor(nome, telefone, email, morada) values('{0}', '{1}', '{2}', '{3}');", nome, telefone, email, morada);
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

        public static bool UpdateFornecedor(int id, string nome, string telefone, string email, string morada)
        {
            try
            {
                string query = string.Format("UPDATE fornecedor SET nome = '{0}', telefone = '{1}', email = '{2}', morada = '{3}' where id = {4};", nome, telefone, email, morada, id);
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


        public static DataTable Filter(string nome, string morada)
        {
            try
            {
                StringBuilder build = new StringBuilder();
                build.Append("select * from fornecedor where ");
                if (nome != string.Empty) build.Append(string.Format("UPPER(nome) LIKE UPPER('%{0}%') AND ", nome));
                if (morada != string.Empty) build.Append(string.Format("UPPER(morada) LIKE UPPER('{0}%') AND ", morada));
                if (build.ToString().Substring(build.Length - 4) == "AND ")
                    build.Length -= 4;
                else if (build.ToString().Substring(build.Length - 6) == "where ")
                    build.Length -= 6;
                build.Append("order by id;");
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
