using System;
using System.Reflection;
using System.Xml.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        const string InsertNamePosition = "1";
        const string OutputAllList = "2";
        const string RemoveNamePosition = "3";
        const string FindName = "4";
        const string Exit = "5";

        bool isWorking = true;
        string userInput;

        string[] nameArray = { "ФИО" };
        string[] positionArray = { "Должность" };

        Console.WriteLine("Добро пожаловать в Кадровый учёт.");
        Console.WriteLine("\nНажмите любую клавишу для продолжения");
        Console.ReadKey();

        while (isWorking != false)
        {
            Console.Clear();
            Console.WriteLine($"Добавить досье: нажмите     - {InsertNamePosition}");
            Console.WriteLine($"Вывести всё досье: нажмите  - {OutputAllList}");
            Console.WriteLine($"Удалить досье: нажмите      - {RemoveNamePosition}");
            Console.WriteLine($"Поиск по фамилии: нажмите   - {FindName}");
            Console.WriteLine($"Выход: нажмите              - {Exit}");
            Console.Write("\nВаш выбор: ");
            userInput = Console.ReadLine();

            switch (userInput)
            {
                case InsertNamePosition:
                    AddNamePosition(ref nameArray, ref positionArray);
                    break;

                case OutputAllList:
                    GetAllList(nameArray, positionArray);
                    break;

                case RemoveNamePosition:
                    DeleteNamePosition(ref nameArray, ref positionArray);
                    break;

                case FindName:
                    SearchName(nameArray, positionArray);
                    break;

                case Exit:
                    isWorking = false;
                    break;
            }
        }
    }

    static void AddNamePosition(ref string[] nameArray, ref string[] positionArray)
    {
            Console.WriteLine("\nВведите ФИО");
            string name = Console.ReadLine();
            string data = name;

            ResizeUp(ref nameArray, data);

            Console.WriteLine("\nВведите должность");
            string position = Console.ReadLine();
            data = position;
            ResizeUp(ref positionArray, data);
    }

    static void GetAllList(string[] nameArray, string[] positionArray)
    {
        Console.Clear();

        for (int i = 0; i < nameArray.Length; i++)
            Console.WriteLine($"\n{i} | {nameArray[i]} - {positionArray[i]}");

        Console.WriteLine("\nНажмите любую клавишу для продолжения");
        Console.ReadKey();
    }

    static void DeleteNamePosition(ref string[] nameArray, ref string[] positionArray)
    {
        Console.WriteLine("\nВведите порядковый номер");
        int index = Convert.ToInt32(Console.ReadLine());

        if (index < nameArray.Length && index != 0)
        {
            ResizeDown(ref nameArray, index);
            ResizeDown(ref positionArray, index);
        }
        else
        {
            Console.WriteLine("\nТакого порядкового номера не существует! Попробуйте снова.");
        }

        Console.WriteLine("\nНажмите любую клавишу для продолжения");
        Console.ReadKey();
    }

    static void SearchName(string[] nameArray, string[] positionArray)
    {
        bool isFined = false;

        Console.Write("\nВведите полностью Фамилию (регистр не важен): ");
        string userName = Console.ReadLine().ToLower();

        for (int i = 1; i < nameArray.Length; i++)
        {
            string[] newNameArray = nameArray[i].Split(' ');

            if (userName == newNameArray[0].ToLower())
            {
                Console.Write($"\n{i} | {nameArray[i]} - {positionArray[i]}");
                isFined = true;
            }
        }

        if (isFined == false)
        {
            Console.Write("\nТакой фамилии не существует! Попробуйте снова.");
        }

        Console.Write("\n\nНажмите любую клавишу для продолжения");
        Console.ReadKey();
    }

    static void ResizeUp(ref string[] array, string data)
    {
        string[] newArray = new string[array.Length + 1];

        for (int i = 0; i < array.Length; i++)
        {
            newArray[i] = array[i];
        }

        newArray[array.Length] = data;
        array = newArray;
    }

    static void ResizeDown(ref string[] array, int index)
    {
        string[] newArray = new string[array.Length - 1];

        for (int i = 0; i < index; i++)
            newArray[i] = array[i];

        for (int i = index + 1; i < array.Length; i++)
            newArray[i - 1] = array[i];

        array = newArray;
    }
}