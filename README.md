# VocabularyChecker

VocabularyChecker is a console application designed to help you practice and test your vocabulary knowledge. It allows you to store words and their translations in a database, display the vocabulary, and check your knowledge by prompting you with either the word or its translation.

## Features

- **Display Vocabulary**: View all words and their translations stored in the database.
- **Check by Words**: Test your knowledge by being prompted with a word and providing its translation.
- **Check by Translations**: Test your knowledge by being prompted with a translation and providing the corresponding word.

## Getting Started

### Prerequisites

- .NET SDK
- SQL Server

### Setting up the Database

First, create a database named `Vocabulary` and execute the following SQL script to create the `Vocabulary` table:

```sql
USE [Vocabulary]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Vocabulary](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [Word] [nvarchar](max) NOT NULL,
    [Transaltion] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Vocabulary] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
```

### Configuring the Application

The application uses Entity Framework Core for database access. Ensure that the connection string in ApplicationDbContext.cs points to your SQL Server instance:

```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=Vocabulary;Integrated Security=True;TrustServerCertificate=True");
}
```

### Running the Application

1. Build the application using the .NET CLI:
```sh
dotnet build
```

2. Run the application:
```sh
dotnet run
```

### Usage

Upon running the application, you will be prompted to select a mode:

- '0': Display Vocabulary
- '1': Check by Words
- '2': Check by Translations

Follow the prompts to interact with the application.

### Example
```vbnet
Mode: 
0.Vocabulary 
1. Check by words 
2. Check by translate
Select: 1
Count of words (Available: 10): 5
1. apple
Ask: 
Answer: яблоко

2. orange
Ask: 
Answer: апельсин

...

The end!
```

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more information.
