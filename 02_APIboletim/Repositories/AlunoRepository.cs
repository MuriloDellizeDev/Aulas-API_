using APIboletim.Context;
using APIboletim.Domains;
using APIboletim.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APIboletim.Repositories
{
    public class AlunoRepository : IAluno
    {

        // Chamammos a classe de conexão do banco

        BoletimContext conexao = new BoletimContext();

        //Chamamos o objeto que poderá receber e executar os comando do banco

        SqlCommand cmd = new SqlCommand();


        public Aluno Alterar(int id, Aluno a)
        {
            cmd.Connection = conexao.Conectar();

            //ATENÇÃO AO ESPAÇO NECESSARIO NO FINAL DO "SET"
            cmd.CommandText = "UPDATE Aluno SET " +
                "Nome = @nome, " +
                "Ra = @ra, " +   
                "Idade = @idade WHERE IdAluno = @id ";
            cmd.Parameters.AddWithValue("@nome", a.Nome);
            cmd.Parameters.AddWithValue("@Ra", a.RA);
            cmd.Parameters.AddWithValue("@Idade", a.Idade);

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();
            return a;
        }

        public Aluno BuscarPoId(int id)
        {
            
                // 3 -  Conecto com o banco
                cmd.Connection = conexao.Conectar();

                // 4 - Preparo minha Query 
                cmd.CommandText = "SELECT * FROM Aluno WHERE IdAluno = @id";
                cmd.Parameters.AddWithValue("@id", id);

                // 5 - Executo o comando para ler
                SqlDataReader dados = cmd.ExecuteReader();

                // 6 - Crio uma lista para exibir meus cadastros
                Aluno aluno = new Aluno();

                while (dados.Read())
                {
                    // 7 - Jogamos os dados lidos no banco no objeto Aluno
                    aluno.IdAluno = Convert.ToInt32(dados.GetValue(0));
                    aluno.Nome = dados.GetValue(1).ToString();
                    aluno.RA = dados.GetValue(2).ToString();
                    aluno.Idade = Int32.Parse(dados.GetValue(3).ToString());
                }

                // 8 - Desconectar
                conexao.Desconectar();

                return aluno;
            

        }

        public Aluno Cadastrar(Aluno a)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText =
                "INSERT INTO Aluno (Nome, RA, Idade) " +
                "VALUES" +
                "(@nome, @Ra, @idade)";
            cmd.Parameters.AddWithValue("@nome", a.Nome);
            cmd.Parameters.AddWithValue("@ra", a.RA);
            cmd.Parameters.AddWithValue("@idade", a.Idade);

            // Será este comando o responsável por injetar os dados no banco efetivamente
            cmd.ExecuteNonQuery();

            conexao.Desconectar();


            return a;
        }

        public void Excluir(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "DELETE FROM Aluno WHERE IdAluno = @id";
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();



            conexao.Desconectar();
        }

        public List<Aluno> LerTodos()
        {
            //Abrir conexão
            cmd.Connection = conexao.Conectar();


            //Preparar a query (Consulta)
            cmd.CommandText = "SELECT * FROM Aluno";

            SqlDataReader dados = cmd.ExecuteReader();

            //Criamos a lista para guardar os alunos
            List<Aluno> alunos = new List<Aluno>();

            while (dados.Read())
            {
                alunos.Add(
                    new Aluno()
                    {
                        IdAluno = Convert.ToInt32(dados.GetValue(0)),
                        Nome = dados.GetValue(1).ToString(),
                        RA = dados.GetValue(2).ToString(),
                        Idade = Convert.ToInt32(dados.GetValue(3))

                    }
                );
            }

            //Fechar conexão
            conexao.Desconectar();

            return alunos;
        }
    }
}
