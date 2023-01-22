using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sales.Model;
using Sales.Repository;

namespace Sales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISaleRepository _saleRepository;

        public SalesController(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Sale>> GetSales()
        {
            return await _saleRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sale>> GetSales(int id)
        {
            return await _saleRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Sale>> PostSales([FromBody] Sale sale)
        {
            var newSale = await _saleRepository.Create(sale);
            return CreatedAtAction(nameof(GetSales), new { id = newSale.Id }, newSale);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSale(int id)
        {
            var saleToDelete = await _saleRepository.Get(id);
            if(saleToDelete == null)
                return NotFound();
            
            await _saleRepository.Delete(saleToDelete.Id);
            return NoContent();
            
            
        }

        [HttpPut]
        public async Task<ActionResult<Sale>> PutSales(int id, [FromBody] Sale sale)
        {
            if (id != sale.Id)
                return BadRequest();
            await _saleRepository.Update(sale);

            return NoContent();
        }

    }
}
