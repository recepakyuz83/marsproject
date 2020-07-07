using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsProject
{
    public class Program
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Directions Direction { get; set; }

        public Program()
        {
            X = 0;
            Y = 0;
            Direction = Directions.N;
        }

        //Enumaration 4 main direction
        public enum Directions
        {
            N = 1,//North
            S = 2,//South
            E = 3,//East
            W = 4//West
        }

        static void Main(string[] args)
        {

            var upperCoordinate = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();
            var firstCoordinate = Console.ReadLine().Trim().Split(' ');
            Program marsProgram = new Program();

            if (firstCoordinate.Count() == 3)
            {
                marsProgram.X = Convert.ToInt32(firstCoordinate[0]);
                marsProgram.Y = Convert.ToInt32(firstCoordinate[1]);
                marsProgram.Direction = (Directions)Enum.Parse(typeof(Directions), firstCoordinate[2]);

                var command = Console.ReadLine().ToUpper();

                try
                {
                    marsProgram.move(upperCoordinate, command);
                    Console.WriteLine($"{marsProgram.X} {marsProgram.Y} {marsProgram.Direction.ToString()}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine($"Wrong Input");
            }

            Console.ReadLine();
        }


        private void turnLeft()
        {
            switch (this.Direction)
            {
                case Directions.N:
                    this.Direction = Directions.W;
                    break;
                case Directions.S:
                    this.Direction = Directions.E;
                    break;
                case Directions.E:
                    this.Direction = Directions.N;
                    break;
                case Directions.W:
                    this.Direction = Directions.S;
                    break;
                default:
                    break;
            }
        }

        private void turnRight()
        {
            switch (this.Direction)
            {
                case Directions.N:
                    this.Direction = Directions.E;
                    break;
                case Directions.S:
                    this.Direction = Directions.W;
                    break;
                case Directions.E:
                    this.Direction = Directions.S;
                    break;
                case Directions.W:
                    this.Direction = Directions.N;
                    break;
                default:
                    break;
            }
        }

        private void goHead()
        {
            switch (this.Direction)
            {
                case Directions.N:
                    this.Y += 1;
                    break;
                case Directions.S:
                    this.Y -= 1;
                    break;
                case Directions.E:
                    this.X += 1;
                    break;
                case Directions.W:
                    this.X -= 1;
                    break;
                default:
                    break;
            }
        }


        public void move(List<int> maxPoints, string commands)
        {
            foreach (var command in commands)
            {
                switch (command)
                {
                    case 'M':
                        this.goHead();
                        break;
                    case 'L':
                        this.turnLeft();
                        break;
                    case 'R':
                        this.turnRight();
                        break;
                    default:
                        Console.WriteLine($"Wrong Command. {command} !! Command can only be L R M .");
                        break;
                }

                if (this.X < 0 || this.X > maxPoints[0] || this.Y < 0 || this.Y > maxPoints[1])
                {
                    throw new Exception($" Max coordinate can only be inside (0 , 0) and ({maxPoints[0]} , {maxPoints[1]})");
                }
            }
        }


    }
}
