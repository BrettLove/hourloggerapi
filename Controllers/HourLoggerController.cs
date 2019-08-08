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
    }

}