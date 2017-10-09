using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Academic.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Academic.Controllers
{
    [Route("api/[controller]")]
    public class AlunosController : Controller
    {

        public AlunosController(AcademicContext dbContext, IOptions<AppSettings> options)
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
            return Ok(await DbContext.Alunos.ToListAsync());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id) //read
        {
            return Ok(await DbContext.Alunos.SingleOrDefaultAsync(m => m.Id == id));

        }

         [HttpPost()]
        public async Task<IActionResult> Post([FromBody]dynamic value)
        {
            if (value != null)
            {
                DbContext.Alunos.AddAsync(value);
                await DbContext.SaveChangesAsync();
                return new NoContentResult();
            }
            else
            {
                return BadRequest();
            }

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] dynamic value)
        {
            if (value == null || value.Id != id)
            {
                return BadRequest();
            }

            var updateValue = await DbContext.Alunos.FirstOrDefaultAsync(t => t.Id == id);
            
            if (updateValue == null)
            {
                return NotFound();
            }

            updateValue.Name = value.Name; //update name
            DbContext.Alunos.Update(updateValue);
            await DbContext.SaveChangesAsync();
            return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var aluno = await DbContext.Alunos.SingleOrDefaultAsync(m => m.Id == id);
            DbContext.Alunos.Remove(aluno);
            await DbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
