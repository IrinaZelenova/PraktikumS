using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace task1.Data
{

    /// <summary>
    /// 2.1* 1.	Создать новую сущность-агрегатор (LibraryCard)
    /// 2.2.1**.	Добавьте валидации в ваши сущности: все обязательные поля должны быть NotNull.
    /// </summary>

    public class LibraryCard
    {
        public int Id { get; set; }

        [Required]
        public int HumanId { get; set; }

        [Required]
        public int BookId { get; set; }

        [Required]
        public DateTimeOffset GivenBook { get; set; }
       
    }

    /// <summary>
    /// 2.1*3.	Создать пустой список, отвечающий за хранение этих сущностей
    /// </summary>
    public class LibraryCards
    {
        public List<LibraryCard> libraryCard = new List<LibraryCard>();
    }
}
