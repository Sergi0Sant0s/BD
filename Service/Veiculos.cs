﻿using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text;

namespace Service
{
    public class Veiculos
    {
        public static DataTable GetAllVeiculos()
        {
            try
            {
                DataTable dt = new DataTable();

                using (NpgsqlConnection pgsqlConnection = new NpgsqlConnection(Config.cs))
                {

                    // abre a conexão com o PgSQL e define a instrução SQL
                    pgsqlConnection.Open();
                    string cmdSeleciona =
                    "select matricula , marca , modelo , ano , cli.Nome as Cliente from veiculo " +
                    "inner join Cliente cli on veiculo.cliente_id = cli.id order by matricula;";

                    using (NpgsqlDataAdapter Adpt = new NpgsqlDataAdapter(cmdSeleciona, pgsqlConnection))
                    {
                        Adpt.Fill(dt);
                    }
                    pgsqlConnection.Close();
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
                    string cmdSeleciona = "select distinct marca from veiculo";

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
                    string cmdSeleciona = "select distinct modelo from veiculo";

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

        public static DataTable GetAllYears()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ano");
                dt.Columns[0].DataType = typeof(string);

                using (NpgsqlConnection pgsqlConnection = new NpgsqlConnection(Config.cs))
                {

                    // abre a conexão com o PgSQL e define a instrução SQL
                    pgsqlConnection.Open();
                    string cmdSeleciona = "select distinct ano from veiculo";

                    using (NpgsqlDataAdapter Adpt = new NpgsqlDataAdapter(cmdSeleciona, pgsqlConnection))
                    {
                        Adpt.Fill(dt);
                    }
                }
                DataTable dtAux = new DataTable();
                dtAux.Columns.Add("ano");
                dtAux.Columns[0].DataType = typeof(string);
                DataRow toInsert = dtAux.NewRow();
                toInsert["ano"] = "Todos";
                dtAux.Rows.Add(toInsert);
                foreach (DataRow row in dt.Rows)
                {
                    DataRow aux = dtAux.NewRow();
                    aux["ano"] = row["ano"].ToString();
                    dtAux.Rows.Add(aux);
                }
                return dtAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool DeleteVeiculo(string matricula)
        {
            try
            {
                string query = string.Format("Delete from veiculo where matricula = UPPER('{0}');",matricula);
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

        public static bool NewVeiculo(string matricula, string marca, string modelo, int ano, int client_id)
        {
            try
            {
                string query = string.Format("insert into veiculo(matricula,marca,modelo,ano,cliente_id) values(UPPER('{0}'), '{1}', '{2}', {3}, '{4}');", matricula, marca, modelo, ano, client_id);
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

        public static bool UpdateVeiculo(string matricula, string marca, string modelo, int cliente, int ano)
        {
            try
            {
                string query = string.Format("Update veiculo set marca = '{1}', modelo = '{2}', ano = {3}, cliente_id = {4} where UPPER(matricula) = UPPER('{0}');", matricula,marca,modelo,ano,cliente);
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

        public static DataTable Filter(string matricula, string marca, string modelo, string cliente, string ano)
        {
            try
            {
                StringBuilder build = new StringBuilder();
                build.Append("select matricula , marca , modelo , ano , cli.Nome as Cliente from veiculo ");
                build.Append("inner join Cliente cli on veiculo.cliente_id = cli.id where ");
                if (matricula != string.Empty) build.Append(string.Format("matricula LIKE UPPER('{0}%') AND ", matricula));
                if (marca != string.Empty) build.Append(string.Format("marca = '{0}' AND ", marca));
                if (modelo != string.Empty) build.Append(string.Format("modelo = '{0}' AND ", modelo));
                if (cliente != string.Empty) build.Append(string.Format("UPPER(cli.nome) LIKE UPPER('%{0}%') AND ", cliente));
                if (ano != string.Empty) build.Append(string.Format("ano = {0}", Convert.ToInt32(ano)));
                if (build.ToString().Substring(build.Length - 4) == "AND ")
                    build.Length -= 4;
                else if(build.ToString().Substring(build.Length - 6) == "where ")
                    build.Length -= 6;
                build.Append(" order by matricula;");
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
    }
}
