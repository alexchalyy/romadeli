// MenuItem.cs

using Microsoft.AspNetCore.Mvc;

namespace TorysDeli.Models
{
    public class MenuItem
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public string? ImageUrl { get; set; }
    }
}
