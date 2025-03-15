﻿namespace ET_Movies.Models
{
    public class Cinemas
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; } 
        public string CinemaLogo { get; set; } 
        public string Address { get; set; } 
        public List<Movies> Movies { get; set; } = new List<Movies>(); 
    }
}