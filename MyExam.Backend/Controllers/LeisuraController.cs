using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyExam.Backend.Models.DbMysqlModels;

namespace MyExam.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeisuraController : ControllerBase
    {
        private readonly LeisuraContext _context = new LeisuraContext();

        [HttpGet("stats/daily-net")]
        public async Task<IActionResult> GetDailyNet([FromQuery] DateOnly date)
        {
            _context.LeisuraCards.Count(l => l.TransactionDate);
        }
    
    }
}
