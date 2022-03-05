﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace task1.Data
{
    /// <summary>
    /// 2.2.1 Класс Человек
    /// </summary>
    public class Human
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime Birthday { get; set; }
                
    }

    /// <summary>
    /// 2.2.3 Статичный список людей
    /// </summary>
    public class People
    {
        public List<Human> human = new List<Human>
           {
               new(){Id= 1,Name="Антон",Patronymic="Павлович",Surname="Чехов",Birthday=new DateTime(1860,1,17)},
               new(){Id= 2,Name="Эрих",Surname="Ремарк",Patronymic="Пауль",Birthday=new DateTime(1898,6,22)},
               new(){Id= 3,Name="Александр",Surname="Твардовский",Patronymic="Трифонович",Birthday=new DateTime(1910,6,21)}
           };
    }
}
