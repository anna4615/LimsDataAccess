﻿using System.Collections.Generic;

namespace LimsDataAccess.Models
{
    public class Elisa
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public List<Test> Tests { get; set; }
    }
}