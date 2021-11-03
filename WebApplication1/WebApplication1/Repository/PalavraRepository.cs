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

        public void DeleteWord(int id)
        {
            var returnId = ReturnOneWord(id);

            if (returnId.Id == id)
            {
                _dbPalavra.Remove(returnId);
                _dbPalavra.SaveChanges();
            }
        }

        public void EditWord(int id, Palavra palavra)
        {
           var returnId =  ReturnOneWord(id);

            if (returnId.Id == palavra.Id)
            {
                _dbPalavra.Update(palavra);
                _dbPalavra.SaveChanges();
            }

        }

        public void RegisterWord(Palavra palavra)
        {

            _dbPalavra.Add(palavra);

            _dbPalavra.SaveChanges();
        }

        public  IQueryable<Palavra> ReturnAllWords()
        {
            

            return (IQueryable<Palavra>)_dbPalavra.palavra.AsNoTracking(); 

        }

       

        public Palavra ReturnOneWord(int id)
        {



            var find = _dbPalavra.palavra.AsNoTracking().FirstOrDefault(bank => bank.Id == id);

            return find;

        }
    }
}
