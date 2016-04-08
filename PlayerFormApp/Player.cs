using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerFormApp
{
    class Player
    {
        private string name;
        private int height;
        private int age;
        private int distance;
        private double speed;



        public Player()
        {
            this.name = "Unassigned";
            this.height = 0;
            this.age = 0;
            this.distance = 0;
            this.speed = 0;
        }

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
