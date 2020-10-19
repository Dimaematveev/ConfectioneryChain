using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfectioneryChain.DB.Inheritance
{
    public abstract class General 
    {
        /// <summary>
        /// Получить новый класс General
        /// </summary>
        /// <returns>Создает новый класс</returns>
        public abstract General CreateNew();

        /// <summary>
        /// Заполнить текущий объект из переданного
        /// без общих свойств(ID)
        /// </summary>
        /// <param name="copy">переданный объект</param>
        public abstract void Fill(General copy);

        /// <summary>
        /// Заполнить текущий объект из переданного 
        /// с общими свойствами(ID)
        /// </summary>
        /// <param name="copy">переданный объект</param>
        public abstract void AllFill(General copy);


        /// <summary>
        /// Скопировать текущий объект в новый 
        /// без общих свойств(ID)
        /// </summary>
        /// <returns>Новый объект с такими-же свойствами</returns>
        public General Clone()
        {
            General newGeneral = CreateNew();
            newGeneral.Fill(this);
            return newGeneral;
        }

        /// <summary>
        /// Скопировать текущий объект в новый
        /// с общими свойствами (ID)
        /// </summary>
        /// <returns>Новый объект с такими-же свойствами</returns>
        public General AllClone()
        {
            General newGeneral = Clone();
            newGeneral.AllFill(this);
            return newGeneral;
        }
    }
}
