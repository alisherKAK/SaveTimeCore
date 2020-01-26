﻿using System;

namespace SaveTimeCore.Domain.DTOs
{
    public class RecordDTO
    {
        public int Id { get; set; }
        public int BarberId { get; set; }
        public int ClientId { get; set; }
        public DateTime BookingTime { get; set; }
        public double SpendTime { get; set; }
        public int Status { get; set; }
    }
}