using System;
using System.Collections.Generic;
using System.Text;

namespace MDA.OIP.ScoreModel
{
    public static class Tie // класс для заполнения объекта класса Note данными, в зависимости от наличия лиги
    {
        static public int None // Нет Лиги (-1)
        {
            get
            {
                return -1;
            }    
        }
        static public int Start // Начало Лиги (0)
        {
            get
            {
                return 0;
            }    
        }
        static public int Stop  // Конец Лиги (1)
        {
            get
            {
                return 1;
            }    
        }

    }
}
