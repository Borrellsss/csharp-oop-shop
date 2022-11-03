//Nel progetto csharp-oop-shop, creare la classe Prodotto che gestisce i prodotti dello shop. Un prodotto è caratterizzato da:
//codice(numero intero)
//nome
//descrizione
//prezzo
//iva
//Usate opportunamente i livelli di accesso (public, private), i costruttori, i metodi getter e setter ed eventuali altri metodi di “utilità” per fare in modo che:
//alla creazione di un nuovo prodotto il codice sia valorizzato con un numero random
//Il codice prodotto sia accessibile solo in lettura V
//Gli altri attributi siano accessibili sia in lettura che in scrittura V
//Il prodotto esponga sia un metodo per avere il prezzo base che uno per avere il prezzo comprensivo di iva V
//Il prodotto esponga un metodo per avere il nome esteso, ottenuto concatenando codice + nome V
//Nella vostro programma principale, testate tutte le funzionalità della classe Prodotto.
//BONUS: create un metodo che restituisca il codice con un pad left di 0 per arrivare a 8 caratteri (ad esempio codice 91 diventa 00000091, mentre codice 123445567 resta come è)

Console.WriteLine("crea una nuova istanza della classe \"Product\":");
Console.WriteLine();

Console.Write("nome: ");
string userProductName = Console.ReadLine();

Console.Write("decrizione: ");
string userProductDescription = Console.ReadLine();

Console.Write("prezzo: ");
double userProductPrice = Convert.ToDouble(Console.ReadLine());

Console.Write("iva: ");
int userProductIva = Convert.ToInt32(Console.ReadLine());

Product testProduct = new Product(userProductName, userProductDescription, userProductPrice, userProductIva);

Console.WriteLine("dettagli istanza della classe \"Product\" appena creata:");
Console.WriteLine($"codice: {testProduct.Code}");
Console.WriteLine($"nome: {testProduct.Name}");
Console.WriteLine($"descrizione: {testProduct.Description}");
Console.WriteLine($"prezzo: {testProduct.Price}");
Console.WriteLine($"iva: {testProduct.Iva}");
Console.WriteLine($"prezzo con iva: {testProduct.GetPricePlusIva()}");
Console.WriteLine($"nome più codice: {testProduct.GetExtendedName()}");
Console.WriteLine($"codice con aggiunta, se necessario, del \"pad-left\": {testProduct.AddPadLeft()}");

public class Product
{
    public int Code { get; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public int Iva { get; set; }

    //Construct

    public Product(string name, string description, double price, int iva)
    {
        this.Code = new Random().Next(1, 99999999);
        this.Name = name;
        this.Description = description;
        this.Price = price;
        this.Iva = iva;
    }

    //Getters

    public string GetPricePlusIva()
    {
        string finalPrice = $"{Math.Round(this.Price + ((this.Price * this.Iva) / 100), 2)} euro"; 

        return finalPrice;
    }

    public string GetExtendedName()
    {
        string extendedName = $"{this.Code} - {this.Name}";

        return extendedName;
    }

    //other methods

    public string AddPadLeft()
    {
        string codeToString = Convert.ToString(this.Code);

        if (codeToString.Length < 8)
        {
            char[] padLeft = new char[8 - codeToString.Length];

            string newCode = "";

            for (int i = 0; i < padLeft.Length; i++)
            {
                padLeft[i] = '0';
                newCode += padLeft[i];
            }

            newCode += codeToString;

            return newCode;
        }
        else
        {
            return codeToString;
        }
    }
}