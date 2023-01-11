// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using System.Text;
using VocabularyChecker.Data;
try
{
    bool isWordCheck = true;

    while (true)
    {
        Console.WriteLine("Mode: \n1. Check by words \n2. Check by translate");
        Console.Write("Select: ");
        string mode = Console.ReadLine();
        

        switch (mode)
        {
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

    ApplicationDbContext _context = new ApplicationDbContext();

    int countWords = await _context.Vocabulary.CountAsync();

    Console.Write($"Count of words (Available: {countWords}): ");
    int userCountWords = int.Parse( Console.ReadLine() );
    Console.WriteLine();

    List<Vocabulary> vocabulary = new List<Vocabulary>();
    StringBuilder sql = new StringBuilder();

    if (userCountWords > countWords)
    {
        sql.Append("SELECT * ");
    }
    else
    {        
        sql.Append($"SELECT TOP {userCountWords} * ");           
    }

    sql.Append("FROM Vocabulary ");
    sql.Append("ORDER BY NEWID() ");
    vocabulary = await _context.Vocabulary.FromSqlRaw(sql.ToString()).ToListAsync();

    int ind = 1;

    foreach (var item in vocabulary)
    {
        
        if(isWordCheck)
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
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}
