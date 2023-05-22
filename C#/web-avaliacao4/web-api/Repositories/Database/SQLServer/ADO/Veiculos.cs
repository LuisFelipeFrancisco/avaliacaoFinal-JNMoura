using Models;
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

        public void Add(Veiculo entity)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Veiculo entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    } 
}
/*  
Id (int) (chave primária e auto numeração), 
Marca (50), 
Nome (100), 
AnoModelo (Int), 
DataFabricacao (Date), 
Valor (decimal-8,2), 
Opcionais (500) não obrigatório.
 */