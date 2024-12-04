using System;
using System.Collections.Generic;

public static class Extensions
{
    public static void AfficherTous(this List<ArticleTypé> articles)
    {
        foreach (var article in articles)
        {
            Console.WriteLine($"Nom: {article.Nom}, Prix: {article.Prix}, Stock: {article.Stock}, Type: {article.Type}");
        }
    }
}
