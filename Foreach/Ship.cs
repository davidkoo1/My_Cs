using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foreach
{
    /*
     
    Его поля string name, int mass (масса в тоннах), bool military - если военный корабль, то true, если не военный - false
Создается список кораблей
1) Вывести названия всех кораблей
2) Вывести массу всех кораблей
3) Вывести название корабля с наибольшй массой
4) Вывести информацию только о военных кораблях
5) Вывести сумму масс всех военных кораблей
6) Вывести самое длинное (по количеству букв) название не военного корабля (То есть самое длинное название среди только не военных)

     */
    public class Ship
    {
        public string name;
        public int massa;
        public bool military;
    }
}
