using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CSharp.NET_CAPSTONE_GC_Car_Dealership.Models;

namespace CSharp.NET_CAPSTONE_GC_Car_Dealership.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly CarsDbContext _context;

        public CarController(CarsDbContext context)
        {
            _context = context;
        }

        // GET: api/Car
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarInfo>>> GetCarInfo()
        {
            return await _context.CarInfo.ToListAsync();
        }

        // GET: api/Car/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarInfo>> GetCarInfo(int id)
        {
            var carInfo = await _context.CarInfo.FindAsync(id);

            if (carInfo == null)
            {
                return NotFound();
            }

            return carInfo;
        }

        // PUT: api/Car/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarInfo(int id, CarInfo carInfo)
        {
            if (id != carInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(carInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarInfoExists(id))
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

        // POST: api/Car
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CarInfo>> PostCarInfo(CarInfo carInfo)
        {
            _context.CarInfo.Add(carInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarInfo", new { id = carInfo.Id }, carInfo);
        }

        // DELETE: api/Car/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CarInfo>> DeleteCarInfo(int id)
        {
            var carInfo = await _context.CarInfo.FindAsync(id);
            if (carInfo == null)
            {
                return NotFound();
            }

            _context.CarInfo.Remove(carInfo);
            await _context.SaveChangesAsync();

            return carInfo;
        }

        private bool CarInfoExists(int id)
        {
            return _context.CarInfo.Any(e => e.Id == id);
        }
    }
}
