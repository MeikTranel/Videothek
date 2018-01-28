﻿using System;

namespace Videothek.Core
{
    public sealed class Penalty
    {
        public int ID { get; set; }
        public User User { get; set; }
        public string Note { get; set; }
        public float Value { get; set; }
        public DateTime Date { get; set; }
        public bool Paid { get; set; }
    }
}
