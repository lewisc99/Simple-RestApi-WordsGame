using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{

    [ApiController]
    [Route("api/[Controller]")]
    public class PalavrasController : ControllerBase
    {

        private IPalavraRepository _dbPalavra;

        public PalavrasController(IPalavraRepository palavra)
        {
            _dbPalavra = palavra;
        }


        [HttpGet("",Name ="ReturnAll")]
        public  async Task<ActionResult> ReturnAll([FromQuery]string query)
        {

          

            var obj = await _dbPalavra.ReturnAllWords();

            return Ok(obj);

        }


        [HttpGet("{id}")]
        public async Task<ActionResult> ReturnOne(int id)
        {
            var findId = await _dbPalavra.ReturnOneWord(id);

            if (findId == null)
            {
                return NotFound();
            }


            return Ok(findId);
        }

        [HttpPost]
        public async Task<ActionResult> Register([FromBody] Palavra palavra)
        {
            if( palavra == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid )
            {
                return BadRequest();
            }


            await _dbPalavra.RegisterWord(palavra);

            return Created($"/api/palavras/{palavra.Id}", palavra);


        }


        [HttpPut("{id}",Name ="EditWord")]
        public async Task<ActionResult> EditId(int id, [FromBody] Palavra palavra)
        {
            if (palavra == null)
            {
                return BadRequest(); 
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
        
            
                var findId = await  _dbPalavra.ReturnOneWord(id);

                if (findId == null)
                {
                    return NotFound();
                }
            await _dbPalavra.EditWord(id, palavra);

                return Ok(palavra);


        }

        [HttpDelete("{id}",Name ="DeleteWord")]
        public async Task<ActionResult> Delete(int id)
        {
            var obj = await _dbPalavra.ReturnOneWord(id);

            if (obj == null)
            {
                return NotFound();
            }


            await  _dbPalavra.DeleteWord(id);


         return   Ok();
        }
    }
}
