using Projeto01_ApiChamados.Enumeracoes;
using Projeto01_ApiChamados.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Projeto01_ApiChamados.Dados
{
    public class ChamadosDao
    {
        //Incluir o chamado
        public ResultadoChamado IncluirChamado(Chamado chamado)
        {
            using (var ctx = new ChamadosEntities())
            {
                ctx.TB_Chamados.Add(chamado);
                ctx.SaveChanges();
                return ResultadoChamado.CHAMADO_OK;
            }
        }
        //Alterar e incluir a Resposta
        public ResultadoChamado IncluirResposta(Chamado chamado)
        {
            using (var ctx = new ChamadosEntities())
            {
                var resposta = ctx.TB_Chamados.FirstOrDefault(p => p.Resposta.Equals(chamado.Resposta));
                if(resposta != null)
                {
                    return ResultadoChamado.RESPOSTA_JA_REALIZADA;
                }

                ctx.Entry<Chamado>(chamado).State = EntityState.Modified;
                ctx.SaveChanges();
                return ResultadoChamado.RESPOSTA_OK;
            }
        }

        //Deletar as Chamadas
        public ResultadoChamado Deletarchamado(Chamado chamado)
        {
            using (var ctx = new ChamadosEntities())
            {
                var resposta = ctx.TB_Chamados.Where(p => p.Resposta.Equals(chamado.Resposta));
                if(resposta.Count()>0)
                {
                    return ResultadoChamado.RESPOSTA_JA_REALIZADA;
                }
                ctx.Entry<Chamado>(chamado).State = EntityState.Deleted;
                ctx.SaveChanges();
                return ResultadoChamado.DELETADO_OK;
            }
        }
        //Listar todos os Chamados
        public IEnumerable<Chamado> ListarChamados()
        {
            using (var ctx = new ChamadosEntities())
            {
                return ctx.TB_Chamados.ToList();
            }
        }
    }
}