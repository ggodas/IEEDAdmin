using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SoftSize.Ieed.UI.Controllers
{
    public class PagSeguroViewModel
    {
        //Email da Loja
        public string VendedorEmail { get; set; }

        public string TransacaoID { get; set; }

        //Número de referência gerado por você e enviado ao PagSeguro para identificação em seu site. 255 caracteres
        public string Referencia { get; set; }

        //Valor das taxas Extras
        public decimal Extras { get; set; }

        public string TipoFrete { get; set; }

        public decimal ValorFrete { get; set; }

        //Anotação enviada pelo cliente, 250
        public string Anotacao { get; set; }

        public DateTime DataTransacao { get; set; }

        public string TipoPagamento { get; set; }
        public string StatusTransacao { get; set; }
        public string CliNome { get; set; }
        public string CliEmail { get; set; }
        public string CliEndereco { get; set; }
        public string CliNumero { get; set; }
        public string CliComplemento { get; set; }
        public string CliBairro { get; set; }
        public string CliCidade { get; set; }
        public string CliEstado { get; set; }
        public string CliCEP { get; set; }
        public string CliTelefone { get; set; }
        public string ProdID_x { get; set; }
        public string ProdDescricao_x { get; set; }
        public string ProdValor_x { get; set; }
        public string ProdQuantidade_x { get; set; }
        public string ProdFrete_x { get; set; }
        public string NumItens { get; set; }
        public string Parcelas { get; set; }
        public string Comando { get; set; }
        public string Token { get; set; }



    }
    public class TransacoesPagSeguroController : Controller
    {
        //
        // GET: /TransacoesPagSeguro/
        [HttpPost]
        public ActionResult Index(PagSeguroViewModel formCollection)
        {
            //formCollection.Add("Comando", "Validar");
            //formCollection.Add("Token", "123456");

            //Response.ContentType = "text/HTML";
            //Response.Charset = "ISO-8859-1";

            formCollection.Comando = "Validar";
            formCollection.Token = "123123";

            //var postData = "";

            //for (int i = 0; i < formCollection.Count; i++)
            //{
            //    if (formCollection.GetKey(i) != null)
            //    {
            //        if (postData.Length > 0)
            //            postData += "&";
            //        postData += formCollection.GetKey(i) + "=" +
            //                    formCollection.GetValue(formCollection.GetKey(i)).AttemptedValue;
            //    }
            //}

            return View(formCollection);
        }

        //
        // GET: /TransacoesPagSeguro/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /TransacoesPagSeguro/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /TransacoesPagSeguro/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /TransacoesPagSeguro/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /TransacoesPagSeguro/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /TransacoesPagSeguro/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /TransacoesPagSeguro/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
