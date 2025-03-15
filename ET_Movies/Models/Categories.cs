namespace ET_Movies.Models
{
    public class Categories
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public List<Movies> Movies { get; set; } = new List<Movies>();
    }
}
