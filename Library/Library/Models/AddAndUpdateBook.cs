﻿namespace Library.Models
{
    public class AddAndUpdateBook
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Pages { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
		public int Price { get; set; }
	}
}
