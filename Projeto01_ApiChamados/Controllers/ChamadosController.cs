using Projeto01_ApiChamados.Dados;
using Projeto01_ApiChamados.Enumeracoes;
using Projeto01_ApiChamados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Projeto01_ApiChamados.Controllers
{
    public class ChamadosController : ApiController
    {
        static readonly ChamadosDao dao = new ChamadosDao();

        //Criando a Resposta POST de Incluir  Chamados
        public HttpResponseMessage PostChamado(Chamado chamado)
        {
            ResultadoChamado resultado = dao.IncluirChamado(chamado);
            if (resultado == ResultadoChamado.CHAMADO_OK)
            {
                var response = Request.CreateResponse<Chamado>(HttpStatusCode.Created, chamado);
                string uri = Url.Link("DefaultApi", new { id = chamado.ChamadoId });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            else
            {
                string mensagem = "Ocorreu um erro";

                //Definir Erro e suas propriedades
                var erro = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("Erro no Servidor"),
                    ReasonPhrase = mensagem
                };
                throw new HttpResponseException(erro);
            }

        }

        //Criando a Resposta PUT para Incluir Resposta
        public HttpResponseMessage PutResposta(int id, Chamado chamado)
        {
            chamado.ChamadoId = id;
            ResultadoChamado resultado = dao.IncluirResposta(chamado);
            if (resultado == ResultadoChamado.RESPOSTA_OK)
            {
                var response = Request.CreateResponse<Chamado>(HttpStatusCode.Created, chamado);
                string uri = Url.Link("DefaultApi", new { id = chamado.ChamadoId });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            else
            {
                string mensagem;
                switch (resultado)
                {
                    case ResultadoChamado.RESPOSTA_JA_REALIZADA:
                        mensagem = "Resposta já foi realizada"; break;
                    default:
                        mensagem = "Erro inesperado"; break;
                }

                //Definir Erro e suas propriedades
                var erro = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("Erro no Servidor"),
                    ReasonPhrase = mensagem
                };
                throw new HttpResponseException(erro);
            }
        }
        //Criando o DELETE para deletar os chamados
        public HttpResponseMessage DeleteChamado(int id, Chamado chamado)
        {
            chamado.ChamadoId = id;
            ResultadoChamado resultado = dao.Deletarchamado(chamado);
            if (resultado == ResultadoChamado.DELETADO_OK)
            {
                var response = Request.CreateResponse<Chamado>(HttpStatusCode.Created, chamado);
                string uri = Url.Link("DefaultApi", new { id = chamado.ChamadoId });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            else
            {
                string mensagem;
                switch (resultado)
                {
                    case ResultadoChamado.RESPOSTA_JA_REALIZADA:
                        mensagem = "Resposta já foi realizada"; break;
                    default:
                        mensagem = "Erro inesperado"; break;
                }

                //Definir Erro e suas propriedades
                var erro = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("Erro no Servidor"),
                    ReasonPhrase = mensagem
                };
                throw new HttpResponseException(erro);
            }
        }
    }
}
