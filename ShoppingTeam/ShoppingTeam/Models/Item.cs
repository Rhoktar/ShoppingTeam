using System;

namespace ShoppingTeam.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public string Menge { get; set; }
        public Kategorien Kategorie { get; set; }

    }

    public enum Kategorien
    {
        Obst, 
        Gemüse,
        Fleisch,
        Kleidung,
        Elektro,
        Sonstiges,
        Backwaren,
        Getränke,
        Knabberzeug,
        Sanitär,
        Hygiene,
        Kühlregal
    }
}