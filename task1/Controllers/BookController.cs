using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task1.Data;

namespace task1.Controllers
{
    public class BookController : Controller
    {
        static Library _library = new Library();
        static People _people = new People();


        
        /// <summary>
        /// 4.1.1.	Список всех книг
        /// </summary>
        [HttpGet]
        [Route("GetAllBooks")]
        public List<Book> GetAllBooks()
        {
            return _library.books;
        }

        /// <summary>
        /// 4.1.2.	Список всех книг по автору (фильтрация AuthorId)
        /// </summary>
        [HttpGet]
        [Route("GetAllBooksOfAuthor")]
        public List<Book> GetAllBooksOfAuthor(int authorId)
        {
            return _library.books
                  .Where(x => x.Author == authorId).ToList();

        }

        /// <summary>
        ///4.2.	Реализовать метод POST добавляющий новую книгу
        /// </summary>
        [HttpPost]
        [Route("AddBook")]
        public void AddBook(Book book)
        {
            book.Id =_library.books.Max(x => x.Id) + 1;
            _library.books.Add(book);
        }

        /// <summary>
        ///4.3.	Реализовать метод DELETE удаляющий книгу
        /// </summary>
        [HttpDelete]
        [Route("DeleteBook")]
        public void DeleteBook(int id)
        {
            var book = _library.books.Where(x => x.Id == id).FirstOrDefault();
            if (book != null) _library.books.Remove(book);
        }


        /// <summary>
        /// 2.2.2**	Добавьте в список книг возможность сделать запрос с сортировкой по автору, имени книги и жанру
        /// т.к. в классе Книга сделала только ссылку на автора, то в данном методе использовала join.
        /// </summary>

        [HttpGet]
        [Route(" GetSortBookByAuthor")]
        public List<BookAuthor> GetSortBookByAuthor(SortType sortType)
        {
            var books = _library.books.Join(_people.human,
                x => x.Author,
                t => t.Id,
                (x, t) => new BookAuthor() { Title = x.Title, Genre = x.Genre, Name = t.Name, Surname = t.Surname, Patronymic = t.Patronymic, Birthday = t.Birthday }).ToList();

            if (sortType == SortType.ascending)
                return books.OrderBy(x => x.Surname).ToList();
            else return books.OrderByDescending(x => x.Surname).ToList();
        }

        [HttpGet]
        [Route(" GetSortBookByTitle")]
        public List<Book> GetSortBookByTitle(SortType sortType)
        {
            if (sortType == SortType.ascending)
                return _library.books.OrderBy(x => x.Title).ToList();
            else return _library.books.OrderByDescending(x => x.Title).ToList();
        }

        [HttpGet]
        [Route(" GetSortBookByGenre")]
        public List<Book> GetSortBookByGenre(SortType sortType)
        {
            if (sortType == SortType.ascending)
                return _library.books.OrderBy(x => x.Genre).ToList();
            else return _library.books.OrderByDescending(x => x.Genre).ToList();
        }
    }
}
