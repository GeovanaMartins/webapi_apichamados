using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto01_ApiChamados.Enumeracoes
{
    public enum ResultadoChamado
    {
        CHAMADO_OK, //se for incluido 
        RESPOSTA_OK, //se a resposta for incluida com sucesso
        DELETADO_OK, //se for deletado com sucesso
        RESPOSTA_JA_REALIZADA
    }
}