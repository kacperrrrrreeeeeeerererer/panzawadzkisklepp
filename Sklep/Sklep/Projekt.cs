namespace Sklep
{
    class Projekt
    {
        public string BarCode { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public Projekt(string barCode, string name, double price, int quantity)
        {
            BarCode = barCode;
            Name = name;
            Price = price;
            Quantity = quantity;
        }
    }
}
