using APIboletim.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIboletim.Interfaces
{
    interface IAluno
    {

        Aluno Cadastrar(Aluno a);
        List<Aluno> LerTodos();

        Aluno BuscarPoId(int id);

        Aluno Alterar(int id, Aluno a);

        void Excluir(int id);


    }
}
