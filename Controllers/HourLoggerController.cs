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
            _context.DayLog.Add(day);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDay), new {id = day.Id}, day);
        }
    }

}