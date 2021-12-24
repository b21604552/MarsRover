using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Messages
{
    public class Messages
    {
        public static string MapInfo {get; set;} = "Give the length of map (N N): ";
        public static string MapInputError {get; set;} = "You gave a map that has wrong format. Try again";
        public static string MapInvalidInputError { get; set;} = "You gave a map that are not integer. Try again";
        public static string MapReady { get; set; } = "Map is ready go to ahead.";
        public static string RoverPlacement { get; set; } = "Now place rover (X Y D): ";
        public static string RoverInputError { get; set; } = "You gave a placement that has wrong format. Try again";
        public static string RoverInputLargerThanMap { get; set; } = "You gave a placement that has larger than map. Try again";
        public static string RoverInputWrongDirection { get; set; } = "You gave a placement that has wrong direction. Try again";
        public static string Description { get; set; } = "Now You Can Contiune With Any Command.\nBefore that keep in mind, you reach to border line of the map.\nWe will not proccess that command, and contiune with next one.";
        public static string EmptyInput { get; set; } = "You gave empty line. Try again";
        public static string RoverIcon { get; set; } = "X";
        public static string ListInfo { get; set; } = "Current Map;";
    }
}
