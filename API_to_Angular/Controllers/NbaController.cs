
using NbaPlayerAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_to_Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NbaPlayerController : Controller
    { 

        public readonly DataContext _context;

        public NbaPlayerController(DataContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public async Task<ActionResult<List<NbaPlayers>>> GetNbaPlayers()
        {
            return Ok(await _context.Nbaplayers.ToListAsync());
        }

        [HttpPost]

        public async Task<ActionResult<List<NbaPlayers>>> PostNbaPlayers(NbaPlayers players)
        {
            _context.Nbaplayers.Add(players);
            await _context.SaveChangesAsync();

            return Ok(await _context.Nbaplayers.ToListAsync());

        }


        [HttpPut]

        public async Task<ActionResult<List<NbaPlayers>>> UpdateNbaPlayers(NbaPlayers players)
        {
            var dbplayer = await _context.Nbaplayers.FindAsync(players.Id);

            if (dbplayer == null)
                return BadRequest("Player not found");

            dbplayer.Position = players.Position;
            dbplayer.FirstName = players.FirstName;
            dbplayer.LastName = players.LastName;
            dbplayer.Club = players.Club;

            await _context.SaveChangesAsync();

            return Ok(await _context.Nbaplayers.ToListAsync());

        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<List<NbaPlayers>>> DeleteNbaPlayers(int id)
        {

            var dbplayer = await _context.Nbaplayers.FindAsync(id);
            if (dbplayer == null)
                return BadRequest("Player not found");

            _context.Nbaplayers.Remove(dbplayer);
            await _context.SaveChangesAsync();


            return Ok(await _context.Nbaplayers.ToListAsync());

        }

    }
}

