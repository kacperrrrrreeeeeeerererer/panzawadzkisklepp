using System;
using System.Collections.Generic;

namespace Sklep
{
    class Program
    {
        static List<Projekt> produkty = new List<Projekt>(); // Zmieniona nazwa klasy na Projekt

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Wybierz opcję:");
                Console.WriteLine("1. Dodaj produkt");
                Console.WriteLine("2. Usuń produkt");
                Console.WriteLine("3. Wyświetl listę produktów");
                Console.WriteLine("4. Aktualizuj produkt");
                Console.WriteLine("5. Oblicz wartość magazynu");
                Console.WriteLine("6. Wyjście");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DodajProjekt();
                        break;
                    case "2":
                        UsunProjekt();
                        break;
                    case "3":
                        WyswietlListeProjektow();
                        break;
                    case "4":
                        AktualizujProjekt();
                        break;
                    case "5":
                        ObliczWartoscMagazynu();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
                        break;
                }
            }
        }

        static void DodajProjekt()
        {
            Console.WriteLine("Podaj nazwę projektu:");
            string name = Console.ReadLine();

            Console.WriteLine("Podaj ilość:");
            int quantity = int.Parse(Console.ReadLine());

            Console.WriteLine("Podaj cenę jednostkową:");
            double price = double.Parse(Console.ReadLine());

            string barCode = Guid.NewGuid().ToString();
            produkty.Add(new Projekt(barCode, name, price, quantity));
            Console.WriteLine($"Projekt {name} został dodany.");
        }

        static void UsunProjekt()
        {
            Console.WriteLine("Podaj nazwę projektu do usunięcia:");
            string name = Console.ReadLine();

            Projekt projekt = produkty.Find(p => p.Name == name);
            if (projekt != null)
            {
                produkty.Remove(projekt);
                Console.WriteLine($"Projekt {name} został usunięty.");
            }
            else
            {
                Console.WriteLine($"Projekt {name} nie został znaleziony.");
            }
        }

        static void WyswietlListeProjektow()
        {
            if (produkty.Count == 0)
            {
                Console.WriteLine("Magazyn jest pusty.");
            }
            else
            {
                Console.WriteLine("\nLista projektów:");
                foreach (var projekt in produkty)
                {
                    Console.WriteLine($"Kod: {projekt.BarCode}, Nazwa: {projekt.Name}, Cena: {projekt.Price} zł, Ilość: {projekt.Quantity}");
                }
            }
        }

        static void AktualizujProjekt()
        {
            Console.WriteLine("Podaj nazwę projektu do aktualizacji:");
            string name = Console.ReadLine();

            Projekt projekt = produkty.Find(p => p.Name == name);
            if (projekt != null)
            {
                Console.WriteLine("Podaj nową ilość:");
                projekt.Quantity = int.Parse(Console.ReadLine());

                Console.WriteLine("Podaj nową cenę:");
                projekt.Price = double.Parse(Console.ReadLine());

                Console.WriteLine($"Projekt {name} został zaktualizowany.");
            }
            else
            {
                Console.WriteLine($"Projekt {name} nie został znaleziony.");
            }
        }

        static void ObliczWartoscMagazynu()
        {
            double totalValue = 0;
            foreach (var projekt in produkty)
            {
                totalValue += projekt.Quantity * projekt.Price;
            }
            Console.WriteLine($"Całkowita wartość magazynu: {totalValue} zł.");
        }
    }
}
