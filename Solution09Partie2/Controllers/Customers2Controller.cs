using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Solution09Partie2.Models;

[Route("api/[controller]")]
[ApiController]
public class Customers2Controller : ControllerBase
{
    private readonly ShoppingDbContext _context;
    public Customers2Controller(ShoppingDbContext context)
    {
        _context = context;
    }

    // GET: api/TblCustomer
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblCustomer>>> GetTblCustomer()
    {
        return await _context.TblCustomers.ToListAsync();
    }

    // GET: api/TblCustomer/5
    [HttpGet("{customerid}")]
    public async Task<ActionResult<TblCustomer>> GetTblCustomer(int customerid)
    {
        var tblcustomer = await _context.TblCustomers.FindAsync(customerid);

        if (tblcustomer == null)
        {
            return NotFound();
        }

        return tblcustomer;
    }

    // PUT: api/TblCustomer/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{customerid}")]
    public async Task<IActionResult> PutTblCustomer(int? customerid, TblCustomer tblcustomer)
    {
        if (customerid != tblcustomer.CustomerId)
        {
            return BadRequest();
        }

        _context.Entry(tblcustomer).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblCustomerExists(customerid))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/TblCustomer
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblCustomer>> PostTblCustomer(TblCustomer tblcustomer)
    {
        _context.TblCustomers.Add(tblcustomer);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblCustomer", new { customerid = tblcustomer.CustomerId }, tblcustomer);
    }

    // DELETE: api/TblCustomer/5
    [HttpDelete("{customerid}")]
    public async Task<IActionResult> DeleteTblCustomer(int? customerid)
    {
        var tblcustomer = await _context.TblCustomers.FindAsync(customerid);
        if (tblcustomer == null)
        {
            return NotFound();
        }

        _context.TblCustomers.Remove(tblcustomer);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblCustomerExists(int? customerid)
    {
        return _context.TblCustomers.Any(e => e.CustomerId == customerid);
    }
}
