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

string userProductName = Console.ReadLine();

Product testProduct = new Product(userProductName, "un'incredibile penna normale", 1.50, 22);

Console.WriteLine(testProduct.AddPadLeft());
Console.WriteLine(testProduct.GetName());
Console.WriteLine(testProduct.GetPrice());
Console.WriteLine(testProduct.GetPricePlusIva());

public class Product
{
    protected int code;
    protected string name;
    protected string description;
    protected double price;
    protected int iva;

    //Construct
    public Product(string name, string description, double price, int iva)
    {
        this.code = new Random().Next(1, 99999999);
        this.name = name;
        this.description = description;
        this.price = price;
        this.iva = iva;
    }

    //Getters
    public int GetCode()
    {
        return this.code;
    }

    public string GetName()
    {
        return this.name;
    }

    public string GetDescription()
    {
        return this.description;
    }

    public double GetPrice()
    {
        return this.price;
    }

    public int GetIva()
    {
        return this.iva;
    }

    public double GetPricePlusIva()
    {
        double finalPrice = this.price + ((this.price * this.iva) / 100); 

        return finalPrice;
    }

    public string GetExtendedName()
    {
        string extendedName = this.code.ToString() + this.name;

        return extendedName;
    }

    //Setters
    public void SetName(string newName)
    {
        this.name = newName;
    }

    public void SetDescription(string newDescription)
    {
        this.description = newDescription;
    }

    public void SetPrice(double newPrice)
    {
        this.price = newPrice;
    }

    public void GetIva(int newIva)
    {
        this.iva = newIva;
    }

    public int AddPadLeft()
    {
        string codeToChange = Convert.ToString(this.code);

        if (codeToChange.Length < 8)
        {
            
            char[] padLeft = new char[8 - codeToChange.Length];

            string newCode = "";

            for (int i = 0; i < padLeft.Length; i++)
            {
                padLeft[i] = '0';
                newCode += padLeft[i];
            }

            newCode += codeToChange;

            Console.WriteLine(newCode);

            this.code = Convert.ToInt32(newCode);

            return this.code;
        }
        else
        {
            return this.code;
        }
    }
}