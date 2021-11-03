using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
   public interface IPalavraRepository
    {

       IQueryable<Palavra> ReturnAllWords();

        Task<Palavra> ReturnOneWord(int id);

        Task RegisterWord(Palavra palavra);
        Task EditWord(int id,Palavra palavra);
        Task DeleteWord(int id);

    }
}
