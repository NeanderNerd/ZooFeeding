using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZooFeeding.Models
{
    public class Animal
    {
        public int AnimalId { get; set; }
        public string AnimalName { get; set; }
        public bool DryCatFood { get; set; }
        public bool Fish { get; set; }
        public bool Fruit { get; set; }
        public bool Hay { get; set; }
        public bool Insects { get; set; }
        public bool Meat { get; set; }
        public bool MonkeyChow { get; set; }
        public bool Plants { get; set; }
        public bool Rodents { get; set; }
        public bool Vegetables { get; set; }
    }
}