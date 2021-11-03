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

        Palavra ReturnOneWord(int id);

        void RegisterWord(Palavra palavra);
        void EditWord(int id,Palavra palavra);
        void DeleteWord(int id);

    }
}
