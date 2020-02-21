using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using FinControl.Services;
using FinControl.Models;
using System.Collections.Generic;

namespace FinControl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContasController : ControllerBase
    {

        private readonly ContasService _contasService;

        public ContasController(ContasService contaService)
        {
            _contasService = contaService;
        }

        [HttpPost]
        public ActionResult<Contas> Save(Contas conta)
        {
            var response = _contasService.Save(conta);
            return response;
        }

        [HttpGet]
        public List<Contas> FindAll()
        {
            var response = _contasService.FindAll();
            return response;
        }


        [HttpGet("{id}", Name = "GetContas")]
        public ActionResult<Contas> Find(string id)
        {
            var contas = _contasService.Find(id);

            if (contas == null)
            {
                return NotFound();
            }

            return contas;
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, Contas contaIn)
        {
            var conta = _contasService.Find(id);

            if (conta == null)
            {
                return NotFound();
            }

            _contasService.Update(id, contaIn);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public string Delete(string id)
        {
            var user = _contasService.Find(id);

            _contasService.Remove(user.Id);

            return "Conta excluida com sucesso!";
        }

    }
}