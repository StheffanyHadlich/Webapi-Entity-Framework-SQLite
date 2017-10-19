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
    public class ClassroomController : Controller
    {

        public ClassroomController(AcademicContext dbContext, IOptions<AppSettings> options)
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
            return Ok(await DbContext.Classroom
            .Include(m => m.subject)
            .ThenInclude(m => m.course)
            .Include(m => m.professor)
            .ToListAsync());
        }
 
        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id) //read
        {
            return Ok(await DbContext.Classroom.SingleOrDefaultAsync(m => m.Id == id));

        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] Classroom value) // CREATE
        {
            if (value != null)
            {
                await DbContext.Classroom.AddAsync(value);
                await DbContext.SaveChangesAsync();
                return new NoContentResult();
            }
            else
            {
                return BadRequest();
            }

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Classroom value) // UPDATE
        {
            if (value == null || value.Id != id)
            {
                return BadRequest();
            }

            var updateValue = await DbContext.Classroom.FirstOrDefaultAsync(t => t.Id == id);

            if (updateValue == null)
            {
                return NotFound();
            }

            updateValue.day = value.day; //update name
            updateValue.classroom = value.classroom;
            updateValue.vacancies = value.vacancies;
            updateValue.subject = value.subject;
            updateValue.professor = value.professor;

            DbContext.Classroom.Update(updateValue);
            await DbContext.SaveChangesAsync();
            return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var classR = await DbContext.Classroom.SingleOrDefaultAsync(m => m.Id == id);
            DbContext.Classroom.Remove(classR);
            await DbContext.SaveChangesAsync();
            return NoContent();
        }



    }
}