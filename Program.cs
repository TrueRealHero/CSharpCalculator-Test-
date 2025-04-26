
using System.Xml.XPath;
using MySecondTestAppCalculator;

            Console.WriteLine("Выбери что сделать:"); // ПОЧЕМУ НЕ РАБОТАЕТ!
            Console.WriteLine("1 - Калькулятор");
            Console.WriteLine("2 - Тренировка");
            Console.WriteLine("3 - Еще одна тренировка");

            string? choice = Console.ReadLine();

            if (choice == "1")
            {
                RunCalculator(); // Вызов калькулятора
            }
            else if (choice == "2")
            {
                Training.RunFirstCalc(); // Метод из файла Test1
            }
            else if (choice == "3")
            {
                Training.RunSecondCalc(); // Еще один метод из файла Test1
            }
            else
            {
                Console.WriteLine("Неверный выбор!");
            }
        


static void RunCalculator()
{
    List<string> history = [];


    while(true)
    {
        Console.WriteLine("\n Введи первое число. (Команды: /exit и /history)");
        string input_text_one = Console.ReadLine()!; // Вводим первое число

        if (input_text_one == "/exit")
        {
            Console.WriteLine("Завершение программы...");
            Environment.Exit(0);
        }

        else if (input_text_one == "/history")
        {
            Console.WriteLine("История операции: ");
            foreach (var list in history)
            {
                Console.WriteLine(list);
            }
            continue;
        }

        if (!int.TryParse(input_text_one, out int number_one))
        {
            Console.WriteLine("Это не число!"); // Отработка ошибки
            continue;
        }

        string[] valid_operators = {"+", "-", "/", "*", "/exit", "/history"}; // допустимые символы
        string operation = "";

        while (true)
        {
            Console.WriteLine("Введите оператор или команду");
            operation = Console.ReadLine()!; // Вводим оператор + - / или *

            if (!valid_operators.Contains(operation))
            {
                Console.WriteLine("Такого оператора не существует");
                continue;
            }
        break;
        }

    int number_two = 0;
    // here_start:   // Хотел костыль в ввиде goto сюда сделать. Уже не надо.
        while (true)
        {
        Console.WriteLine("\n Введи второе число. (Команды: /exit и /history)");
        string input_text_two = Console.ReadLine()!;

        if (input_text_two == "/exit")
        {
            Console.WriteLine("Завершение программы...");
            Environment.Exit(0);
        }

        else if (input_text_two == "/history")
        {
            Console.WriteLine("История операции: ");
            foreach (var list in history)
            {
                Console.WriteLine(list);
            }
            continue;
        }
        
        if (!int.TryParse(input_text_two, out number_two))
        {
            Console.WriteLine("Это не число!");
            // goto here_start;  // Костыль
            continue;
        }
        break;
        }   

        double final_result = 0;
        bool validation = true;

        switch(operation) // Логика операторов. Отработка деления на ноль.
        {
            case "+":
                final_result = number_one + number_two;
                break;
            case "-":
                final_result = number_one - number_two;
                break;
            case "*":
                final_result = number_one * number_two;
                break;
            case "/":
                if (number_two == 0)
                {
                    Console.WriteLine("Деление на ноль невозможно!");
                    validation = false;
                }
                else
                {
                    final_result = (double)number_one / number_two;
                }
            break;
            default:
                Console.WriteLine("Неправльная операция или команда: ");
                validation = false;
                continue;
        }

        if (validation == true) // Вывод результата и внесение данных в историю
        {
            string history_list = $"{number_one} {operation} {number_two} = {final_result}";
            Console.WriteLine("Результат: " + final_result);
            history.Add(history_list);
            File.AppendAllText("history.txt", $"{number_one} {operation} {number_two} = {final_result}\n");
        }

    }
}