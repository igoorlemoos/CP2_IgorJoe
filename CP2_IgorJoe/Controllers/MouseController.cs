using CP2_IgorJoe.Data;
using CP2_IgorJoe.DTOs;
using CP2_IgorJoe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace CP2_IgorJoe.Controllers
{
    [Route("api/mouse")]
    [ApiController]
    public class MouseController : ControllerBase
    {
        private readonly DataContext _context;

        public MouseController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetMouses()
        {
            var mouses = await _context.Mouses.ToListAsync();
            return Ok(mouses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMouses(int id)
        {
            var mouse = await _context.Mouses.FindAsync(id);

            if (mouse == null)
            {
                return NotFound();
            }

            return Ok(mouse);
        }

        [HttpPost]
        public async Task<IActionResult> AddMouse([FromBody] MousesDTO mouseDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mouse = new Mouses
            {
                Modelo = mouseDTO.Modelo,
                Marca = mouseDTO.Marca,
                Peso = mouseDTO.Peso,
                Preco = mouseDTO.Preco
            };

            _context.Mouses.Add(mouse);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMouses), new { id = mouse.Id }, mouse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMouse(int id, [FromBody] MousesDTO mouseDTO)
        {
            if (id != mouseDTO.Id)
            {
                return BadRequest();
            }

            var mouse = await _context.Mouses.FindAsync(id);

            if (mouse == null)
            {
                return NotFound();
            }

            mouse.Modelo = mouseDTO.Modelo;
            mouse.Marca = mouseDTO.Marca;
            mouse.Peso = mouseDTO.Peso;
            mouse.Preco = mouseDTO.Preco;
            

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MouseExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMouse(int id)
        {
            var mouse = await _context.Mouses.FindAsync(id);
            if (mouse == null)
            {
                return NotFound();
            }

            _context.Mouses.Remove(mouse);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MouseExists(int id)
        {
            return _context.Mouses.Any(e => e.Id == id);
        }
    }
}
