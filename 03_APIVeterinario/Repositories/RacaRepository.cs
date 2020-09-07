using APIVeterinario.Context;
using APIVeterinario.Domains;
using APIVeterinario.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APIVeterinario.Repositories
{

    //Repositorie é reponsavel por fazer a comunicação com o banco de dados
    public class RacaRepository : IRaca
    {



        VeterinarioContext conexao = new VeterinarioContext();

        SqlCommand cmd = new SqlCommand();



        
        /*LerTodos é responsavel por fazer a leitura e retornar 
        todas as raças já cadastradas no banco de dados.*/
        public List<Raca> LerTodos()
        {

            //Abrir conexão
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM Raca";

            SqlDataReader dados = cmd.ExecuteReader();

            List<Raca> racas = new List<Raca>();

            while (dados.Read())
            {
                racas.Add(
                    new Raca()
                    {
                        IdRaca = Convert.ToInt32(dados.GetValue(0)),
                        Descricao = dados.GetValue(1).ToString(),
                        IdTipoDePet = Convert.ToInt32(dados.GetValue(2))
                    }
                );
            }

            //Fechar conexão
            conexao.Desconectar();

            return racas;
        }

       
        /*BuscarPorId é responsavel por fazer a leitura e retornar 
        uma raça especifica de acordo com o id especificado.*/
        public Raca BuscarPorId(int id)
        {

            //Abrir conexão
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM Raca WHERE IdRaca = @id";

            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dados = cmd.ExecuteReader();

            Raca r = new Raca();

            while (dados.Read())
            {

                r.IdRaca = Convert.ToInt32(dados.GetValue(0));
                r.Descricao = dados.GetValue(1).ToString();
                r.IdTipoDePet = Convert.ToInt32(dados.GetValue(2));

            }

            //Fechar conexão
            conexao.Desconectar();

            return r;


        }

        /*Cadastrar é responsavel por cadastrar uma Raça no banco de dados.*/
        public Raca Cadastrar(Raca r)
        {

            //Abrir conexão
            cmd.Connection = conexao.Conectar();

            cmd.CommandText =
                "INSERT INTO Raca (Descricao, IdTipoDePet) " +
                "VALUES" +
                "(@descricao, @idTipoDePet) ";
            cmd.Parameters.AddWithValue("@descricao", r.Descricao);
            cmd.Parameters.AddWithValue("@idTipoDePet", r.IdTipoDePet);

            
            cmd.ExecuteNonQuery();

            //Fechar conexão
            conexao.Desconectar();

            return r; 
        }

        /*Excluir é responsavel por excluir uma Raça do banco de dados.*/
        public void Excluir(int id)
        {

            //Abrir conexão
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "DELETE FROM Raca WHERE IdRaca = @id";
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            //Fechar conexão
            conexao.Desconectar();
        }

        /*Alterar é responsavel por alterar uma Raça já existente no banco de dados.*/
        public Raca Alterar(int id, Raca r)
        {

            //Abrir conexão
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "UPDATE Raca SET " +
                "Descricao = @descricao, " +
                "IdTipoDePet = @idTipoDePet WHERE IdRaca = @id ";

            cmd.Parameters.AddWithValue("@descricao", r.Descricao);
            cmd.Parameters.AddWithValue("@idTipoDePet", r.IdTipoDePet);

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            //Fechar conexão
            conexao.Desconectar();

            return r;

        }  
    }
}
