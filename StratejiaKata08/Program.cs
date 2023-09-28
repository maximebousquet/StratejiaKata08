using StratejiaKata08.Readable;
using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using StratejiaKata08.Extendible;
using StratejiaKata08.Extendible.DTO;
using StratejiaKata08.Extendible.Interfaces;

// DI Setup
var serviceProvider = new ServiceCollection()
    .AddTransient<ICompundWordsKata, ExtendibleCompoundWordsKata>()
    .AddTransient<ICompoundWordsStrategy, CartesianProductStrategy>()
    .AddTransient<ICompoundWordsStrategy, TrieStrategy>()
    .AddTransient<IWordsConcatenationValidator, WordsConcatenationValidator>()
    .BuildServiceProvider();

// Load words
var words = new List<string>();
words = File.ReadAllLines("../../../Resources/words.txt").ToList();

var sw = new Stopwatch();
sw.Start();

// ReadableKata
//var readableKata = new ReadableKata(words);
//var result = await readableKata.Execute();

// ExtendibleKata
var strategyInput = new CartesianStrategyInput(words, 6);

var compoundWordsKata = serviceProvider.GetService<ICompundWordsKata>();

var result = await compoundWordsKata.Execute(strategyInput, CompoundWordStrategyType.CROSSPRODUCT);

sw.Stop();

Console.WriteLine(result.Count);
Console.WriteLine(sw.Elapsed.ToString("mm\\:ss\\.ff"));
