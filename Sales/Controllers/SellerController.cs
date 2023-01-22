using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sellers.Model;
using Sellers.Repository;

namespace Sellers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        private readonly ISellerRepository _sellerRepository;

        public SellerController(ISellerRepository sellerRepository)
        {
            _sellerRepository = sellerRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Seller>> GetSellers()
        {
            return await _sellerRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Seller>> GetSellers(int id)
        {
            return await _sellerRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Seller>> PostSellers([FromBody] Seller seller)
        {
            var newSeller = await _sellerRepository.Create(seller);
            return CreatedAtAction(nameof(GetSellers), new { id = newSeller.Id }, newSeller);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSeller(int id)
        {
            var sellerToDelete = await _sellerRepository.Get(id);
            if (sellerToDelete == null)
                return NotFound();

            await _sellerRepository.Delete(sellerToDelete.Id);
            return NoContent();


        }

        [HttpPut]
        public async Task<ActionResult<Seller>> PutSellers(int id, [FromBody] Seller seller)
        {
            if (id != seller.Id)
                return BadRequest();
            await _sellerRepository.Update(seller);

            return NoContent();
        }
    }

   }
