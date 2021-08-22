namespace RobotSimulatorLib
{
    /// <summary>
    /// This class contains the location of the Robot on the Tabletop and the direction it is facing
    /// </summary>
    public class Placement
    {
        public int XLocation { get; set; }
            
        public int YLocation { get; set; }

        public Direction Direction { get; set; }
    }
}
