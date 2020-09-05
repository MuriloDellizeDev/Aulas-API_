using APIVeterinario.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIVeterinario.Interfaces
{
    interface IRaca
    {

        Raca Cadastrar(Raca r);

        List<Raca> LerTodos();

        Raca BuscarPorId(int id);

        Raca Alterar(Raca r);

        Raca Excluir(Raca r);



    }
}
