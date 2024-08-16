using System;
using System.Collections.Generic;
using TheatricalPlayersRefactoringKata.Domain;
using TheatricalPlayersRefactoringKata.Services;


namespace MyTheatricalApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var plays = new Dictionary<string, Play>
            {
                { "hamlet", new Play("Hamlet", 4024, "tragedy") },
                { "as-like", new Play("As You Like It", 2670, "comedy") },
                { "othello", new Play("Othello", 3560, "tragedy") }
            };

            Invoice invoice = new Invoice(
                "BigCo",
                new List<Performance>
                {
                    new Performance("hamlet", 55),
                    new Performance("as-like", 35),
                    new Performance("othello", 40)
                }
            );

            StatementPrinter statementPrinter = new StatementPrinter();
            var result = statementPrinter.Print(invoice, plays);

            Console.WriteLine(result);
        }
    }

    // Classes Play, Invoice, Performance, StatementPrinter devem ser implementadas aqui ou em arquivos separados
}