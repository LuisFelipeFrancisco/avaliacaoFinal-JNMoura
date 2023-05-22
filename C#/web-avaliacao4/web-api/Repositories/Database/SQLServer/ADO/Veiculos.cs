using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Repositories.Database.SQLServer.ADO
{
    public class Veiculos : IRepository<Models.Veiculo>
    {
        private readonly SqlConnection conn;
        private readonly string chaveCache;

        public Veiculos(String connectionString)
        {
            this.conn = new SqlConnection(connectionString);
            this.chaveCache = "veiculos";
        }
        public List<Models.Veiculo> Get(){
            List<Models.Veiculo> veiculos = (List<Models.Veiculo>)Cache.Get(chaveCache);
            if (veiculos != null)
                return veiculos;

            veiculos = new List<Models.Veiculo>();

            using (conn)
            {
                conn.Open();

                string commadText = "SELECT Id, Marca, Nome, AnoModelo, DataFabricacao, Valor, Opcionais FROM Veiculos";

                using (SqlCommand cmd = new SqlCommand(commadText, conn))
                {
                    
                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Models.Veiculo veiculo = new Models.Veiculo();
                            veiculo.Id = (int)dataReader["Id"];
                            veiculo.Marca = dataReader["Marca"].ToString();
                            veiculo.Nome = dataReader["Nome"].ToString();
                            veiculo.AnoModelo = (int)dataReader["AnoModelo"];
                            veiculo.DataFabricacao = (DateTime)dataReader["DataFabricacao"];
                            veiculo.Valor = (decimal)dataReader["Valor"];
                            veiculo.Opcionais = dataReader["Opcionais"] == DBNull.Value ? null : dataReader["Opcionais"].ToString();

                            veiculos.Add(veiculo);
                        }
                    }
                }
            }
            Cache.Set(chaveCache, veiculos, 15);

            return veiculos;
        }

        public Models.Veiculo GetById(int id)
        {
            List<Models.Veiculo> veiculos = (List<Models.Veiculo>)Cache.Get(chaveCache);

            if (veiculos != null)
                return veiculos.Find(veiculoCache => veiculoCache.Id == id);

            Models.Veiculo veiculo = null;

            using (conn)
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT Id, Marca, Nome, AnoModelo, DataFabricacao, Valor, Opcionais FROM Veiculos WHERE Id = @Id";
                    cmd.Parameters.Add(new SqlParameter("@Id", System.Data.SqlDbType.Int)).Value = id;

                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            veiculo = new Models.Veiculo();
                            veiculo.Id = (int)dataReader["Id"];
                            veiculo.Marca = dataReader["Marca"].ToString();
                            veiculo.Nome = dataReader["Nome"].ToString();
                            veiculo.AnoModelo = (int)dataReader["AnoModelo"];
                            veiculo.DataFabricacao = (DateTime)dataReader["DataFabricacao"];
                            veiculo.Valor = (decimal)dataReader["Valor"];
                            veiculo.Opcionais = dataReader["Opcionais"] == DBNull.Value ? null : dataReader["Opcionais"].ToString();
                        }
                    }
                }
            }
            return veiculo;
        }

        public void Add(Models.Veiculo veiculo)
        {
            using (conn)
            {
                conn.Open();
                string commadText = "INSERT INTO Veiculos (Marca, Nome, AnoModelo, DataFabricacao, Valor, Opcionais) VALUES (@Marca, @Nome, @AnoModelo, @DataFabricacao, @Valor, @Opcionais); select convert (int, @@identity) as Id;";

                using (SqlCommand cmd = new SqlCommand(commadText,conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@Marca", System.Data.SqlDbType.VarChar)).Value = veiculo.Marca;
                    cmd.Parameters.Add(new SqlParameter("@Nome", System.Data.SqlDbType.VarChar)).Value = veiculo.Nome;
                    cmd.Parameters.Add(new SqlParameter("@AnoModelo", System.Data.SqlDbType.Int)).Value = veiculo.AnoModelo;
                    cmd.Parameters.Add(new SqlParameter("@DataFabricacao", System.Data.SqlDbType.DateTime)).Value = veiculo.DataFabricacao;
                    cmd.Parameters.Add(new SqlParameter("@Valor", System.Data.SqlDbType.Decimal)).Value = veiculo.Valor;
                    if (veiculo.Opcionais == null)
                        cmd.Parameters.Add(new SqlParameter("@Opcionais", System.Data.SqlDbType.VarChar)).Value = DBNull.Value;
                    else
                        cmd.Parameters.Add(new SqlParameter("@Opcionais", System.Data.SqlDbType.VarChar)).Value = veiculo.Opcionais;

                    veiculo.Id = (int)cmd.ExecuteScalar();
                }
            }
            Cache.Remove(chaveCache);
        }

        public int Update(int id, Models.Veiculo veiculo)
        {
            int linhasAfetadas = 0;

            using (conn)
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "UPDATE Veiculos SET Marca = @Marca, Nome = @Nome, AnoModelo = @AnoModelo, DataFabricacao = @DataFabricacao, Valor = @Valor, Opcionais = @Opcionais WHERE Id = @Id";

                    cmd.Parameters.Add(new SqlParameter("@Id", System.Data.SqlDbType.Int)).Value = id;
                    cmd.Parameters.Add(new SqlParameter("@Marca", System.Data.SqlDbType.VarChar)).Value = veiculo.Marca;
                    cmd.Parameters.Add(new SqlParameter("@Nome", System.Data.SqlDbType.VarChar)).Value = veiculo.Nome;
                    cmd.Parameters.Add(new SqlParameter("@AnoModelo", System.Data.SqlDbType.Int)).Value = veiculo.AnoModelo;
                    cmd.Parameters.Add(new SqlParameter("@DataFabricacao", System.Data.SqlDbType.DateTime)).Value = veiculo.DataFabricacao;
                    cmd.Parameters.Add(new SqlParameter("@Valor", System.Data.SqlDbType.Decimal)).Value = veiculo.Valor;
                    if (veiculo.Opcionais == null)
                        cmd.Parameters.Add(new SqlParameter("@Opcionais", System.Data.SqlDbType.VarChar)).Value = DBNull.Value;
                    else
                        cmd.Parameters.Add(new SqlParameter("@Opcionais", System.Data.SqlDbType.VarChar)).Value = veiculo.Opcionais;

                    linhasAfetadas = cmd.ExecuteNonQuery();                    
                }
            }
            Cache.Remove(chaveCache);

            return linhasAfetadas;
        }

        public int Delete(int id)
        {
            int linhasAfetadas = 0;

            using (conn)
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "DELETE FROM Veiculos WHERE Id = @Id";
                    cmd.Parameters.Add(new SqlParameter("@Id", System.Data.SqlDbType.Int)).Value = id;

                    linhasAfetadas = cmd.ExecuteNonQuery();
                }
            }
            Cache.Remove(chaveCache);

            return linhasAfetadas;
        }
    } 
}
