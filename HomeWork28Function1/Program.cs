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

        string[] NameArray = { "ФИО" };
        string[] PositionArray = { "Должность" };

        Console.WriteLine("Добро пожаловать в Кадровый учёт.");
        Console.WriteLine("\nНажмите клавишу - Ввод для продолжения");
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

                    InsertNamePosition(ref NameArray, ref PositionArray);

                    break;

                case outputAllList:

                    OutputAllList(NameArray, PositionArray);

                    break;

                case removeNamePosition:

                    RemoveNamePosition(ref NameArray, ref PositionArray);

                    break;

                case searchName:

                    SearchName(NameArray, PositionArray);

                    break;

                case exit:
                    isWorking = false;
                    break;
            }
        }
    }

    static void InsertNamePosition(ref string[] NameArray, ref string[] PositionArray)
    {
        Console.WriteLine("\nВведите порядковый номер");
        int index = Convert.ToInt32(Console.ReadLine());

        if (index <= NameArray.Length && index != 0)
        {
            Console.WriteLine("Введите ФИО");
            string name = Console.ReadLine();
            Console.WriteLine("\nВведите должность");
            string position = Console.ReadLine();

            string[] NewNameArray = new string[NameArray.Length + 1];

            NewNameArray[index] = name;

            for (int i = 0; i < index; i++)
                NewNameArray[i] = NameArray[i];

            for (int i = index; i < NameArray.Length; i++)
                NewNameArray[i + 1] = NameArray[i];

            NameArray = NewNameArray;

            string[] NewPositionArray = new string[PositionArray.Length + 1];

            NewPositionArray[index] = position;

            for (int i = 0; i < index; i++)
                NewPositionArray[i] = PositionArray[i];

            for (int i = index; i < PositionArray.Length; i++)
                NewPositionArray[i + 1] = PositionArray[i];

            PositionArray = NewPositionArray;
        }
        else
        {
            Console.WriteLine("\nТакого порядкового номера не существует! Попробуйте снова.");
            Console.WriteLine("\nНажмите клавишу - Ввод для продолжения");
            Console.ReadKey();
        }
    }

    static void OutputAllList(string[] NameArray, string[] PositionArray)
    {
        Console.Clear();

        for (int i = 0; i < NameArray.Length; i++)
            Console.WriteLine($"\n{i} | {NameArray[i]} - {PositionArray[i]}");

        Console.WriteLine("\nНажмите клавишу - Ввод для продолжения");
        Console.ReadKey();
    }

    static void RemoveNamePosition(ref string[] NameArray, ref string[] PositionArray)
    {
        Console.WriteLine("\nВведите порядковый номер");
        int index = Convert.ToInt32(Console.ReadLine());

        if (index < NameArray.Length && index != 0)
        {
            string[] NewNameArray = new string[NameArray.Length - 1];

            for (int i = 0; i < index; i++)
                NewNameArray[i] = NameArray[i];

            for (int i = index + 1; i < NameArray.Length; i++)
                NewNameArray[i - 1] = NameArray[i];

            NameArray = NewNameArray;

            string[] NewPositionArray = new string[PositionArray.Length - 1];

            for (int i = 0; i < index; i++)
                NewPositionArray[i] = PositionArray[i];

            for (int i = index + 1; i < PositionArray.Length; i++)
                NewPositionArray[i - 1] = PositionArray[i];

            PositionArray = NewPositionArray;
        }
        else
        {
            Console.WriteLine("\nТакого порядкового номера не существует! Попробуйте снова.");
        }

        Console.WriteLine("\nНажмите клавишу - Ввод для продолжения");
        Console.ReadKey();
    }
    
    static void SearchName(string[] NameArray, string[] PositionArray)
    {
        bool nameIsFined = false;

        Console.Write("\nВведите Фамилию: ");
        string name = Console.ReadLine();

        for (int i = 0; i < NameArray.Length; i++)
        {
            if (name.ToLower() == NameArray[i].ToLower())
            {
                Console.Write($"\n{i} | {NameArray[i]} - {PositionArray[i]}");
                nameIsFined = true;
            }
        }

        if (nameIsFined == false)
        {
            Console.Write("Такой фамилии не существует! Попробуйте снова.");
        }

        Console.WriteLine("\nНажмите клавишу - Ввод для продолжения");
        Console.ReadKey();
    }
}