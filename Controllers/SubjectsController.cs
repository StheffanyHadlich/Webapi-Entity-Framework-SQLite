using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Academic.Data;
using Academic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Academic.Controllers
{
    [Route("api/[controller]")]
    public class SubjectsController : Controller
    {

        public SubjectsController(AcademicContext dbContext, IOptions<AppSettings> options)
        {
            DbContext = dbContext;
            AppSettings = options.Value;
        }

        private AppSettings AppSettings { get; }
        public AcademicContext DbContext { get; }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await DbContext.Subjects.ToListAsync());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id) //read
        {
            return Ok(await DbContext.Subjects.SingleOrDefaultAsync(m => m.Id == id));

        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] Subjects value) // CREATE
        {
            if (value != null)
            {
                await DbContext.Subjects.AddAsync(value);
                await DbContext.SaveChangesAsync();
                return new NoContentResult();
            }
            else
            {
                return BadRequest();
            }

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Subjects value) // UPDATE
        {
            if (value == null || value.Id != id)
            {
                return BadRequest();
            }

            var updateValue = await DbContext.Subjects.FirstOrDefaultAsync(t => t.Id == id);

            if (updateValue == null)
            {
                return NotFound();
            }

            updateValue.name = value.name;
            updateValue.workload = value.workload; 
            updateValue.course = value.course; 
        
            

            DbContext.Subjects.Update(updateValue);
            await DbContext.SaveChangesAsync();
            return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var subjects = await DbContext.Subjects.SingleOrDefaultAsync(m => m.Id == id);
            DbContext.Subjects.Remove(subjects);
            await DbContext.SaveChangesAsync();
            return NoContent();
        }



    }
}