using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProstakishinaLibraryLib;

namespace ProstakishinaTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LibraryFunctions library = new LibraryFunctions();

            Console.WriteLine("                    ТЕСТИРОВАНИЕ БИБЛИОТЕКИ                  \n");

            //GetLibraryName - метод возвращает ФИО главного библиотекаря
            Console.WriteLine("1. Название библиотеки:");
            Console.WriteLine("   " + library.GetLibraryName());

            // GetChiefLibrarian - метод возвращает название библиотеки
            Console.WriteLine("\n2. Главный библиотекарь (изначально):");
            Console.WriteLine("   " + library.GetChiefLibrarian());

            // SetChiefLibrarian - метод изменяет ФИО главного библиотекаря,
            //  только если данное ФИО есть в списке сотрудников
            Console.WriteLine("\n3. Введите ФИО, чтобы попробовать назначить его главным библиотекарем:");
            string candidate = Console.ReadLine();

            string oldChief = library.GetChiefLibrarian(); // запоминаем, кто был главным
            library.SetChiefLibrarian(candidate);
            string newChief = library.GetChiefLibrarian();

            Console.WriteLine("   Было: " + oldChief);
            Console.WriteLine("   Стало: " + newChief);

            if (oldChief == newChief)
            {
                Console.WriteLine("   Результат: смена НЕ произошла (такого ФИО нет в списке сотрудников).");
            }
            else
            {
                Console.WriteLine("   Результат: смена ПРОИЗОШЛА успешно (ФИО найдено в списке).");
            }


            // GenerateBookCode - метод формирует код книги вида CAT_number
            Console.WriteLine("\n4. Генерация кодов книг (введите 'выход', чтобы закончить):");

            while (true)
            {
                Console.WriteLine("   Введите категорию книги:");
                string CAT = Console.ReadLine();

                if (CAT.ToLower() == "выход")
                {
                    Console.WriteLine("   Генерация завершена.");
                    break;
                }

                if (string.IsNullOrWhiteSpace(CAT))
                {
                    Console.WriteLine("   Пустая строка. Попробуйте ещё раз.");
                    continue;
                }

                string number = library.GenerateBookCode(CAT, 0);
                Console.WriteLine("   Сгенерированный код: " + number);
                Console.WriteLine();
            }

            // GetStaff - метод возвращает списоксотрудниковбиблиотеки
            Console.WriteLine("\n5. Список сотрудников:");
            Console.WriteLine("   - " + string.Join("\n   - ", library.GetStaff()));

            // AddStaff - метод добавляет нового сотрудникавсписок сотрудников
            Console.WriteLine("\n6. Добавляем нового сотрудника в список:");
            Console.WriteLine("\n Введите ФИО нового сотрудника для добавления:");
            string newStaff = Console.ReadLine();
            library.AddStaff(newStaff);
            Console.WriteLine("\n   Список после добавления:");
            Console.WriteLine("   - " + string.Join("\n   - ", library.GetStaff()));

            Console.WriteLine("\n                      ТЕСТИРОВАНИЕ ЗАВЕРШЕНО                      ");
          
        }
    }
}
