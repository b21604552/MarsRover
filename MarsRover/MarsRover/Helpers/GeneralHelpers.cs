using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsRover.Messages;
using MarsRover.Classes;

namespace MarsRover.Helpers
{
    public class GeneralHelpers
    {
        public static char[] Directions = new char[] { 'S', 'W', 'N', 'E' };
        public static string[] adjustMap()
        {
            string[] mapLength;
            var mapLegnthCheck = false;
            int mapX;
            int mapY;
            do
            {
                mapLength = Console.ReadLine().Split(" ");
                if (mapLength.Length != 2)
                {
                    Console.WriteLine(Messages.Messages.MapInputError);
                    Console.Write(Messages.Messages.MapInfo);
                }
                else
                {
                    mapLegnthCheck = true;
                }
                if (mapLegnthCheck)
                {
                    try
                    {
                        mapX = int.Parse(mapLength[0]);
                        mapY = int.Parse(mapLength[1]);
                    }
                    catch (Exception)
                    {
                        mapLegnthCheck = false;
                        Console.WriteLine(Messages.Messages.MapInvalidInputError);
                        Console.Write(Messages.Messages.MapInfo);
                    }
                }
            } while (!mapLegnthCheck);
            return mapLength;
        }

        public static Classes.Rover initRover(int mapMaxX, int mapMaxY)
        {
            Rover marsRover;
            string[] roverPlacement;
            Console.WriteLine(Messages.Messages.MapReady);
            Console.Write(Messages.Messages.RoverPlacement);
            var roverCheck = false;
            do
            {
                roverPlacement = Console.ReadLine().Split(" ");
                if (roverPlacement.Length != 3)
                {
                    Console.WriteLine(Messages.Messages.RoverInputError);
                    Console.Write(Messages.Messages.RoverPlacement);
                }
                else
                {
                    roverCheck = true;
                }
                if (roverCheck)
                {
                    try
                    {
                        int roverX = int.Parse(roverPlacement[0]);
                        int roverY = int.Parse(roverPlacement[1]);
                        char roverD = roverPlacement[2].First();
                        if (roverX > mapMaxX || roverY > mapMaxY)
                        {
                            roverCheck = false;
                            Console.WriteLine(Messages.Messages.RoverInputLargerThanMap);
                            Console.Write(Messages.Messages.RoverPlacement);
                        }
                        else
                        {
                            if (Directions.Contains(roverD))
                            {
                                marsRover = new Rover(roverX, roverY, roverD);
                                return marsRover;
                            }
                            else
                            {
                                roverCheck = false;
                                Console.WriteLine(Messages.Messages.RoverInputWrongDirection);
                                Console.Write(Messages.Messages.RoverPlacement);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        roverCheck = false;
                        Console.WriteLine(Messages.Messages.RoverInputError);
                        Console.Write(Messages.Messages.RoverPlacement);
                    }
                }
            } while (!roverCheck);
            return initRover(mapMaxX, mapMaxY);
        }

        public static void adjustRover(string[] roverPlacement, int mapMaxX, int mapMaxY, Rover rover, Map mapObj)
        {
            Rover marsRover;
            var roverCheck = false;
            if (roverPlacement.Length != 3)
            {
                Console.WriteLine(Messages.Messages.RoverInputError);
            }
            else
            {
                roverCheck = true;
            }
            if (roverCheck)
            {
                try
                {
                    int roverX = int.Parse(roverPlacement[0]);
                    int roverY = int.Parse(roverPlacement[1]);
                    char roverD = roverPlacement[2].First();
                    if (roverX > mapMaxX || roverY > mapMaxY)
                    {
                        Console.WriteLine(Messages.Messages.RoverInputLargerThanMap);
                    }
                    else
                    {
                        if (Directions.Contains(roverD))
                        {
                            mapObj.map[rover.x, rover.y] = 0;
                            mapObj.map[roverX, roverY] = 1;
                            rover.x = roverX;
                            rover.y = roverY;
                            rover.d = roverD;
                        }
                        else
                        {
                            Console.WriteLine(Messages.Messages.RoverInputWrongDirection);
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine(Messages.Messages.RoverInputError);
                }
            }
        }

        public static bool isMoveAviable(Map mapObj, Rover rover, char? direction)
        {
            if(direction == 'M')
            {
                var checkX = rover.x;
                var checkY = rover.y;
                var checkD = rover.d;
                switch (checkD)
                {
                    case 'W':
                        checkY--;
                        break;
                    case 'E':
                        checkY++;
                        break;
                    case 'N':
                        checkX--;
                        break;
                    case 'S':
                        checkX++;
                        break;
                }
                if(checkX <= mapObj.x && checkY <= mapObj.y && checkX > 0 && checkY > 0)
                {
                    move(mapObj,rover, checkX, checkY);
                    return true;
                }
            }
            else if(direction == 'F')
            {
                var checkX = rover.x - 1;
                if(checkX >= 0)
                {
                    move(mapObj, rover, checkX, rover.y);
                    return true;
                }
            }
            else if (direction == 'B')
            {
                var checkX = rover.x + 1;
                if (checkX <= mapObj.x)
                {
                    move(mapObj, rover, checkX, rover.y);
                    return true;
                }
            }
            else if (direction == 'L')
            {
                var checkY = rover.y - 1;
                if (checkY >= 0)
                {
                    move(mapObj, rover, rover.x, checkY);
                    return true;
                }
            }
            else if (direction == 'R')
            {
                var checkY = rover.y + 1;
                if (checkY <= mapObj.y)
                {
                    move(mapObj, rover, rover.x, checkY);
                    return true;
                }
            }
            return false;
        }

        public static void move(Map mapObj, Rover rover, int newX, int newY)
        {
            mapObj.map[rover.x, rover.y] = 0;
            mapObj.map[newX, newY] = 1;
            rover.x = newX;
            rover.y = newY;
            Console.WriteLine(rover.x + " " + rover.y + " " + rover.d);
        }
    }
}
