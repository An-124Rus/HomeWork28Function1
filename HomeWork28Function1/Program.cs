using System;
using System.Reflection;
using System.Xml.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        const string insertNamePosition = "1";
        const string outputAllList = "2";
        const string removeNamePosition = "3";
        const string searchName = "4";
        const string exit = "5";

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
            Console.WriteLine($"Добавить досье: нажмите     - {insertNamePosition}");
            Console.WriteLine($"Вывести всё досье: нажмите  - {outputAllList}");
            Console.WriteLine($"Удалить досье: нажмите      - {removeNamePosition}");
            Console.WriteLine($"Поиск по фамилии: нажмите   - {searchName}");
            Console.WriteLine($"Выход: нажмите              - {exit}");
            Console.Write("\nВаш выбор: ");
            userInput = Console.ReadLine();

            switch (userInput)
            {
                case insertNamePosition:
                    InsertNamePosition(ref nameArray, ref positionArray);
                    break;

                case outputAllList:
                    OutputAllList(nameArray, positionArray);
                    break;

                case removeNamePosition:
                    RemoveNamePosition(ref nameArray, ref positionArray);
                    break;

                case searchName:
                    SearchName(nameArray, positionArray);
                    break;

                case exit:
                    isWorking = false;
                    break;
            }
        }
    }

    static void InsertNamePosition(ref string[] nameArray, ref string[] positionArray)
    {
        Console.WriteLine("\nВведите порядковый номер");
        int index = Convert.ToInt32(Console.ReadLine());

        if (index <= nameArray.Length && index != 0)
        {
            Console.WriteLine("\nВведите ФИО");
            string name = Console.ReadLine();
            Console.WriteLine("\nВведите должность");
            string position = Console.ReadLine();

            resizeUpNamePosition(ref nameArray, ref positionArray, index, name, position);
        }
        else
        {
            Console.WriteLine("\nТакого порядкового номера не существует! Попробуйте снова.");
            Console.WriteLine("\nНажмите любую клавишу для продолжения");
            Console.ReadKey();
        }
    }

    static void OutputAllList(string[] nameArray, string[] positionArray)
    {
        Console.Clear();

        for (int i = 0; i < nameArray.Length; i++)
            Console.WriteLine($"\n{i} | {nameArray[i]} - {positionArray[i]}");

        Console.WriteLine("\nНажмите любую клавишу для продолжения");
        Console.ReadKey();
    }

    static void RemoveNamePosition(ref string[] nameArray, ref string[] positionArray)
    {
        Console.WriteLine("\nВведите порядковый номер");
        int index = Convert.ToInt32(Console.ReadLine());

        if (index < nameArray.Length && index != 0)
            resizeDownNamePosition(ref nameArray, ref positionArray, index);
        else
            Console.WriteLine("\nТакого порядкового номера не существует! Попробуйте снова.");

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

    static void resizeUpNamePosition(ref string[] nameArray, ref string[] positionArray, int index, string name, string position)
    {
        string[] newNameArray = new string[nameArray.Length + 1];

        newNameArray[index] = name;

        for (int i = 0; i < index; i++)
            newNameArray[i] = nameArray[i];

        for (int i = index; i < nameArray.Length; i++)
            newNameArray[i + 1] = nameArray[i];

        nameArray = newNameArray;

        string[] newPositionArray = new string[positionArray.Length + 1];

        newPositionArray[index] = position;

        for (int i = 0; i < index; i++)
            newPositionArray[i] = positionArray[i];

        for (int i = index; i < positionArray.Length; i++)
            newPositionArray[i + 1] = positionArray[i];

        positionArray = newPositionArray;
    }

    static void resizeDownNamePosition(ref string[] nameArray, ref string[] positionArray, int index)
    {
        string[] newNameArray = new string[nameArray.Length - 1];

        for (int i = 0; i < index; i++)
            newNameArray[i] = nameArray[i];

        for (int i = index + 1; i < nameArray.Length; i++)
            newNameArray[i - 1] = nameArray[i];

        nameArray = newNameArray;

        string[] newPositionArray = new string[positionArray.Length - 1];

        for (int i = 0; i < index; i++)
            newPositionArray[i] = positionArray[i];

        for (int i = index + 1; i < positionArray.Length; i++)
            newPositionArray[i - 1] = positionArray[i];

        positionArray = newPositionArray;
    }
}