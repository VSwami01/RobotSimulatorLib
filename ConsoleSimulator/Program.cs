using System;
using RobotSimulatorLib;

namespace ConsoleSimulator
{
    /// <summary>
    /// Console Toy Robot Simulator to test RobotSimulatorLib
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            IToyRobot robot = new ToyRobot();

            Console.WriteLine("Welcome to Toy Robot simulator");
            char choice = '1';

            //Continue until user decides to exit
            while (choice != '6')
            {
                Console.WriteLine("Press 1 for Place, 2 for Move, 3 for Left, 4 for Right, 5 for Report, 6 for exit");
                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                //Invalid commands are discarded
                switch (choice)
                {
                    case '1':
                        if (robot.Place(GetPlacementFromUser()))
                            Console.WriteLine("Robot Placed");
                        else
                            Console.WriteLine("Invalid Placement");
                        break;

                    case '2':
                        if(robot.Move())
                            Console.WriteLine("Robot Moved");
                        else
                            Console.WriteLine("Invalid Move");
                        break;

                    case '3':
                        if (robot.Left())
                            Console.WriteLine("Robot Turned Left");
                        else
                            Console.WriteLine("Invalid Left");
                        break;

                    case '4':
                        if(robot.Right())
                            Console.WriteLine("Robot Turned Right");
                        else
                            Console.WriteLine("Invalid Right");
                        break;

                    case '5':
                        Placement placement = robot.Report();
                        Console.WriteLine($"X: {placement.XLocation}, Y: {placement.YLocation}, Direction: {placement.Direction}");
                        break;

                    case '6':
                        break;

                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// This method gets user input for Robot location and direction on the TableTop
        /// </summary>
        /// <returns></returns>
        static Placement GetPlacementFromUser()
        {
            Placement placement = new Placement()
            {
                XLocation = -1,
                YLocation = -1
            };

            int intVal;

            char choice;

            Console.WriteLine("Enter X Location (0-5)");
            choice = Console.ReadKey().KeyChar;
            Console.WriteLine();

            if (int.TryParse(choice.ToString(), out intVal)
                && intVal >= 0 && intVal <= 5)
                placement.XLocation = intVal;
            else
                return placement;

            Console.WriteLine("Enter Y Location (0-5)");
            choice = Console.ReadKey().KeyChar;
            Console.WriteLine();

            if (int.TryParse(choice.ToString(), out intVal)
                && intVal >= 0 && intVal <= 5)
                placement.YLocation = intVal;
            else
                return placement;

            Console.WriteLine("Enter Direcion (N,E,S,W)");
            choice = Console.ReadKey().KeyChar;
            Console.WriteLine();

            switch (choice)
            {
                case 'n':
                case 'N':
                    placement.Direction = Direction.North;
                    break;
                case 'e':
                case 'E':
                    placement.Direction = Direction.East;
                    break;
                case 's':
                case 'S':
                    placement.Direction = Direction.South;
                    break;
                case 'w':
                case 'W':
                    placement.Direction = Direction.West;
                    break;
                default:
                    //invalid input. clear off placement
                    placement.XLocation = -1;
                    placement.YLocation = -1;
                    break;
            }

            return placement;
        }
    }
}
