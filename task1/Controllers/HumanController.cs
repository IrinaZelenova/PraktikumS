using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task1.Data;

namespace task1.Controllers
{

    /// <summary>
    /// 3.	контроллер, который отвечает за человека
    /// </summary>
    [ApiController]
    public class HumanController : Controller
    {
        static People _people=new People();
        static Library _library = new Library();

        /// <summary>
        /// 3.1.1.	Список всех людей
        /// </summary>
        [HttpGet]
        [Route("GetAll")]
        public List<Human> GetAll()
        {
            return _people.human;
        }

        /// <summary>
        ///3.1.2.	Список людей, которые пишут книги
        /// </summary>
        [HttpGet]
        [Route("GetAllWriters")]
        public List<Human> GetAllWriters()
        {
            var author = _library.books.
                         Select(x => x.Author).Distinct().ToList();
            return _people.human
                    .Where(x => author.Contains(x.Id)).ToList();
        }

        /// <summary>
        ///3.1.3.	Поиск людей, в имени, фамилии или отчестве которых содержится поисковая фраза (query)
        /// </summary>
        [HttpGet]
        [Route("GetHuman/{search}")]
        public List<Human> GetHuman(string search="query")
        {
            return _people.human
                   .Where(x => x.Name.IndexOf(search) > -1 || x.Surname.IndexOf(search) > -1 || x.Patronymic.IndexOf(search) > -1).ToList();
        }

        /// <summary>
        ///3.2.	Реализовать метод POST добавляющий нового человека.
        /// </summary>
        [HttpPost]
        [Route("AddHuman")]
        public void AddHuman(Human human)
        {
            human.Id = _people.human.Max(x => x.Id) + 1;
            _people.human.Add(human);
        }

        /// <summary>
        ///3.3.	Реализовать метод DELETE удаляющий человека
        /// </summary>
        [HttpDelete]
        [Route("DeleteHuman")]
        public void DeleteHuman(int id)
        {
            var human = _people.human.Where(x => x.Id == id).FirstOrDefault();
            if (human!=null) _people.human.Remove(human);
        }

    }
}
