using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VendasAPI.Model;
using VendasAPI.Repository;

namespace VendasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendasController : ControllerBase
    {
        private readonly IVendaRepository _vendaRepository;

        public VendasController(IVendaRepository vendaRepository)
        {
            _vendaRepository = vendaRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Venda>> GetVendas()
        {
            return await _vendaRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Venda>> GetVendas(int id)
        {
            return await _vendaRepository.Get(id);
        }

        [HttpPost("/AdicionarVenda/")]
        public async Task<ActionResult<Venda>> AdicionarVenda([FromBody] Venda venda)
        {
            DateTime dataHoje = DateTime.Today;
           
            venda.DataVenda =  dataHoje.ToLongDateString();
            venda.Status = "Aguardando pagamento";
            var novaVenda = await _vendaRepository.Create(venda);
            return CreatedAtAction(nameof(GetVendas), new { id = novaVenda.Id }, novaVenda);
        }

        [HttpDelete("/DeletarVenda/{id}")]
        public async Task<ActionResult> DeleteSale(int id)
        {
            var vendaToDelete = await _vendaRepository.Get(id);
            if(vendaToDelete == null)
                return NotFound();
            
            await _vendaRepository.Delete(vendaToDelete.Id);
            return NoContent();
            
            
        }

        [HttpPut("/AtualizarVenda/{id}")]
        public async Task<ActionResult<Venda>> PutVendas(int id, [FromBody] Venda venda)
        {
            if (id != venda.Id)
                return BadRequest();
            await _vendaRepository.Update(venda);

            return NoContent();
        }

    }
}
