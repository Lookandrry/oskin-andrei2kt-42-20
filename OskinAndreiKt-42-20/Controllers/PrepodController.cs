using Microsoft.AspNetCore.Mvc;
using OskinAndreiKt_42_20.Database;
using OskinAndreiKt_42_20.Models;
using OskinAndreiKt_42_20.Interfaces;
using OskinAndreiKt_42_20.Filters;
using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;

namespace OskinAndreiKt_42_20.Controllers
{   [ApiController]
[Route("prepod")]
public class PrepodController : Controller
{
    private readonly ILogger<PrepodController> _logger;
    private readonly IPrepodService _prepodService;
    private PrepodDbContext _context;

    public PrepodController(ILogger<PrepodController> logger, IPrepodService prepodService, PrepodDbContext context)
    {
        _logger = logger;
        _prepodService = prepodService;
        _context = context;
    }

    [HttpPost(Name = "GetPrepodsByKafedra")]
    public async Task<IActionResult> GetPrepodsByKafedraAsync(PrepodKafedraFilter filter, CancellationToken cancellationToken = default)
    {
        var prepod = await _prepodService.GetPrepodsByKafedraAsync(filter, cancellationToken);

        return Ok(prepod);
    }
    //добавление для преподов
    [HttpPost("AddPrepod", Name = "AddPrepod")]
    public IActionResult CreatePrepod([FromBody] Prepod prepod)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Prepod.Add(prepod);
        _context.SaveChanges();
        return Ok(prepod);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTeacher(int id, Prepod prepod)
    {
        if (id != prepod.PrepodId)
        {
            return BadRequest();
        }

        try
        {

            _context.Entry(prepod).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok("vse ok");
        }
        catch (DbUpdateConcurrencyException)
        {
            return BadRequest();
        }

    }

    
  /*  //добавление для кафедры
    [HttpPost("AddKafedra", Name = "AddKafedra")]
    public IActionResult CreateKafedra([FromBody] OskinAndreiKt_42_20.Models.Kafedra kafedra)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Kafedra.Add(kafedra);
        _context.SaveChanges();
        return Ok(kafedra);
    }*/
        /*
    [HttpPut("EditKafedra")]
    public IActionResult UpdateKafedra(string kafedraname, [FromBody] Kafedra updatedKafedra)
    {
        var existingKafedra = _context.Kafedra.FirstOrDefault(g => g.KafedraName == kafedraname);

        if (existingKafedra == null)
        {
            return NotFound();
        }

        existingKafedra.KafedraName = updatedKafedra.KafedraName;
        _context.SaveChanges();

        return Ok();
    }*/
    //удаление для кафедры
   /* [HttpDelete("DeleteKafedra")]
    public IActionResult DeleteKafedra(string kafedraName, OskinAndreiKt_42_20.Models.Kafedra updatedKafedra)
    {
        var existingKafedra = _context.Kafedra.FirstOrDefault(g => g.KafedraName == kafedraName);

        if (existingKafedra == null)
        {
            return NotFound();
        }
        _context.Kafedra.Remove(existingKafedra);
        _context.SaveChanges();

        return Ok();
    }*/


        // DELETE:
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrepod(int id)
        {

            var prepod = await _context.Prepod.FindAsync(id);

            if (prepod == null)
            {
                return NotFound();
            }
            _context.Prepod.Remove(prepod);
            _context.SaveChanges();

            return Ok("removal was successful");
        }
    }
}
