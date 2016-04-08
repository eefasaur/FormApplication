using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerFormApp
{
    public class Player
    {
        private string name;
        private int height;
        private int age;
        private int distance;
        private double speed;



        public Player() { }
      

        public Player(string name, int height, int age, int distance, double speed)
        {
            this.name = name;
            this.height = height;
            this.age = age;
            this.distance = distance;
            this.speed = speed;
        }

        public string Name { get; set; }
        public int Height { get; set; }
        public int Age { get; set; }
        public int Distance { get; set; }
        public double Speed { get; set; }
    }
}
