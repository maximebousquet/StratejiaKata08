using StratejiaKata08.Readable;
using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using StratejiaKata08.Extendible;
using StratejiaKata08.Extendible.DTO;
using StratejiaKata08.Extendible.Interfaces;
using StratejiaKata08.Extendible.Strategies;

// DI Setup
var serviceProvider = new ServiceCollection()
    .AddTransient<ICompoundWordsKata, ExtendibleCompoundWordsKata>()
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
var strategyInput = new CompoundWordsKataInput(words, 6);

var compoundWordsKata = serviceProvider.GetService<ICompoundWordsKata>();

var trieResult = await compoundWordsKata.Execute(strategyInput, CompoundWordStrategyType.TRIE);
var filteredTrieList = trieResult.Distinct();


var CrossProductresult = await compoundWordsKata.Execute(strategyInput, CompoundWordStrategyType.CROSSPRODUCT);
var filteredList = CrossProductresult.Distinct();
var missingResults = CrossProductresult.Except(trieResult);

sw.Stop();

Console.WriteLine(string.Join("\n", missingResults));
Console.WriteLine("CrossProd:" + filteredList.Count());
Console.WriteLine("Trie:" + filteredTrieList.Count());
Console.WriteLine(sw.Elapsed.ToString("mm\\:ss\\.ff"));
