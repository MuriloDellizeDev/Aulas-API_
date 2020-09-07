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
    public class TipoDePetRepository : ITipoDePet
    {



        VeterinarioContext conexao = new VeterinarioContext();

        SqlCommand cmd = new SqlCommand();




        /*LerTodos é responsavel por fazer a leitura e retornar 
        todas as TipodDePet já cadastradas no banco de dados.*/
        public List<TipoDePet> LerTodos()
        {
            //Abrir conexão
            cmd.Connection = conexao.Conectar();


            //Preparar a Query (consulta)
            cmd.CommandText = "SELECT * FROM TipoDePet";

            SqlDataReader dados = cmd.ExecuteReader();


            List<TipoDePet> tipos = new List<TipoDePet>();

            while (dados.Read())
            {

                tipos.Add(

                    new TipoDePet()
                    {
                        IdTipoDePet = Convert.ToInt32(dados.GetValue(0)),
                        Descricao = dados.GetValue(1).ToString()
                    }

                    ); 

            }


            //Fechar conexão
            conexao.Desconectar();


            return tipos;
        }




        /*BuscarPorId é responsavel por fazer a leitura e retornar 
       uma TipoDePet especifica de acordo com o id especificado.*/
        public TipoDePet BuscarPorId(int id)
        {

            //Abrir conexão
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM TipoDePet WHERE IdTipoDePet = @id";
            
            
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dados = cmd.ExecuteReader();

            TipoDePet t = new TipoDePet();

            while (dados.Read())
            {

                t.IdTipoDePet = Convert.ToInt32(dados.GetValue(0));
                t.Descricao = dados.GetValue(1).ToString();

            }

            //Fechar conexão
            conexao.Desconectar();

            return t;



        }




        /*Cadastrar é responsavel por cadastrar uma TipoDePet no banco de dados.*/
        public TipoDePet Cadastrar(TipoDePet t)
        {

                //Abrir conexão
                cmd.Connection = conexao.Conectar();

                cmd.CommandText =
                    "INSERT INTO TipoDePet (Descricao) " +
                    "VALUES" +
                    "(@descricao)";
                cmd.Parameters.AddWithValue("@descricao", t.Descricao);
              

                // Será este comando o responsável por injetar os dados no banco efetivamente
                cmd.ExecuteNonQuery();

                //Fechar conexão
                conexao.Desconectar();

                return t;
            }


        /*Excluir é responsavel por excluir uma TipoDePet do banco de dados.*/
        public void Excluir(int id)
        {

            //Abrir conexão
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "DELETE FROM TipoDePet WHERE IdTipoDePet = @id";
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            //Fechar conexão
            conexao.Desconectar();
        }


        /*Alterar é responsavel por alterar uma TipoDePet já existente no banco de dados.*/
        public TipoDePet Alterar(int id, TipoDePet t)
        {

            //Abrir conexão
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "UPDATE TipoDePet SET " +
                "Descricao = @descricao WHERE IdTipoDePet = @id ";

            cmd.Parameters.AddWithValue("@descricao", t.Descricao);

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            //Fechar conexão
            conexao.Desconectar();

            return t;
        }

        

        

        

        
    }
}
