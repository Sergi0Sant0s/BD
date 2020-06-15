using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Service
{
    public class EstadoReparacao
    {
        public static DataTable GetAllStates()
        {
            try
            {
                DataTable dt = new DataTable();

                using (NpgsqlConnection pgsqlConnection = new NpgsqlConnection(Config.cs))
                {

                    // abre a conexão com o PgSQL e define a instrução SQL
                    pgsqlConnection.Open();
                    string cmdSeleciona = "select id, nome from estado_reparacao order by id";

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
                    string cmdSeleciona = "SELECT last_value+1 FROM estado_reparacao_id_seq;";

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

        public static bool NewStates(string nome)
        {
            try
            {
                string query = string.Format("insert into estado_reparacao(nome) values('{0}');", nome);
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

        public static bool UpdateStates(int id, string nome)
        {
            try
            {
                string query = string.Format("UPDATE estado_reparacao SET nome = '{0}' where id = {1};", nome, id);
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

        public static bool DeleteStates(int id)
        {
            try
            {
                string query = string.Format("Delete from estado_reparacao where id = {0});", id);
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
