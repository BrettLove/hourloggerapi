using Microsoft.AspNetCore.Mvc;
using HourLoggerApi.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HourLoggerApi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class HourLoggerController : ControllerBase
    {
        private readonly HourLoggerContext _context;

        public HourLoggerController(HourLoggerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Day>>> GetDayLog()
        {
            return await _context.DayLog.ToListAsync();
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Day>> GetDay(long id)
        {
            var Day = await _context.DayLog.FindAsync(id);

            if (Day == null) {
                return NotFound();
            }

            return Day;
        }

        [HttpPost]
        public async Task<ActionResult<Day>> CreateDay(Day day) 
        {
            // this works, at least for sqlite, but maybe not the best design... make a public model that inherits ?
            Day Day = day;
            Day.Id = 0;
            _context.DayLog.Add(Day);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDay), new {id = Day.Id}, Day);
        }

        // could also use post for this
        [HttpPut("{id}")]
        public async Task<ActionResult<Day>> UpdateDay(long id, Day day)
        {
            if (id != day.Id) {
                return BadRequest();
            }

            _context.DayLog.Update(day);
            await _context.SaveChangesAsync();

            return NoContent();
            //return Ok();  // I think this is also ok to do.

            //var Day = await _context.DayLog.FindAsync(id);
            //_context.Entry(Day).CurrentValues.SetValues(day);
            //return await _context.SaveChangesAsync();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Day>> DeleteDay(long id)
        {
            var day = await _context.DayLog.FindAsync(id);
            if (day == null) 
            {
                return NotFound();
            }
            _context.DayLog.Remove(day);
            await _context.SaveChangesAsync();
            return Ok();
            // return NoContent();
        }
    }

}