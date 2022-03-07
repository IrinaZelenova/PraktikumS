using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace task1.Data
{
    /// <summary>
    /// 2.2	Класс книга
    /// 2.2.1**.	Добавьте валидации в ваши сущности: все обязательные поля должны быть NotNull.
    /// </summary>
    public class Book
    {
       
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Author { get; set; }

        [Required]
        public GenreType Genre { get; set; }
        
    }

    /// <summary>
    /// 2.3.	Статичный список книг.
    /// </summary>
    public class Library
    {
        public List<Book> books = new List<Book>
        {
            new(){Id=1,Title="Хамелеон",Author=1,Genre=GenreType.Story},
            new(){Id=2,Title="Толстый и тонкий",Author=1,Genre=GenreType.Story},
            new(){Id=3,Title="Три товарища",Author=2,Genre=GenreType.Novel}
        };
    }

    public enum GenreType
    {
        [Description("Рассказ")]
        Story = 0,
        [Description("Роман")]
        Novel = 1
    }

    public enum SortType
    {
        [Description("В порядке убывания")]
        descending = -1,
        [Description("В порядке возрастания")]
        ascending = 1
    }

    public class BookAuthor
    {
        public string Title { get; set; }
        public GenreType Genre { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime Birthday { get; set; }
    }


}
