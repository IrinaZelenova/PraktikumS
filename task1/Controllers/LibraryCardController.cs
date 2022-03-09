using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task1.Data;

namespace task1.Controllers
{
    [ApiController]
    public class LibraryCardController : Controller
    {
        static LibraryCards _libraryCards = new LibraryCards();

        /// <summary>
        ///2.1 * 4.	В контроллере создать метод POST отвечающий за взятие книги читателем. На вход - вышеописанный объект
        /// </summary>
        [HttpPost]
        [Route("AddLibraryCard")]
        public void AddLibraryCard(LibraryCard libraryCard)
        {
            if (_libraryCards.libraryCard.Count > 0) libraryCard.Id = _libraryCards.libraryCard.Max(x => x.Id) + 1;
            else libraryCard.Id = 1;

            _libraryCards.libraryCard.Add(libraryCard);
        }
    }
}
