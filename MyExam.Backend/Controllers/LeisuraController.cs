using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var count = await _context.LeisuraCards.CountAsync(l => l.TransactionDate == date);
            if (count == 0)
            {
                return NotFound("Nincs tranzakció a megadott napon!");
            }

            var sum = await _context.LeisuraCards
                .Where(l => l.TransactionDate == date)
                .SumAsync(l => l.AmountHuf);

            var resultLine = $"{date:yyyy-MM-dd} | netAmountHuf: {sum} | transactionsCount: {count}";

            return Ok(new { resultLine = resultLine });
        }

        [HttpGet("stats/in-out-ratio")]
        public async Task<IActionResult> GetDepositWithdrawPercentage()
        {
            var depositCount = await _context.LeisuraCards.Where(l => l.AmountHuf > 0).CountAsync();
            var withdrawCount = await _context.LeisuraCards.Where(l => l.AmountHuf < 0).CountAsync();
            if (depositCount == 0 || withdrawCount == 0)
            {
                return NotFound("Egyetlen tranzakció sem lett rögzítve!");
            }
            double depositPercentage = Math.Round(100.0 * depositCount / (depositCount + withdrawCount), 1);

            return Ok(new { depositCount = depositCount, withdrawCount = withdrawCount, depositPercentage = depositPercentage });

        }
        [HttpGet("stats/max-in-out")]
        public async Task<IActionResult> GetMaxAndMinWithdraw()
        {
            var maxdeposit =await _context.LeisuraCards.Where(l => l.AmountHuf > 0).MaxAsync(l => l.AmountHuf);
            var maxwithdraw =await _context.LeisuraCards.Where(l => l.AmountHuf < 0).MinAsync(l => l.AmountHuf);

            if (maxdeposit == 0 || maxwithdraw == 0)
            {
                return NotFound("Egyetlen tranzakció sem lett rögzítve!");
            }
            maxwithdraw = maxwithdraw * -1;
            return Ok(new { maxdeposit = maxdeposit, maxwithdraw = maxwithdraw });

        }

        [HttpGet("stats/avg-by-gender")]
        public async Task<IActionResult> GetTransactioByGender([FromQuery] DateOnly fromdate, DateOnly todate)
        {
            var malecountindate = await _context.LeisuraCards.Where(l => l.IsMale == "True" && l.TransactionDate > fromdate && l.TransactionDate < todate).CountAsync();
            double malesum = await _context.LeisuraCards.Where(l => l.IsMale == "True" && l.TransactionDate > fromdate && l.TransactionDate < todate).AverageAsync(l => l.AmountHuf);
            var femalecountindate = await _context.LeisuraCards.Where(l => l.IsMale == "False" && l.TransactionDate > fromdate && l.TransactionDate < todate).CountAsync();
            double femalesum = await _context.LeisuraCards.Where(l => l.IsMale == "False" && l.TransactionDate > fromdate && l.TransactionDate < todate).AverageAsync(l => l.AmountHuf);
           



            if (malecountindate == 0 || femalecountindate == 0)
            {
                return NotFound("Nincs tranzakció a megadott időszakban!");
            }
            double femaleAvgHuf = Math.Round((Double)(femalesum), 1);
            double maleAvgHuf = Math.Round((Double)(malesum), 1);
            return Ok(new { form = fromdate, to = todate, maleAvgHuf = maleAvgHuf, femaleAvgHuf = femaleAvgHuf });

        }
        [HttpGet("transactions/withdrawals")]
        public async Task<IActionResult> GetTransactioninList([FromQuery] int minAbs)
        {
            var transactions = await _context.LeisuraCards.OrderBy(l => l.TransactionDate).Where(l => l.AmountHuf < 0 && Math.Abs(l.AmountHuf) > minAbs).ToListAsync();
            if (transactions == null)
            {
                return NotFound("Nincs találat!");
            }

            var result = transactions.Select(t =>
            $"id: {t.Id}, empliyeeName: {t.EmployeeName}, isMale: {t.IsMale}, transactionDate: {t.TransactionDate}, amountHuf: {t.AmountHuf}"
            ).ToList();

            return Ok(result);
        }

        [HttpGet("transactions/by-employee")]
        public async Task<IActionResult> GetAllTransactionOfWorker([FromQuery] string name)
        {
            var tranofworker = await _context.LeisuraCards.OrderBy(l => l.TransactionDate).Where(l => l.EmployeeName == name).ToListAsync();
           
            if (tranofworker == null)
            {
                return NotFound("Nincs tranzakció a megadott dolgozóhoz");
            }
            var result = tranofworker.Select(t =>
             $"id: {t.Id}, empliyeeName: {t.EmployeeName}, isMale: {t.IsMale}, transactionDate: {t.TransactionDate}, amountHuf: {t.AmountHuf}"
             ).ToList();

            return Ok(new { result = result });
        }

        [HttpGet("transactions/by-date")]
        public async Task<IActionResult> GetTransactionByDate([FromQuery] DateOnly date)
        {
            var amountHuf = await _context.LeisuraCards.OrderByDescending(l => l.AmountHuf).Where(l => l.TransactionDate == date).ToListAsync();
            var result = amountHuf.Select(t =>
            $"id: {t.Id}, empliyeeName: {t.EmployeeName}, isMale: {t.IsMale}, transactionDate: {t.TransactionDate}, amountHuf: {t.AmountHuf}"
            ).ToList();

            return Ok(new { result = result });
        }


        [HttpGet("transactions/deposits")]
        public async Task<IActionResult> GetDepositsInList([FromQuery] string isMale)
        {
            var deposits = await _context.LeisuraCards.OrderBy(l => l.AmountHuf).Where(l => l.IsMale == isMale).ToListAsync();
            var result = deposits.Select(t =>
            $"id: {t.Id}, empliyeeName: {t.EmployeeName}, isMale: {t.IsMale}, transactionDate: {t.TransactionDate}, amountHuf: {t.AmountHuf}"
            ).ToList();

            return Ok(new { result = result });
        }

        [HttpGet("transactions/range")]
        public async Task<IActionResult> GetTransactionInDate([FromQuery] DateOnly from, DateOnly to)
        {
            var listaindate = await _context.LeisuraCards.OrderBy(l => l.TransactionDate).Where(l => l.TransactionDate > from && l.TransactionDate < to).ToListAsync();
            var result = listaindate.Select(t =>
            $"id: {t.Id}, empliyeeName: {t.EmployeeName}, isMale: {t.IsMale}, transactionDate: {t.TransactionDate}, amountHuf: {t.AmountHuf}"
            ).ToList();

            return Ok(new { result = result });
        }

        [HttpGet("transactions/top-withdrawals")]
        public async Task<IActionResult> MaxNPay([FromQuery] int top)
        {
            if(top < 0)
            {
                top = top * -1;
            }
            var listoftopwithdrawls = await _context.LeisuraCards.OrderByDescending(l => Math.Abs(l.AmountHuf)).Where(l => l.AmountHuf < Math.Abs(top) && l.AmountHuf < 0).ToListAsync();
            var result = listoftopwithdrawls.Select(t =>
            $"id: {t.Id}, empliyeeName: {t.EmployeeName}, isMale: {t.IsMale}, transactionDate: {t.TransactionDate}, amountHuf: {t.AmountHuf}"
            ).ToList();

            return Ok(new { result = result });
        }










    }
}
