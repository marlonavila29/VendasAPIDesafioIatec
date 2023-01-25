using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VendasAPI.Model;
using VendasAPI.Repository;

namespace VendasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendedorController : ControllerBase
    {
        private readonly IVendedorRepository _vendedorRepository;

        public VendedorController(IVendedorRepository vendedorRepository)
        {
            _vendedorRepository = vendedorRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Vendedor>> GetVendedores()
        {
            return await _vendedorRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vendedor>> GetVendedores(int id)
        {
            return await _vendedorRepository.Get(id);
        }

        [HttpPost("/AdicionarVendedor/")]
        public async Task<ActionResult<Vendedor>> PostVendedores([FromBody] Vendedor vendedor)
        {
            var novoVendedor = await _vendedorRepository.Create(vendedor);
            return CreatedAtAction(nameof(GetVendedores), new { id = novoVendedor.Id }, novoVendedor);
        }

        [HttpDelete("/DeletarVendedor/{id}")]
        public async Task<ActionResult> DeleteVendedor(int id)
        {
            var vendedorToDelete = await _vendedorRepository.Get(id);
            if (vendedorToDelete == null)
                return NotFound();

            await _vendedorRepository.Delete(vendedorToDelete.Id);
            return NoContent();


        }

        [HttpPut("/AtualizarVendedor/{id+}")]
        public async Task<ActionResult<Vendedor>> PutVendedores(int id, [FromBody] Vendedor vendedor)
        {
            if (id != vendedor.Id)
                return BadRequest();
            await _vendedorRepository.Update(vendedor);

            return NoContent();
        }
    }

   }
