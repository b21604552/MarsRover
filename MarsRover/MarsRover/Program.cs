using MarsRover.Messages;
using MarsRover.Classes;
using MarsRover.Helpers;
namespace FirtsApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Map marsMap = initMap();
            Rover marsRover = GeneralHelpers.initRover(marsMap.x, marsMap.y);
            marsMap.map[marsRover.x, marsRover.y] = 1;
            Console.WriteLine(Messages.Description);
            do
            {
                var command = Console.ReadLine();
                if (String.IsNullOrEmpty(command))
                {
                    Console.WriteLine(Messages.EmptyInput);
                }
                else
                {
                    if (command == "List")
                    {
                        Map.List(marsMap);
                    }
                    else
                    {
                        var commandArray = command.Split(' ');
                        if (commandArray.Length == 3)
                        {
                            GeneralHelpers.adjustRover(commandArray, marsMap.x, marsMap.y, marsRover, marsMap);
                        }
                        else
                        {
                            var moveCommands = command.ToCharArray();
                            foreach (var moveCommand in moveCommands)
                            {
                                switch (moveCommand)
                                {
                                    case 'L':
                                        GeneralHelpers.isMoveAviable(marsMap, marsRover, 'L');
                                        break;
                                    case 'R':
                                        GeneralHelpers.isMoveAviable(marsMap, marsRover, 'R');
                                        break;
                                    case 'F':
                                        GeneralHelpers.isMoveAviable(marsMap, marsRover, 'F');
                                        break;
                                    case 'B':
                                        GeneralHelpers.isMoveAviable(marsMap, marsRover, 'B');
                                        break;
                                    case 'M':
                                        GeneralHelpers.isMoveAviable(marsMap, marsRover, 'M');
                                        break;
                                }
                            }
                        }
                    }
                }
            } while (true);
        }

        public static Map initMap()
        {
            Console.Write(Messages.MapInfo);
            string[] mapLength = GeneralHelpers.adjustMap();
            Map marsMap = new Map(Convert.ToInt32(mapLength[0]), Convert.ToInt32(mapLength[1]));
            return marsMap;
        }
    }
}