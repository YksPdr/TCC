using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BairroConnectAPI.Data;
using BairroConnectAPI.Models;

namespace BairroConnectAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MunicipeExemploController : ControllerBase
    {
        private readonly DataContext _context;

        public MunicipeExemploController(DataContext context)
        {
            _context = context;
        }

        #region GET

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<Municipe> municipeList = await _context.TB_MUNICIPE.ToListAsync();
                return Ok(municipeList);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao buscar todos os munícipes: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                Municipe municipe = await _context.TB_MUNICIPE.FindAsync(id);
                if (municipe == null)
                {
                    return NotFound($"Munícipe com id {id} não encontrado.");
                }
                return Ok(municipe);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao buscar o munícipe com id {id}: {ex.Message}");
            }
        }

        #endregion

        #region POST

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] Municipe newMunicipe)
        {
            try
            {
                _context.TB_MUNICIPE.Add(newMunicipe);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetById), new { id = newMunicipe.idMunicipe }, newMunicipe);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao adicionar o munícipe: {ex.Message}");
            }
        }


        #endregion

        #region PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Municipe updatedMunicipe)
        {
            try
            {
                if (id != updatedMunicipe.idMunicipe)
                {
                    return BadRequest("Id do munícipe não corresponde ao id fornecido na requisição.");
                }

                _context.Entry(updatedMunicipe).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao atualizar o munícipe com id {id}: {ex.Message}");
            }
        }

        #endregion

        #region DELETE

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var municipeToDelete = await _context.TB_MUNICIPE.FindAsync(id);
                if (municipeToDelete == null)
                {
                    return NotFound($"Munícipe com id {id} não encontrado.");
                }

                _context.TB_MUNICIPE.Remove(municipeToDelete);
                await _context.SaveChangesAsync();

                return Ok(municipeToDelete);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao deletar o munícipe com id {id}: {ex.Message}");
            }
        }

        #endregion

       
    }
}
