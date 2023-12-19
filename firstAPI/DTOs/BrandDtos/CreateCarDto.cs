﻿namespace firstAPI.DTOs.BrandDtos
{
    public class CreateCarDto
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ModelYear { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public double Dailyprice { get; set; }

    }
}
