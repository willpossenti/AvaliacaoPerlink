using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AvaliacaoPerlink.Models;

namespace AvaliacaoPerlink.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Avaliacao()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }


        [HttpPost]
        public ActionResult Descobrir(Avaliacao avaliacao)
        {
        

            if (ModelState.IsValid)
            {
               string resultado = CalcularNumeroSortudo(avaliacao.numero) + CalcularNumeroFeliz(avaliacao.numero);

                avaliacao.mensagem = resultado;
            }

            return View("Avaliacao", avaliacao);
        }


        #region Cálculo do Número Feliz
        public string CalcularNumeroFeliz(string numero)
        {
            int resultadoFinal =  Convert.ToInt32(numero);
            int interacoes = 1;

            if (resultadoFinal != 1 ) {
            
                while (resultadoFinal > 1) {

                    int resultadoParcial = 0;

                    double numeroAoQuadrado;
                    char[] array = resultadoFinal.ToString().ToCharArray(); 

                    for (int i = 0; i < array.Length; i++)
                    {
                        numeroAoQuadrado = Math.Pow(Convert.ToDouble(array[i].ToString()), 2);
                        resultadoParcial += Convert.ToInt32(numeroAoQuadrado.ToString());

                    }

                    resultadoFinal = resultadoParcial;

                    if (interacoes == 100)
                        break;
                    else
                        interacoes++;
                }

                if (resultadoFinal == 1)
                    return " e Feliz";
            }

            return " e Não-Feliz";

        }
        #endregion

        #region Cálculo do Número Sortudo
        public string CalcularNumeroSortudo(string numero)
        {
            int resultado = Convert.ToInt32(numero);
            int incremento = 1;

            if(resultado % 2 == 0)
                return "Número Não-Sortudo";
            else {
            
                List<int> resultadoParcial = new List<int>();

                for (int i = 1; i <= resultado; i++)
                {

                    resultadoParcial.Add(Convert.ToInt32(i.ToString()));
                        i++;
                }

                if (resultadoParcial.Count >= 3)
                {

                    List<int> numerosApenasComImpares = resultadoParcial;
                    resultadoParcial = new List<int>();

                    for (int i = 0; i < numerosApenasComImpares.Count; i++)
                    {

                        if(incremento != 3) {

                            resultadoParcial.Add(numerosApenasComImpares[i]);
                            incremento++;
                        }
                        else 
                            incremento = 1;
                    }

                }



                if (resultadoParcial.Count >= 7)
                {
                     incremento = 1;

                    List<int> numerosRemovendoATerceiraPosicao = resultadoParcial;
                    resultadoParcial = new List<int>();

                    for (int i = 0; i < numerosRemovendoATerceiraPosicao.Count; i++)
                    {

                        if (incremento != 7)
                        {
                            resultadoParcial.Add(numerosRemovendoATerceiraPosicao[i]);
                            incremento++;
                        }
                        else
                            incremento = 1;


                    }

                    if (resultadoParcial.Contains<int>(resultado))
                        return "Número Sortudo";
                    else
                        return "Número Não-Sortudo";

                }
                else {

                    if (resultadoParcial.Contains<int>(resultado))
                        return "Número Sortudo";
                     else
                        return "Número Não-Sortudo";

                }

            }

         }
        #endregion

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
