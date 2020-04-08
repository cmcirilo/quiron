using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web;
using Quiron.LojaVirtual.Dominio.Entidades;

namespace Quiron.LojaVirtual.Web.InfraEstrutura
{
    public class CarrinhoModelBinder : IModelBinder
    {
        private const string SessionKey = "Carrinho";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            //Obtenho Carrinho da Sessão
            Carrinho carrinho = null;

            if (controllerContext.HttpContext.Session[SessionKey] != null)
            {
                carrinho = (Carrinho)controllerContext.HttpContext.Session[SessionKey];
            }

            //Cria o Carrinho se não tenho Sessão

            if(carrinho == null)
            {
                carrinho = new Carrinho();

                if(controllerContext.HttpContext.Session!= null)
                {
                    controllerContext.HttpContext.Session[SessionKey] = carrinho;
                }
            }
            //Retorno o Carrinho
            return carrinho;


        }
    }
}


