using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SleepTrackerApi.Data;
using SleepTrackerApi.Models;

namespace SleepTrackerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SleepRecordsController : ControllerBase
    {
        private readonly SleepTrackerApiContext _context;

        public SleepRecordsController(SleepTrackerApiContext context)
        {
            _context = context;
        }

        // GET: api/SleepRecords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SleepRecord>>> GetSleepRecord()
        {
            return await _context.SleepRecord.ToListAsync();
        }

        // GET: api/SleepRecords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SleepRecord>> GetSleepRecord(int id)
        {
            var sleepRecord = await _context.SleepRecord.FindAsync(id);

            if (sleepRecord == null)
            {
                return NotFound();
            }

            return sleepRecord;
        }

        // PUT: api/SleepRecords/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSleepRecord(int id, SleepRecord sleepRecord)
        {
            if (id != sleepRecord.Id)
            {
                return BadRequest();
            }

            _context.Entry(sleepRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SleepRecordExists(id))
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

        // POST: api/SleepRecords
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SleepRecord>> PostSleepRecord(SleepRecord sleepRecord)
        {
            _context.SleepRecord.Add(sleepRecord);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSleepRecord", new { id = sleepRecord.Id }, sleepRecord);
        }

        // DELETE: api/SleepRecords/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSleepRecord(int id)
        {
            var sleepRecord = await _context.SleepRecord.FindAsync(id);
            if (sleepRecord == null)
            {
                return NotFound();
            }

            _context.SleepRecord.Remove(sleepRecord);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SleepRecordExists(int id)
        {
            return _context.SleepRecord.Any(e => e.Id == id);
        }
    }
}
