using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DemoCallAPI.Models;

namespace DemoCallAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly AppDBContext _context;

        public SongsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/Songs
        [HttpGet]
        public IEnumerable<SongModel> GetSongs()
        {
            var songs = from s in _context.Songs
                        select new SongModel
                        {
                            SongId = s.SongId,
                            Tittle = s.Tittle,
                            Author = s.Author,
                            Duration = s.Duration,
                            Singer = s.Singer,
                        };
            return songs;
        }

        // GET: api/Songs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSong([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var song = _context.Songs.FirstOrDefault(t => t.SongId == id);
            if (song == null)
            {
                return NotFound();
            }
            else
            {
                var songModel = from s in _context.Songs.Where(s => s.SongId == id)
                                select new SongModel
                                {
                                    SongId = s.SongId,
                                    Author = s.Author,
                                    Duration = s.Duration,
                                    Singer = s.Singer,
                                };
                return Ok(songModel);
            }
        }

        //search
        // PUT: api/Songs/name
        [HttpGet("{name}")]
        public async Task<IActionResult> GetSongByName([FromRoute] string title)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var song = _context.Songs.FirstOrDefault(t => t.Tittle == title);
            if (song == null)
            {
                return NotFound();
            }
            else
            {
                var songModel = from s in _context.Songs.Where(s => s.Tittle == title)
                                select new SongModel
                                {
                                    SongId = s.SongId,
                                    Author = s.Author,
                                    Duration = s.Duration,
                                    Singer = s.Singer,
                                };
                return Ok(songModel);
            }
        }

        // PUT: api/Songs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSong([FromRoute] string id, [FromBody] Song song)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != song.SongId)
            {
                return BadRequest();
            }

            _context.Entry(song).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongExists(id))
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

        // POST: api/Songs
        [HttpPost]
        public async Task<IActionResult> PostSong([FromBody] Song song)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Songs.Add(song);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSong", new { id = song.SongId }, song);
        }

        // DELETE: api/Songs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSong([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var song = await _context.Songs.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }

            _context.Songs.Remove(song);
            await _context.SaveChangesAsync();

            return Ok(song);
        }

        private bool SongExists(string id)
        {
            return _context.Songs.Any(e => e.SongId == id);
        }
    }
}