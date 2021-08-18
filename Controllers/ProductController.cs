using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using meus_produtos.Models;
using meus_produtos.Data;
using Microsoft.AspNetCore.Http;

namespace meus_produtos.Controllers
{
  [ApiController]
  [Route("api/v1/products")]
  public class ProductController : ControllerBase
  {
    private readonly IProductRepository productRepository;
    public ProductController(IProductRepository productRepository)
    {
      this.productRepository = productRepository;
    }

    [HttpGet]
    public async Task<ActionResult> GetProducts()
    {
      try
      {
        return Ok(await productRepository.GetProducts());
      }
      catch (System.Exception)
      {
        return StatusCode(StatusCodes.Status500InternalServerError,
            "Erro ao recuperar dados");
      }

    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
      try
      {
        var result = Ok(await productRepository.GetProduct(id));

        if (result == null)
        {
          return NotFound();
        }
        else
        {
          return result;
        }
      }
      catch (System.Exception)
      {
        return StatusCode(StatusCodes.Status500InternalServerError,
              "Erro ao recuperar dados");
      }
    }

    [HttpPost]
    public async Task<ActionResult<Product>> AddProduct(Product product)
    {
      try
      {
        if (product == null)
        {
          return BadRequest();
        }

        var createdProduct = await productRepository.AddProduct(product);

        return CreatedAtAction(nameof(GetProduct),
        new { id = createdProduct.Id }, createdProduct);

      }
      catch (System.Exception)
      {
        return StatusCode(StatusCodes.Status500InternalServerError,
            "Erro ao adicionar dados");
      }
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Product>> UpdateProduct(int id, Product product)
    {
      try
      {
        if (id != product.Id)
        {
          return BadRequest("ID de produto inconsistente");
        }

        var productToUpdate = await productRepository.GetProduct(product.Id);

        if (productToUpdate == null)
        {
          return NotFound($"Produto com o ID {product.Id} não encontado");
        }

        return await productRepository.UpdateProduct(product);
      }
      catch (System.Exception)
      {
        return StatusCode(StatusCodes.Status500InternalServerError,
            "Erro ao atualizar dados");
      }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteProduct(int id)
    {
      try
      {
        var productToDelete = await productRepository.GetProduct(id);
        if (productToDelete == null)
        {
          return NotFound($"Produto com o ID {id} não encontado");
        }

        await productRepository.DeleteProduct(id);

        return Ok($"Produto com o ID {id} deletado");
      }
      catch (System.Exception)
      {
        return StatusCode(StatusCodes.Status500InternalServerError,
              "Erro ao deletar dados");
      }
    }

  }
}