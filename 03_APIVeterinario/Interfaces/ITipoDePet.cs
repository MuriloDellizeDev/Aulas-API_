using APIVeterinario.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIVeterinario.Interfaces
{
    interface ITipoDePet
    {
        //Retorno NomeDoMetodo(Argumento);

        TipoDePet Cadastrar(TipoDePet t);

        List<TipoDePet> LerTodos();

        TipoDePet BuscarPorId(int id);

        TipoDePet Alterar(TipoDePet t);

        TipoDePet Excluir(TipoDePet t);

    }
}
