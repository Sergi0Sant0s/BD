using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Service
{
    public class Services
    {
        public static DataTable GetAllServicos()
        {
            try
            {
                DataTable dt = new DataTable();

                using (NpgsqlConnection pgsqlConnection = new NpgsqlConnection(Config.cs))
                {

                    // abre a conexão com o PgSQL e define a instrução SQL
                    pgsqlConnection.Open();
                    StringBuilder build = new StringBuilder();
                    build.Append("select serv.id, tserv.nome as tservice, func.nome as funcionario, serv.matricula, descricao,descricao_reparacao, state.nome as estado, serv.data_inicio,serv.data_fim, serv.created_at from servico serv ");
                    build.Append("inner join cliente func on func.id = serv.id_funcionario ");
                    build.Append("inner join tipo_servico tserv on tserv.id = serv.id_tiposervico ");
                    build.Append("inner join estado_reparacao state on state.id = serv.id_estado ");
                    build.Append("order by serv.id;");


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

        public static int GetNewId()
        {
            try
            {
                DataTable dt = new DataTable();

                using (NpgsqlConnection pgsqlConnection = new NpgsqlConnection(Config.cs))
                {

                    // abre a conexão com o PgSQL e define a instrução SQL
                    pgsqlConnection.Open();
                    string cmdSeleciona = "SELECT last_value+1 FROM servico_id_seq;";

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

        public static bool NewServico(int tservice,int funcionario, string matricula, string descricao, int estadoId, DateTime created)
        {
            try
            {
                string query = string.Format("insert into servico(id_tiposervico, id_funcionario, matricula, descricao, id_estado, created_at) values({0},{1},'{2}','{3}',{4},{5});", tservice,funcionario,matricula,descricao,estadoId, string.Format("{0:dd/MM/yyyy}", created));
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

        public static bool UpdateServico(int id, string nome)
        {
            try
            {
                string query = string.Format("UPDATE tipo_servico SET descricao = '{0}' where id = {1};", nome, id);
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

        public static bool IniciarServico(int id)
        {
            try
            {
                string query = string.Format("UPDATE servico SET data_inicio = '{0}', id_estado = 2 where id = {1};", string.Format("{0:dd/MM/yyyy}", DateTime.Now), id);
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

        public static bool FinalizarServico(int id)
        {
            try
            {
                string query = string.Format("UPDATE servico SET data_fim = '{0}', id_estado = 3 where id = {1};", string.Format("{0:dd/MM/yyyy}", DateTime.Now), id);
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

        public static DataTable Filter(string matricula, string tipoServico, string estado, string funcionario)
        {
            try
            {
                StringBuilder build = new StringBuilder();
                build.Append("select serv.id, tserv.nome as tservice, func.nome as funcionario, serv.matricula, descricao,descricao_reparacao, state.nome as estado, serv.data_inicio,serv.data_fim, serv.created_at from servico serv ");
                build.Append("inner join cliente func on func.id = serv.id_funcionario ");
                build.Append("inner join tipo_servico tserv on tserv.id = serv.id_tiposervico ");
                build.Append("inner join estado_reparacao state on state.id = serv.id_estado where ");
                //
                if (matricula != string.Empty) build.Append(string.Format("serv.matricula LIKE UPPER('{0}%') AND ", matricula));
                if (tipoServico != string.Empty) build.Append(string.Format("serv.id_tiposervico = {0} AND ", Convert.ToInt32(tipoServico)));
                if (estado != string.Empty) build.Append(string.Format("serv.id_estado = {0} AND ", Convert.ToInt32(estado)));
                if (funcionario != string.Empty) build.Append(string.Format("serv.id_funcionario = {0} AND ", Convert.ToInt32(funcionario)));
                if (build.ToString().Substring(build.Length - 4) == "AND ")
                    build.Length -= 4;
                else if (build.ToString().Substring(build.Length - 6) == "where ")
                    build.Length -= 6;
                build.Append("order by serv.id;");
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
