using EFCoreInterceptor.Data;
using EFCoreInterceptor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreInterceptor.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PersonController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public PersonController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Create(CancellationToken cancellationToken)
        {
            var person = new Person("Saeed");

            await context.People.AddAsync(person, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            return CreatedAtAction(nameof(Create), person);
        }

        [HttpGet]
        public async Task<IActionResult> Update(CancellationToken cancellationToken)
        {
            var person = await context.People.FirstAsync(cancellationToken: cancellationToken);
            person.SetName("Vahid");
            await context.SaveChangesAsync(cancellationToken);

            return Ok();
        }
    }
}