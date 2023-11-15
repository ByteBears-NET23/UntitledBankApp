namespace UntitledBankApp.Views.Utilities;

public static class InputUtils
{
    public static string GetNonEmptyString(string prompt)
    {
        while (true)
        {
            Console.Write($"{char.ToUpper(prompt[0]) + prompt[1..].ToLower()}: ");
            var input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
            {
                return input;
            }

            Console.WriteLine("The input cannot be empty!");
        }
    }
}