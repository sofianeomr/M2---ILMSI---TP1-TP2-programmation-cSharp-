public class ArticleTypé
{
    public string Nom { get; set; }
    public double Prix { get; set; }
    public int Stock { get; set; }
    public TypeArticle Type { get; set; }

    public ArticleTypé(string nom, double prix, int stock, TypeArticle type)
    {
        Nom = nom;
        Prix = prix;
        Stock = stock;
        Type = type;
    }
}
