using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using E_commerceProductCatalogAPI.Interfaces;
using E_commerceProductCatalogAPI.Models;
using E_commerceProductCatalogAPI.DTO;

namespace E_commerceProductCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductVariantController : Controller
    {
        private readonly IProductVariantRepository _productVariantRepository;
        private readonly IMapper _mapper;

        public ProductVariantController(IProductVariantRepository productVariantRepository, IMapper mapper)
        {
            _productVariantRepository = productVariantRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ProductVariantDto>))]
        public IActionResult GetProductVariants()
        {
            var productVariants = _mapper.Map<List<ProductVariantDto>>(_productVariantRepository.GetProductVariants());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(productVariants);
        }

        [HttpGet("{variantId}")]
        [ProducesResponseType(200, Type = typeof(ProductVariantDto))]
        [ProducesResponseType(400)]
        public IActionResult GetProductVariant(int variantId)
        {
            if (!_productVariantRepository.ProductVariantExists(variantId))
                return NotFound();

            var productVariant = _mapper.Map<ProductVariantDto>(_productVariantRepository.GetProductVariant(variantId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(productVariant);
        }

        [HttpGet("product/{productId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ProductVariantDto>))]
        [ProducesResponseType(400)]
        public IActionResult GetProductVariantsByProduct(int productId)
        {
            var productVariants = _mapper.Map<List<ProductVariantDto>>(_productVariantRepository.GetProductVariantsByProduct(productId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(productVariants);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateProductVariant([FromQuery] int productId, [FromBody] ProductVariantDto productVariantCreate)
        {
            if (productVariantCreate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var productVariantMap = _mapper.Map<ProductVariant>(productVariantCreate);

            if (!_productVariantRepository.CreateProductVariant(productId, productVariantMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{variantId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateProductVariant(int variantId, [FromBody] ProductVariantDto updatedProductVariant)
        {
            if (updatedProductVariant == null)
                return BadRequest(ModelState);

            if (variantId != updatedProductVariant.Id)
                return BadRequest(ModelState);

            if (!_productVariantRepository.ProductVariantExists(variantId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var productVariantMap = _mapper.Map<ProductVariant>(updatedProductVariant);

            if (!_productVariantRepository.UpdateProductVariant(productVariantMap))
            {
                ModelState.AddModelError("", "Something went wrong updating product variant");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{variantId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteProductVariant(int variantId)
        {
            if (!_productVariantRepository.ProductVariantExists(variantId))
            {
                return NotFound();
            }

            var productVariantToDelete = _productVariantRepository.GetProductVariant(variantId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_productVariantRepository.DeleteProductVariant(productVariantToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting product variant");
            }

            return NoContent();
        }
    }
}