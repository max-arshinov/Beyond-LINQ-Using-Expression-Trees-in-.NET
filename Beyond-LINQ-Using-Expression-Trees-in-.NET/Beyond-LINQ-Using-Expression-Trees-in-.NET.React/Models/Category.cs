using Force.Ddd;

namespace Beyond_LINQ_Using_Expression_Trees_in_.NET.React.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public static readonly Spec<Category> NiceRating
            = new Spec<Category>(x => x.Rating > 50);
   
        public int Rating { get; set; }
    }
}