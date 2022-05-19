using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroDB.Server.Data;
using SuperHeroDB.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHeroDB.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {

        private readonly DataContext _context;

        public MusicController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("random/{Count}")]
        public async Task<IActionResult> GetRandomMusic(int Count)
        {
            return Ok(await _context.Music.OrderBy(r => Guid.NewGuid()).Take(Count).ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> GetMusics()
        {
            return base.Ok(await GetMusicsList());
        }

        private async Task<List<Music>> GetMusicsList()
        {
            return await _context.Music.Include(x => x.MusicInformation).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleMusic(Guid id)
        {
            var hero = await _context.Music.Include(sh => sh.MusicInformation).FirstOrDefaultAsync(h => h.Id == id);
            if (hero == null)
                return NotFound("Music wasn't found. Too bad. :(");

            return Ok(hero);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMusic(Music Music)
        {
            _context.Music.Add(Music);
            await _context.SaveChangesAsync();

            return Ok(await GetMusicsList());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMusic(Music Music, Guid id)
        {
            var music = await _context.Music.Include(sh => sh.MusicInformation).FirstOrDefaultAsync(h => h.Id == id);

            if (music == null)
                return NotFound("Music wasn't found. Too bad. :(");

            music.Name = Music.Name;
            music.MusicAddress = Music.MusicAddress;
            music.PictureAddress = Music.PictureAddress;
            music.MusicInformation = Music.MusicInformation;

            await _context.SaveChangesAsync();

            return Ok(await GetMusicsList());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMusic(Guid id)
        {
            var music = await _context.Music.Include(sh => sh.MusicInformation).FirstOrDefaultAsync(h => h.Id == id);

            if (music == null)
                return NotFound("Music wasn't found. Too bad. :(");

            _context.Music.Remove(music);
            await _context.SaveChangesAsync();

            return Ok(await GetMusicsList());
        }

        //geners
        [HttpGet("Geners")]
        public async Task<IActionResult> GetGeners()
        {
            return base.Ok(await GetGenersList());
        }

        private async Task<List<Gener>> GetGenersList()
        {
            return await _context.Gener.ToListAsync();
        }

        [HttpGet("Geners/{id}")]
        public async Task<IActionResult> GetSingleGener(int id)
        {
            var hero = await _context.Gener.FirstOrDefaultAsync(h => h.Id == id);
            if (hero == null)
                return NotFound("Gener wasn't found. Too bad. :(");

            return Ok(hero);
        }

        [HttpPost("Geners")]
        public async Task<IActionResult> CreateGener(Gener Gener)
        {
            _context.Gener.Add(Gener);
            await _context.SaveChangesAsync();

            return Ok(await GetGenersList());
        }

        [HttpPut("Geners/{id}")]
        public async Task<IActionResult> UpdateGener(Gener gener, int id)
        {
            var Gener = await _context.Gener.FirstOrDefaultAsync(h => h.Id == id);

            if (Gener == null)
                return NotFound("Gener wasn't found. Too bad. :(");

            Gener.Name = gener.Name;

            await _context.SaveChangesAsync();

            return Ok(await GetGenersList());
        }

        [HttpDelete("Geners/{id}")]
        public async Task<IActionResult> DeleteGener(int id)
        {
            var Gener = await _context.Gener.FirstOrDefaultAsync(h => h.Id == id);

            if (Gener == null)
                return NotFound("Gener wasn't found. Too bad. :(");

            _context.Gener.Remove(Gener);
            await _context.SaveChangesAsync();

            return Ok(await GetGenersList());
        }


        //singers
        [HttpGet("Singers")]
        public async Task<IActionResult> GetSingers()
        {
            return base.Ok(await GetSingersList());
        }

        private async Task<List<Singer>> GetSingersList()
        {
            return await _context.Singer.ToListAsync();
        }

        [HttpGet("Singers/{id}")]
        public async Task<IActionResult> GetSingleSinger(Guid id)
        {
            var hero = await _context.Singer.FirstOrDefaultAsync(h => h.Id == id);
            if (hero == null)
                return NotFound("Singer wasn't found. Too bad. :(");

            return Ok(hero);
        }

        [HttpPost("Singers")]
        public async Task<IActionResult> CreateSinger(Singer Singer)
        {
            _context.Singer.Add(Singer);
            await _context.SaveChangesAsync();

            return Ok(await GetSingersList());
        }

        [HttpPut("Singers/{id}")]
        public async Task<IActionResult> UpdateSinger(Singer singer, Guid id)
        {
            var Singer = await _context.Singer.FirstOrDefaultAsync(h => h.Id == id);

            if (Singer == null)
                return NotFound("Singer wasn't found. Too bad. :(");

            Singer.Name = singer.Name;

            await _context.SaveChangesAsync();

            return Ok(await GetSingersList());
        }

        [HttpDelete("Singers/{id}")]
        public async Task<IActionResult> DeleteSinger(Guid id)
        {
            var Singer = await _context.Singer.FirstOrDefaultAsync(h => h.Id == id);

            if (Singer == null)
                return NotFound("Singer wasn't found. Too bad. :(");

            _context.Singer.Remove(Singer);
            await _context.SaveChangesAsync();

            return Ok(await GetSingersList());
        }



        //Nationalities
        [HttpGet("Nationalities")]
        public async Task<IActionResult> GetNationalities()
        {
            return base.Ok(await GetNationalitiesList());
        }

        private async Task<List<Nationality>> GetNationalitiesList()
        {
            return await _context.Nationality.ToListAsync();
        }

        [HttpGet("Nationalities/{id}")]
        public async Task<IActionResult> GetSingleNationality(Guid id)
        {
            var hero = await _context.Nationality.FirstOrDefaultAsync(h => h.Id == id);
            if (hero == null)
                return NotFound("Nationality wasn't found. Too bad. :(");

            return Ok(hero);
        }

        [HttpPost("Nationalities")]
        public async Task<IActionResult> CreateNationality(Nationality Nationality)
        {
            _context.Nationality.Add(Nationality);
            await _context.SaveChangesAsync();

            return Ok(await GetNationalitiesList());
        }

        [HttpPut("Nationalities/{id}")]
        public async Task<IActionResult> UpdateNationality(Nationality nationality, Guid id)
        {
            var Nationality = await _context.Nationality.FirstOrDefaultAsync(h => h.Id == id);

            if (Nationality == null)
                return NotFound("Nationality wasn't found. Too bad. :(");

            Nationality.Name = nationality.Name;

            await _context.SaveChangesAsync();

            return Ok(await GetNationalitiesList());
        }

        [HttpDelete("Nationalities/{id}")]
        public async Task<IActionResult> DeleteNationality(Guid id)
        {
            var Nationality = await _context.Nationality.FirstOrDefaultAsync(h => h.Id == id);

            if (Nationality == null)
                return NotFound("Nationality wasn't found. Too bad. :(");

            _context.Nationality.Remove(Nationality);
            await _context.SaveChangesAsync();

            return Ok(await GetNationalitiesList());
        }

    }
}
