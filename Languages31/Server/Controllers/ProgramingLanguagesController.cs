using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Languages31.Server.Data;
using Languages31.Shared;

namespace Languages31.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramingLanguagesController : ControllerBase
    {
        private readonly Languages31ServerContext _context;

        public ProgramingLanguagesController(Languages31ServerContext context)
        {
            _context = context;
        }

        // GET: api/ProgramingLanguages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProgramingLanguages>>> GetProgramingLanguages()
        {
            return await _context.ProgramingLanguages.ToListAsync();
        }

        // GET: api/ProgramingLanguages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProgramingLanguages>> GetProgramingLanguages(int id)
        {
            var programingLanguages = await _context.ProgramingLanguages.FindAsync(id);

            if (programingLanguages == null)
            {
                return NotFound();
            }

            return programingLanguages;
        }

        // PUT: api/ProgramingLanguages/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProgramingLanguages(int id, ProgramingLanguages programingLanguages)
        {
            if (id != programingLanguages.Id)
            {
                return BadRequest();
            }

            _context.Entry(programingLanguages).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgramingLanguagesExists(id))
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

        // POST: api/ProgramingLanguages
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProgramingLanguages>> PostProgramingLanguages(ProgramingLanguages programingLanguages)
        {
            _context.ProgramingLanguages.Add(programingLanguages);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProgramingLanguages", new { id = programingLanguages.Id }, programingLanguages);
        }

        // DELETE: api/ProgramingLanguages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProgramingLanguages>> DeleteProgramingLanguages(int id)
        {
            var programingLanguages = await _context.ProgramingLanguages.FindAsync(id);
            if (programingLanguages == null)
            {
                return NotFound();
            }

            _context.ProgramingLanguages.Remove(programingLanguages);
            await _context.SaveChangesAsync();

            return programingLanguages;
        }

        private bool ProgramingLanguagesExists(int id)
        {
            return _context.ProgramingLanguages.Any(e => e.Id == id);
        }
    }
}
