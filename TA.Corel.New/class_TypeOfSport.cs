using System;
using System.Collections.Generic;
using System.Text;

namespace TA.Corel
{
    /// <summary>
    /// Описывает доступные виды спорта
    /// </summary>
    public class TypeOfSport
    {
        /// <summary>
        /// Идентификатор вида спорта
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Название вида спорта
        /// </summary>
        public string Name { get; set; }
        public TypeOfSport()
        {
            Id = 0; Name = "";
        }
        public TypeOfSport(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public override string ToString()
        {
            return Name;
        }
    }

}
