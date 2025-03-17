using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ET_Movies.Models
{
    public class Categories
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ValidateNever]
        public List<Movies> Movies { get; set; } = new List<Movies>();
    }
}
