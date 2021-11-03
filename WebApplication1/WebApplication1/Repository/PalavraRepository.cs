using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Database;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class PalavraRepository : IPalavraRepository
    {

        private readonly PalavraContext _dbPalavra;


      public  PalavraRepository(PalavraContext palavra)
        {
            _dbPalavra = palavra;
        }

        public async Task DeleteWord(int id)
        {
            var returnId =await ReturnOneWord(id);

            if (returnId.Id == id)
            {
                _dbPalavra.Remove(returnId);
               await _dbPalavra.SaveChangesAsync();
            }
        }

        public async Task EditWord(int id, Palavra palavra)
        {
           var returnId = await ReturnOneWord(id);

            if (returnId.Id == palavra.Id)
            {
                palavra.Atualizado = DateTime.Now;
                _dbPalavra.Update(palavra);
               await _dbPalavra.SaveChangesAsync();
            }

        }

        public async Task RegisterWord(Palavra palavra)
        {

            _dbPalavra.Add(palavra);

           await _dbPalavra.SaveChangesAsync();
        }

        public  IQueryable<Palavra> ReturnAllWords()
        {
            

            return  (IQueryable<Palavra> )  _dbPalavra.palavra.AsNoTracking(); 

        }

       

        public async Task<Palavra> ReturnOneWord(int id)
        {



            var find = await _dbPalavra.palavra.AsNoTracking().FirstOrDefaultAsync(bank => bank.Id == id);

            return find;

        }
    }
}
