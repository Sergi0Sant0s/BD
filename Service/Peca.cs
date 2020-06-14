using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Service
{
    public class Peca
    {
        public static DataTable GetAllPecas()
        {
            try
            {
                DataTable dt = new DataTable();

                using (NpgsqlConnection pgsqlConnection = new NpgsqlConnection(Config.cs))
                {

                    // abre a conexão com o PgSQL e define a instrução SQL
                    pgsqlConnection.Open();
                    string cmdSeleciona =
                    "select * from peca order by id";

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

        public static DataTable GetAllBrands()
        {
            try
            {
                DataTable dt = new DataTable();

                using (NpgsqlConnection pgsqlConnection = new NpgsqlConnection(Config.cs))
                {

                    // abre a conexão com o PgSQL e define a instrução SQL
                    pgsqlConnection.Open();
                    string cmdSeleciona = "select distinct marca from peca";

                    using (NpgsqlDataAdapter Adpt = new NpgsqlDataAdapter(cmdSeleciona, pgsqlConnection))
                    {
                        Adpt.Fill(dt);
                    }
                }
                DataRow toInsert = dt.NewRow();
                toInsert["marca"] = "Todos";
                dt.Rows.InsertAt(toInsert, 0);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetAllModels()
        {
            try
            {
                DataTable dt = new DataTable();

                using (NpgsqlConnection pgsqlConnection = new NpgsqlConnection(Config.cs))
                {

                    // abre a conexão com o PgSQL e define a instrução SQL
                    pgsqlConnection.Open();
                    string cmdSeleciona = "select distinct modelo from peca";

                    using (NpgsqlDataAdapter Adpt = new NpgsqlDataAdapter(cmdSeleciona, pgsqlConnection))
                    {
                        Adpt.Fill(dt);
                    }
                }
                DataRow toInsert = dt.NewRow();
                toInsert["modelo"] = "Todos";
                dt.Rows.InsertAt(toInsert, 0);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool DeletePeca(int id)
        {
            try
            {
                string query = string.Format("Delete from peca where id = {0};", id);
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

        public static bool NewPeca(string nome, string marca, string modelo, string descricao)
        {
            try
            {
                string query = string.Format("insert into peca(nome, marca, modelo, descricao) values('{0}', '{1}', '{2}', '{3}');", nome, marca,modelo,descricao);
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

        public static bool UpdatePeca(int id,string nome, string marca, string modelo, string descricao)
        {
            try
            {
                string query = string.Format("Update peca set nome = '{1}', marca = '{2}', modelo = '{3}', descricao = '{4}' where id = {0};", id, nome, marca, modelo, descricao);
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

        public static DataTable Filter(string nome, string marca, string modelo)
        {
            try
            {
                StringBuilder build = new StringBuilder();
                build.Append("select * from peca where ");
                if (nome != string.Empty) build.Append(string.Format("UPPER(nome) LIKE UPPER('%{0}%') AND ", nome));
                if (marca != string.Empty) build.Append(string.Format("marca = '{0}' AND ", marca));
                if (modelo != string.Empty) build.Append(string.Format("modelo = '{0}' AND ", modelo));
                if (build.ToString().Substring(build.Length - 4) == "AND ")
                    build.Length -= 4;
                else if (build.ToString().Substring(build.Length - 6) == "where ")
                    build.Length -= 6;
                build.Append("order by id;");
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
    }
}
