using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace task1.Data
{
    /// <summary>
    /// 2.2	Класс книга
    /// </summary>
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Author { get; set; }
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

    
}
