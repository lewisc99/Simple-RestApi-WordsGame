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
        public  ActionResult ReturnAll([FromQuery]string query)
        {

          

            var obj = _dbPalavra.ReturnAllWords();

            return Ok(obj);

        }


        [HttpGet("{id}")]
        public ActionResult ReturnOne(int id)
        {
            var findId = _dbPalavra.ReturnOneWord(id);

            if (findId == null)
            {
                return NotFound();
            }


            return Ok(findId);
        }

        [HttpPost]
        public ActionResult Register([FromBody] Palavra palavra)
        {
            if(palavra == null)
            {
                return BadRequest();
            }




            _dbPalavra.RegisterWord(palavra);

            return Created($"/api/palavras/{palavra.Id}",palavra);
        }


        [HttpPut("{id}",Name ="EditWord")]
        public ActionResult EditId(int id, [FromBody] Palavra palavra)
        {

            if (palavra == null)
            {
                return BadRequest();
            }

            var findId = _dbPalavra.ReturnOneWord(id);
           


            if (findId == null)
            {
                return NotFound();
            }
            _dbPalavra.EditWord(id, palavra);

            return Ok(palavra);


        }

        [HttpDelete("{id}",Name ="DeleteWord")]
        public ActionResult Delete(int id)
        {
            var obj = _dbPalavra.ReturnOneWord(id);

            if (obj == null)
            {
                return NotFound();
            }


            _dbPalavra.DeleteWord(id);


         return   RedirectToAction("ReturnAll");
        }
    }
}
