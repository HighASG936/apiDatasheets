using apiDatasheets.DTOs;
using apiDatasheets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace apiDatasheets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatasheetController(DatasheetContext context) : ControllerBase
    {
        private readonly DatasheetContext _context = context;


        [HttpGet]
        public async Task<IEnumerable<DatasheetDto>> Get() =>
            await _context.Datasheets.Select(f => new DatasheetDto
            {
                Id = f.Id,
                Name = f.Name,
                Description = f.Description,
                Filename = f.Filename
            }).ToListAsync();


        [HttpGet("{id}")]
        public async Task<ActionResult<DatasheetDto>> GetById(int id)
        {
            var datasheet = await _context.Datasheets.FindAsync(id);
            if (datasheet == null)
            {
                return NotFound();
            }
            return new DatasheetDto
            {
                Id = datasheet.Id,
                Name = datasheet.Name,
                Description = datasheet.Description,
                Filename = datasheet.Filename
            };
        }


        [HttpPost]
        public async Task<ActionResult<DatasheetDto>> Add(DatasheetDtoInsert datasheetDtoInsert)
        {
            var datasheet = new Datasheet()
            {
                Name = datasheetDtoInsert.Name,
                Description = datasheetDtoInsert.Description,
                Filename = datasheetDtoInsert.Filename
            };

            await _context.AddAsync(datasheet);
            await _context.SaveChangesAsync();

            var datasheetDto = new DatasheetDto()
            {
                Id = datasheet.Id,
                Name = datasheet.Name,
                Description = datasheet.Description,
                Filename = datasheet.Filename
            };

            return CreatedAtAction(nameof(GetById), new { id = datasheet.Id }, datasheetDto);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<DatasheetDto>> Update(int id, DatasheetDtoUpdate datasheetUpdateDto)
        {
            var datasheet = await _context.Datasheets.FindAsync(id);
            if (datasheet == null)
            {
                return NotFound();
            }
            datasheet.Name = datasheetUpdateDto.Name;
            datasheet.Description = datasheetUpdateDto.Description;
            datasheet.Filename = datasheetUpdateDto.Filename;
            await _context.SaveChangesAsync();
            var datasheetDto = new DatasheetDto()
            {
                Id = datasheet.Id,
                Name = datasheet.Name,
                Description = datasheet.Description,
                Filename = datasheet.Filename
            };
            return datasheetDto;
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var beer = await _context.Datasheets.FindAsync(id);
            if (beer == null)
            {
                return NotFound();
            }
            _context.Remove(beer);
            await _context.SaveChangesAsync();
            return NoContent();
        }


    }
}
