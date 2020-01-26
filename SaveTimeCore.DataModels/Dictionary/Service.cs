﻿using SaveTimeCore.AbstractModels.Marker;

namespace SaveTimeCore.DataModels.Dictionary
{
    public class Service : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public double SpendTimeInMinutes { get; set; }
    }
}
