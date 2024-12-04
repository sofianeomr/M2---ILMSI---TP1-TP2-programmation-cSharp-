using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<ArticleTypé> articles = new List<ArticleTypé>
        {
            new ArticleTypé("Pomme", 2.5, 50, TypeArticle.Alimentaire),
            new ArticleTypé("Savon", 3.2, 30, TypeArticle.Droguerie),
            new ArticleTypé("T-shirt", 15.0, 20, TypeArticle.Habillement)
        };

        Console.WriteLine("Articles Alimentaires :");
        var articlesAlimentaires = articles.Where(a => a.Type == TypeArticle.Alimentaire);
        foreach (var article in articlesAlimentaires)
        {
            Console.WriteLine($"Nom: {article.Nom}, Prix: {article.Prix}, Stock: {article.Stock}");
        }

        Console.WriteLine("\nArticles Triés par Prix (Décroissant) :");
        var articlesTriesParPrix = articles.OrderByDescending(a => a.Prix);
        foreach (var article in articlesTriesParPrix)
        {
            Console.WriteLine($"Nom: {article.Nom}, Prix: {article.Prix}");
        }

        Console.WriteLine("\nStock Total :");
        var stockTotal = articles.Sum(a => a.Stock);
        Console.WriteLine($"Stock total : {stockTotal}");

        Console.WriteLine("\nArticles Typés dans une Collection Mixte :");
        var mixedCollection = new List<object>
        {
            new ArticleTypé("Pomme", 2.5, 50, TypeArticle.Alimentaire),
            "Un objet quelconque",
            new ArticleTypé("Savon", 3.2, 30, TypeArticle.Droguerie),
            42
        };
        var articlesTypés = mixedCollection.OfType<ArticleTypé>();
        foreach (var article in articlesTypés)
        {
            Console.WriteLine($"Nom: {article.Nom}, Type: {article.Type}");
        }

        Console.WriteLine("\nVue Simplifiée des Articles (Nom et Prix) :");
        var vueSimplifiee = articles.Select(a => new { a.Nom, a.Prix });
        foreach (var article in vueSimplifiee)
        {
            Console.WriteLine($"Nom: {article.Nom}, Prix: {article.Prix}");
        }

        string jsonFilePath = "articles.json";
        JsonHandler.ExportToJson(articles, jsonFilePath);
        Console.WriteLine($"\nLes articles ont été exportés vers le fichier : {jsonFilePath}");

        var importedArticles = JsonHandler.ImportFromJson(jsonFilePath);
        Console.WriteLine("\nArticles Importés depuis JSON :");
        foreach (var article in importedArticles)
        {
            Console.WriteLine($"Nom: {article.Nom}, Prix: {article.Prix}, Stock: {article.Stock}, Type: {article.Type}");
        }

        Console.WriteLine("Liste complète des articles :");
        articles.AfficherTous();

        double valeurTotaleStock = articles.Sum(a => a.Prix * a.Stock);
        Console.WriteLine($"\nValeur totale du stock : {valeurTotaleStock:F2}");

        string jsonFilePath = "articles.json";

        Console.WriteLine("Export des articles vers un fichier JSON...");
        JsonHandler.ExportToJson(articles, jsonFilePath);
        Console.WriteLine($"Les articles ont été exportés vers : {jsonFilePath}");

        Console.WriteLine("\nImport des articles depuis le fichier JSON...");
        var importedArticles = JsonHandler.ImportFromJson(jsonFilePath);

        Console.WriteLine("Articles importés :");
        foreach (var article in importedArticles)
        {
            Console.WriteLine($"Nom: {article.Nom}, Prix: {article.Prix}, Stock: {article.Stock}, Type: {article.Type}");
        }
    }
}
