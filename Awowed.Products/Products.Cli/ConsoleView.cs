using System;
using System.Globalization;
using Products.Application.View;
using Products.Domain.Models;

namespace Products.Cli
{
    public class ConsoleView : IView
    {
        private T DisplayAndGet<T>(Predicate<T>? condition, params string[] messages) where T : IConvertible
        {
            T result;
            
            foreach (var message in messages)
                Console.WriteLine(message);

            while (true)
            {
                Console.Write("> ");
                var strResult = Console.ReadLine();

                if (typeof(T) == typeof(double))
                    strResult = strResult?.Replace('.', ',');

                try
                {
                    result = (T)((IConvertible) strResult)?.ToType(typeof(T), null);
                    if(condition != null && !condition(result))
                        throw new FormatException();
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Enter in correct format!");
                }
            }
            

            return result;
        }

        public void ShowMessage(string message) => Console.WriteLine(message);

        public int ShowMainMenu() =>
            DisplayAndGet<int>(r => r == 1 || r == 2 || r == 3, "What do u wanna do?",
                "1 - Register", "2 - Authorize",
                "3 - Continue as guest");

        public (string, string) ShowAuthorization()
        {
            var login = DisplayAndGet<string>(null, "Enter your login");
            var password = DisplayAndGet<string>(null, "Enter your password");
            return (login, password);
        }

        public (string, string) ShowRegistration()
        {
            var login = DisplayAndGet<string>(null, "Enter login");
            var password = DisplayAndGet<string>(null, "Enter password");
            var repeatPassword = DisplayAndGet<string>(null, "Repeat password");
            if (password == repeatPassword) return (login, password);
            ShowMessage("Passwords are different");
            return ShowRegistration();
        }
    }
}