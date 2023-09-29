using StratejiaKata08.Readable;
using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using StratejiaKata08.Extendible;
using StratejiaKata08.Extendible.DTO;
using StratejiaKata08.Extendible.Interfaces;
using StratejiaKata08.Extendible.Strategies;
using StratejiaKata08.Extendible.Factories;
using StratejiaKata08.Fastest;
using StratejiaKata08.Extendible.Services;
using StratejiaKata08.Extendible.Enums;

// DI Setup
var serviceProvider = new ServiceCollection()
    .AddTransient<ICompoundWordsKata, ExtendibleCompoundWordsKata>()
    .AddTransient<ICompoundWordsStrategy, CartesianProductStrategy>()
    .AddTransient<ICompoundWordsStrategy, TrieStrategy>()
    .AddTransient<IWordsConcatenationValidator, WordsConcatenationValidator>()
    .AddTransient<ICompoundWordsStrategyFactory, CompoundWordsStrategyFactory>()
    .BuildServiceProvider();

var kata = serviceProvider.GetService<ICompoundWordsKata>();

WriteOptions();

while(true)
{
    // Load words
    var words = File.ReadAllLines("../../../Resources/words.txt").ToList();

    var strategyInput = new CompoundWordsKataInput(words, 6);

    switch (Console.ReadLine())
    {
        case "1":
            await ExecuteReadibleKata(words);
            break;
        case "2":
            await ExecuteExtendibleWithCrossProdKata(kata, strategyInput);
            break;
        case "3":
            await ExecuteFastestKata(kata, strategyInput);
            break;
    }

    WriteOptions();
}

static void WriteOptions()
{
    Console.WriteLine("\nChoose an option from the following list:");
    Console.WriteLine("\t1 - Execute Readible Kata");
    Console.WriteLine("\t2 - Execute Extendible Kata (with Cross-product)");
    Console.WriteLine("\t3 - Execute Fastest Kata");
    Console.Write("Your option? ");
}

static async Task ExecuteReadibleKata(List<string> words)
{
    var sw = new Stopwatch();
    sw.Start();

    var readableKata = new ReadableKata(words);
    var result = await readableKata.Execute();

    sw.Stop();

    Console.WriteLine("\nNombre of words: " + result.Count());
    Console.WriteLine("Elapsed time was: " + sw.Elapsed.ToString("mm\\:ss\\.ff"));
}

static async Task ExecuteFastestKata(ICompoundWordsKata compoundWordsKata, CompoundWordsKataInput input)
{
    var sw = new Stopwatch();
    sw.Start();

    var trieResult = await compoundWordsKata.ExecuteAsync(input, CompoundWordStrategyType.TRIE);

    sw.Stop();

    Console.WriteLine("\nNumber of words: " + trieResult.Count());
    Console.WriteLine("Elapsed time was: " + sw.Elapsed.ToString("mm\\:ss\\.ff"));
}

static async Task ExecuteExtendibleWithCrossProdKata(ICompoundWordsKata compoundWordsKata, CompoundWordsKataInput input)
{
    var sw = new Stopwatch();
    sw.Start();

    var result = await compoundWordsKata.ExecuteAsync(input, CompoundWordStrategyType.CROSSPRODUCT);
    var filteredResult = result.Distinct();

    sw.Stop();

    Console.WriteLine("\nNumber of words: " + result.Count());
    Console.WriteLine("Elapsed time was: " + sw.Elapsed.ToString("mm\\:ss\\.ff"));
}
