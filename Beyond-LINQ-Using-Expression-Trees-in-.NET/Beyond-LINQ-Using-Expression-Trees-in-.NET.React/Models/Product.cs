namespace Beyond_LINQ_Using_Expression_Trees_in_.NET.React.Models
{
    public class Product
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public Category Category { get; set; }
        
        public decimal Price { get; set; }

        public bool IsForSale { get; set; }

        public int InStock { get; set; }


        public bool IsAvailable => IsForSale && InStock > 0;  

    }
}