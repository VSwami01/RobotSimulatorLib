namespace RobotSimulatorLib
{
    /// <summary>
    /// This class containes the Behavior of the Robot 
    /// </summary>
    public class ToyRobot : IToyRobot
    {
        private Placement _placement;

        /// <summary>
        /// Initial placement of the Robot is outside the Tabletop
        /// </summary>
        public ToyRobot()
        {
            _placement = new Placement() { XLocation = -1, YLocation = -1 };
        }

        /// <summary>
        /// This method places Robot on the table
        /// </summary>
        /// <param name="placement"></param>
        /// <returns></returns>
        public bool Place(Placement placement)
        {
            bool validPlacement = IsValidPlacement(placement);

            if (validPlacement)
            {
                _placement = placement;
            }

            return validPlacement;
        }

        /// <summary>
        /// This method moves the Robot one unit in the direction Robot is currently facing
        /// </summary>
        /// <returns></returns>
        public bool Move()
        {
            Placement nextPlacement = GetNextPlacement();

            bool validPlacement = IsValidPlacement(nextPlacement);

            if (validPlacement)
            {
                _placement = nextPlacement;
            }

            return validPlacement;
        }

        /// <summary>
        /// This method rotates the Robot 90 degrees in anticlockwise direction without changing the position of the Robot
        /// </summary>
        /// <returns></returns>
        public bool Left()
        {
            bool validPlacement = IsValidPlacement(_placement);

            if (validPlacement)
            {
               switch( _placement.Direction)
                {
                    case Direction.North:
                        _placement.Direction = Direction.West;
                        break;
                    case Direction.East:
                        _placement.Direction = Direction.North;
                        break;
                    case Direction.South:
                        _placement.Direction = Direction.East;
                        break;
                    case Direction.West:
                        _placement.Direction = Direction.South;
                        break;
                }    
            }

            return validPlacement;
        }

        /// <summary>
        /// This method rotates the Robot 90 degrees in clockwise direction without changing the position of the Robot
        /// </summary>
        /// <returns></returns>
        public bool Right()
        {

            bool validPlacement = IsValidPlacement(_placement);

            if (validPlacement)
            {
                switch (_placement.Direction)
                {
                    case Direction.North:
                        _placement.Direction = Direction.East;
                        break;
                    case Direction.East:
                        _placement.Direction = Direction.South;
                        break;
                    case Direction.South:
                        _placement.Direction = Direction.West;
                        break;
                    case Direction.West:
                        _placement.Direction = Direction.North;
                        break;
                }
            }

            return validPlacement;
        }

        /// <summary>
        /// This method returns the X,Y and orientation of the Robot.
        /// </summary>
        /// <returns></returns>
        public Placement Report()
        {
            return _placement;
        }

        /// <summary>
        /// This method calculates and returns the Next Position of the Robot
        /// </summary>
        /// <returns></returns>
        private Placement GetNextPlacement()
        {
            Placement nextPlacement = new() { XLocation = _placement.XLocation, YLocation = _placement.YLocation, Direction= _placement.Direction };

            switch (_placement.Direction)
            {
                case Direction.North:
                    nextPlacement.YLocation += 1;
                    break;

                case Direction.East:
                    nextPlacement.XLocation += 1;
                    break;

                case Direction.South:
                    nextPlacement.YLocation -= 1;
                    break;

                case Direction.West:
                    nextPlacement.XLocation -= 1;
                    break;

            }

            return nextPlacement;
        }

        /// <summary>
        /// This method checks if the new placement is valid for the Robot
        /// </summary>
        /// <param name="placement"></param>
        /// <returns></returns>
        private bool IsValidPlacement(Placement placement)
        {
            return (placement.XLocation >= 0 && placement.XLocation < Constant.TABLE_TOP_COLUMNS
                && placement.YLocation >= 0 && placement.YLocation < Constant.TABLE_TOP_ROWS);
        }
    }
}
