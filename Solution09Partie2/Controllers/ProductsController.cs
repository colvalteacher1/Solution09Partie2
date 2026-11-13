using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Solution09Partie2.Dtos;
using Solution09Partie2.Models;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly ShoppingDbContext _context;
    public ProductsController(ShoppingDbContext context)
    {
        _context = context;
    }

    // GET: api/TblProduct
    [HttpGet]
    [Route("all")]
    public async Task<ActionResult<IEnumerable<TblProduct>>> GetTblProduct()
    {
        return await _context.TblProducts.ToListAsync();
    }

    // GET: api/TblProduct/5
    [HttpGet("one/{productid}")]
    public async Task<ActionResult<TblProduct>> GetTblProduct(int productid)
    {
        var tblproduct = await _context.TblProducts.FindAsync(productid);

        if (tblproduct == null)
        {
            return NotFound();
        }

        ProductDto productDto = new ProductDto()
        {
            ProductId = productid,
            ProductName = tblproduct.ProductName,
            Category = tblproduct.Category,
            Price = tblproduct.Price,
            Description = tblproduct.Description,
            StockQuantity = tblproduct.StockQuantity
        };

        return Ok(productDto);
    }

    // PUT: api/TblProduct/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{productid}")]
    public async Task<IActionResult> PutTblProduct([FromRoute] int productid, [FromBody] TblProduct tblproduct)
    {
        if (!TblProductExists(productid))
        {
            return NotFound();
        }
        tblproduct.ProductId = productid;
        _context.Entry(tblproduct).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        
        return NoContent();
    }


    // PUT: api/TblProduct/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    //[HttpPatch("patch/{productid}")]
    //public async Task<IActionResult> PatchTblProduct([FromRoute] int productid, [FromBody] TblProduct tblproduct)
    //{
    //    if (!TblProductExists(productid))
    //    {
    //        return NotFound();
    //    }
    //    tblproduct.ProductId = productid;
    //    _context.Entry(tblproduct).State = EntityState.Modified;
    //    await _context.SaveChangesAsync();

    //    return NoContent();
    //}
    // POST: api/TblProduct
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblProduct>> PostTblProduct([FromBody] [Bind("ProductName,Category,Price,StockQuantity,Description")] TblProduct tblproduct)
    {
        if (ModelState.IsValid)
        {
            var newProduct = _context.TblProducts.Add(tblproduct).Entity;
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblProduct", new { productid = newProduct.ProductId }, newProduct);
        }
        return BadRequest();
    }

    // DELETE: api/TblProduct/5
    [HttpDelete("{productid}")]
    public async Task<IActionResult> DeleteTblProduct(int? productid)
    {
        var tblproduct = await _context.TblProducts.FindAsync(productid);
        if (tblproduct == null)
        {
            return NotFound();
        }

        _context.TblProducts.Remove(tblproduct);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblProductExists(int? productid)
    {
        return _context.TblProducts.Any(e => e.ProductId == productid);
    }
}
