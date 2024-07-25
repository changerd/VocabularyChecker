// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using VocabularyChecker.Data;



try
{
    await using var _context = new ApplicationDbContext();
    bool isWordCheck = true;

    while (true)
    {
        Console.WriteLine("Mode: \n0.Vocabulary \n1. Check by words \n2. Check by translate");
        Console.Write("Select: ");
        string mode = Console.ReadLine();

        switch (mode)
        {
            case "0":
                await DisplayVocabulary(_context);
                continue;
            case "1":
                isWordCheck = true;
                break;
            case "2":
                isWordCheck = false;
                break;
            default:
                continue;
        }

        break;
    }

    int countWords = await _context.Vocabulary.CountAsync();

    Console.Write($"Count of words (Available: {countWords}): ");
    if (!int.TryParse(Console.ReadLine(), out int userCountWords) || userCountWords <= 0)
    {
        Console.WriteLine("Invalid number entered.");
        return;
    }

    if (userCountWords > countWords)
    {
        userCountWords = countWords;
    }

    var vocabulary = await _context.Vocabulary
        .OrderBy(v => EF.Functions.Random())
        .Take(userCountWords)
        .ToListAsync();

    int ind = 1;

    foreach (var item in vocabulary)
    {
        if (isWordCheck)
        {
            Console.WriteLine($"{ind}. {item.Word}");
            Console.Write("Ask: ");
            Console.ReadLine();
            Console.WriteLine($"Answer: {item.Transaltion}\n");
        }
        else
        {
            Console.WriteLine($"{ind}. {item.Transaltion}");
            Console.Write("Ask: ");
            Console.ReadLine();
            Console.WriteLine($"Answer: {item.Word}\n");
        }

        ind++;
    }

    Console.WriteLine("The end!");
    Console.ReadKey();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}


static async Task DisplayVocabulary(ApplicationDbContext context)
{
    List<Vocabulary> vocabularyList = await context.Vocabulary.OrderBy(v => v.Word).ToListAsync();

    char currentLetter = '\0';
    foreach (var vocabulary in vocabularyList)
    {
        if (vocabulary.Word[0] != currentLetter)
        {
            Console.WriteLine("\n" + new string('-', Console.WindowWidth - 1));
            currentLetter = vocabulary.Word[0];
        }

        Console.WriteLine("| " + vocabulary.Word.PadRight(20) + " | " + vocabulary.Transaltion.PadRight(50) + " |");
    }

    Console.WriteLine(new string('-', Console.WindowWidth - 1));
}
