using NUnit.Framework;
using RobotSimulatorLib;

namespace RobotSimulatorLibTest
{
    public class TestToyRobot
    {
        private IToyRobot _toyRobot;
        public TestToyRobot()
        {
            _toyRobot = new ToyRobot();
        }

        #region Place

        /// <summary>
        /// Test placing Robot at the bottom left of the Tabletop
        /// </summary>
        [Test]
        public void Place_BottomLeft_ReturnsTrue()
        {
            // Arrange
            Placement placement = new Placement()
            {
                XLocation=0,
                YLocation=0,
                Direction = Direction.North
            };
            bool expected = true;

            // Act
            bool actual = _toyRobot.Place(placement);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test placing Robot at the top left of the Tabletop
        /// </summary>
        [Test]
        public void Place_TopLeft_ReturnsTrue()
        {
            // Arrange
            Placement placement = new Placement()
            {
                XLocation = 0,
                YLocation = Constant.TABLE_TOP_ROWS - 1, //index 0
                Direction = Direction.North
            };
            bool expected = true;

            // Act
            bool actual = _toyRobot.Place(placement);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test placing Robot at the bottom right of the Tabletop
        /// </summary>
        [Test]
        public void Place_BottomRight_ReturnsTrue()
        {
            // Arrange
            Placement placement = new Placement()
            {
                XLocation = Constant.TABLE_TOP_COLUMNS - 1, //index 0
                YLocation = 0,
                Direction = Direction.North
            };
            bool expected = true;

            // Act
            bool actual = _toyRobot.Place(placement);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test placing Robot at the top rightof the Tabletop
        /// </summary>
        [Test]
        public void Place_TopRight_ReturnsTrue()
        {
            // Arrange
            Placement placement = new Placement()
            {
                //index 0
                XLocation = Constant.TABLE_TOP_COLUMNS - 1,
                YLocation = Constant.TABLE_TOP_ROWS - 1,
                Direction = Direction.North
            };
            bool expected = true;

            // Act
            bool actual = _toyRobot.Place(placement);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test placing Robot outside the Tabletop
        /// </summary>
        [Test]
        public void Place_OutsideTable_ReturnsFalse()
        {
            // Arrange
            Placement placement = new Placement()
            {
                XLocation = Constant.TABLE_TOP_COLUMNS + 5,
                YLocation = 0,
                Direction = Direction.North
            };
            bool expected = false;

            // Act
            bool actual = _toyRobot.Place(placement);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test placing Robot for invalid location
        /// </summary>
        [Test]
        public void Place_Negative_ReturnsFalse()
        {
            // Arrange
            Placement placement = new Placement()
            {
                XLocation = -1,
                YLocation = 0,
                Direction = Direction.North
            };
            bool expected = false;

            // Act
            bool actual = _toyRobot.Place(placement);

            // Assert
            Assert.AreEqual(expected, actual);
        }


        #endregion

        #region Move

        /// <summary>
        /// Test falling of the Robot from left edge of Tabletop
        /// </summary>
        [Test]
        public void Move_WestFromLeftEdge_ReturnsFalse()
        {
            // Arrange
            Placement placement = new Placement()
            {
                XLocation = 0,
                YLocation = 2,
                Direction = Direction.West
            };
            _toyRobot.Place(placement);
            bool expected = false;

            // Act
            bool actual = _toyRobot.Move();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test falling of the Robot from top edge of Tabletop
        /// </summary>
        [Test]
        public void Move_NorthFromTopEdge_ReturnsFalse()
        {
            // Arrange
            Placement placement = new Placement()
            {
                XLocation = 0,
                YLocation = Constant.TABLE_TOP_ROWS -1, //index 0
                Direction = Direction.North
            };
            _toyRobot.Place(placement);
            bool expected = false;

            // Act
            bool actual = _toyRobot.Move();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test falling of the Robot from right edge of Tabletop
        /// </summary>
        [Test]
        public void Move_EastFromRightEdge_ReturnsFalse()
        {
            // Arrange
            Placement placement = new Placement()
            {
                XLocation = Constant.TABLE_TOP_COLUMNS -1, //index 0
                YLocation = 0,
                Direction = Direction.East
            };
            _toyRobot.Place(placement);
            bool expected = false;

            // Act
            bool actual = _toyRobot.Move();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test falling of the Robot from bottom edge of Tabletop
        /// </summary>
        [Test]
        public void Move_SouthFromBottomEdge_ReturnsFalse()
        {
            // Arrange
            Placement placement = new Placement()
            {
                XLocation = 0,
                YLocation = 0,
                Direction = Direction.South
            };
            _toyRobot.Place(placement);
            bool expected = false;

            // Act
            bool actual = _toyRobot.Move();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test valid move from West
        /// </summary>
        [Test]
        public void Move_West_ReturnsTrue()
        {
            // Arrange
            Placement placement = new Placement()
            {
                XLocation = 2,
                YLocation = 2,
                Direction = Direction.West
            };
            _toyRobot.Place(placement);
            bool expected = true;

            // Act
            bool actual = _toyRobot.Move();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test valid move from North
        /// </summary>
        [Test]
        public void Move_North_ReturnsTrue()
        {
            // Arrange
            Placement placement = new Placement()
            {
                XLocation = 2,
                YLocation = 2,
                Direction = Direction.North
            };
            _toyRobot.Place(placement);
            bool expected = true;

            // Act
            bool actual = _toyRobot.Move();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test valid move from East
        /// </summary>
        [Test]
        public void Move_East_ReturnsTrue()
        {
            // Arrange
            Placement placement = new Placement()
            {
                XLocation = 2,
                YLocation = 2,
                Direction = Direction.East
            };
            _toyRobot.Place(placement);
            bool expected = true;

            // Act
            bool actual = _toyRobot.Move();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test valid move from South
        /// </summary>
        [Test]
        public void Move_South_ReturnsTrue()
        {
            // Arrange
            Placement placement = new Placement()
            {
                XLocation = 3,
                YLocation = 3,
                Direction = Direction.South
            };
            _toyRobot.Place(placement);
            bool expected = true;

            // Act
            bool actual = _toyRobot.Move();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Left

        /// <summary>
        /// Test rotating Robot 90 degrees anticlockwise without placing it on Tabletop
        /// </summary>
        [Test]
        public void Left_WithoutPlacement_ReturnsFalse()
        {
            // Arrange
            IToyRobot newToyRobot = new ToyRobot();
            bool expected = false;

            // Act
            bool actual = newToyRobot.Left();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test rotating Robot 90 degrees anticlockwise from South
        /// </summary>
        [Test]
        public void Left_FromSouth_ReturnsEast()
        {
            // Arrange
            Placement placement = new Placement()
            {
                XLocation = 0,
                YLocation = 0,
                Direction = Direction.South
            };
            _toyRobot.Place(placement);
            Direction expected = Direction.East;

            // Act
            _toyRobot.Left();
            Direction actual = _toyRobot.Report().Direction;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test rotating Robot 90 degrees anticlockwise from East
        /// </summary>
        [Test]
        public void Left_FromEast_ReturnsNorth()
        {
            // Arrange
            Placement placement = new Placement()
            {
                XLocation = 0,
                YLocation = 0,
                Direction = Direction.East
            };
            _toyRobot.Place(placement);
            Direction expected = Direction.North;

            // Act
            _toyRobot.Left();
            Direction actual = _toyRobot.Report().Direction;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test rotating Robot 90 degrees anticlockwise from North
        /// </summary>
        [Test]
        public void Left_FromNorth_ReturnsWest()
        {
            // Arrange
            Placement placement = new Placement()
            {
                XLocation = 0,
                YLocation = 0,
                Direction = Direction.North
            };
            _toyRobot.Place(placement);
            Direction expected = Direction.West;

            // Act
            _toyRobot.Left();
            Direction actual = _toyRobot.Report().Direction;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test rotating Robot 90 degrees anticlockwise from West
        /// </summary>
        [Test]
        public void Left_FromWest_ReturnsSouth()
        {
            // Arrange
            Placement placement = new Placement()
            {
                XLocation = 0,
                YLocation = 0,
                Direction = Direction.West
            };
            _toyRobot.Place(placement);
            Direction expected = Direction.South;

            // Act
            _toyRobot.Left();
            Direction actual = _toyRobot.Report().Direction;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test rotating Robot 90 degrees anticlockwise 4 times from North to complete the circle
        /// </summary>
        [Test]
        public void Left_CircleFromNorth_ReturnsNorth()
        {
            // Arrange
            Placement placement = new Placement()
            {
                XLocation = 0,
                YLocation = 0,
                Direction = Direction.North
            };
            _toyRobot.Place(placement);
            Direction expected = Direction.North;

            // Act
            _toyRobot.Left();
            _toyRobot.Left();
            _toyRobot.Left();
            _toyRobot.Left();
            Direction actual = _toyRobot.Report().Direction;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Right

        /// <summary>
        /// Test rotating Robot 90 degrees clockwise without placing it on Tabletop
        /// </summary>
        [Test]
        public void Right_WithoutPlacement_ReturnsFalse()
        {
            // Arrange
            IToyRobot newToyRobot = new ToyRobot();
            bool expected = false;

            // Act
            bool actual = newToyRobot.Right();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test rotating Robot 90 degrees clockwise from South
        /// </summary>
        [Test]
        public void Right_FromSouth_ReturnsWest()
        {
            // Arrange
            Placement placement = new Placement()
            {
                XLocation = 0,
                YLocation = 0,
                Direction = Direction.South
            };
            _toyRobot.Place(placement);
            Direction expected = Direction.West;

            // Act
            _toyRobot.Right();
            Direction actual = _toyRobot.Report().Direction;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test rotating Robot 90 degrees clockwise from West
        /// </summary>
        [Test]
        public void Right_FromWest_ReturnsNorth()
        {
            // Arrange
            Placement placement = new Placement()
            {
                XLocation = 0,
                YLocation = 0,
                Direction = Direction.West
            };
            _toyRobot.Place(placement);
            Direction expected = Direction.North;

            // Act
            _toyRobot.Right();
            Direction actual = _toyRobot.Report().Direction;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test rotating Robot 90 degrees clockwise from North
        /// </summary>
        [Test]
        public void Right_FromNorth_ReturnsEast()
        {
            // Arrange
            Placement placement = new Placement()
            {
                XLocation = 0,
                YLocation = 0,
                Direction = Direction.North
            };
            _toyRobot.Place(placement);
            Direction expected = Direction.East;

            // Act
            _toyRobot.Right();
            Direction actual = _toyRobot.Report().Direction;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test rotating Robot 90 degrees clockwise from East
        /// </summary>
        [Test]
        public void Right_FromEast_ReturnsSouth()
        {
            // Arrange
            Placement placement = new Placement()
            {
                XLocation = 0,
                YLocation = 0,
                Direction = Direction.East
            };
            _toyRobot.Place(placement);
            Direction expected = Direction.South;

            // Act
            _toyRobot.Right();
            Direction actual = _toyRobot.Report().Direction;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test rotating Robot 90 degrees clockwise 4 times from North to complete the circle
        /// </summary>
        [Test]
        public void Right_CircleFromNorth_ReturnsNorth()
        {
            // Arrange
            Placement placement = new Placement()
            {
                XLocation = 0,
                YLocation = 0,
                Direction = Direction.North
            };
            _toyRobot.Place(placement);
            Direction expected = Direction.North;

            // Act
            _toyRobot.Right();
            _toyRobot.Right();
            _toyRobot.Right();
            _toyRobot.Right();
            Direction actual = _toyRobot.Report().Direction;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Report

        /// <summary>
        /// Test Report for valid placement of the Robot on the Tabletop
        /// </summary>
        [Test]
        public void Report_ValidPlacement_ReturnsPlacement()
        {
            // Arrange
            Placement placement = new Placement()
            {
                XLocation = 0,
                YLocation = 0,
                Direction = Direction.South
            };
            _toyRobot.Place(placement);
            Placement expected = new Placement()
            {
                XLocation = 0,
                YLocation = 0,
                Direction = Direction.South
            };

            // Act
            Placement actual = _toyRobot.Report();

            // Assert
            Assert.AreEqual(expected.XLocation, actual.XLocation);
            Assert.AreEqual(expected.YLocation, actual.YLocation);
            Assert.AreEqual(expected.Direction, actual.Direction);
        }

        /// <summary>
        /// Test Report for invalid placement of the Robot on the Tabletop
        /// </summary>
        [Test]
        public void Report_InvalidPlacement_ReturnsLastPlacement()
        {
            // Arrange
            Placement placement = new Placement()
            {
                XLocation = 0,
                YLocation = 0,
                Direction = Direction.South
            };

            _toyRobot.Place(placement);

            Placement invalidPlacement = new Placement()
            {
                XLocation = Constant.TABLE_TOP_COLUMNS + 5,
                YLocation = 0,
                Direction = Direction.North
            };

            _toyRobot.Place(invalidPlacement);

            Placement expected = new Placement()
            {
                XLocation = 0,
                YLocation = 0,
                Direction = Direction.South
            };

            // Act
            Placement actual = _toyRobot.Report();

            // Assert
            Assert.AreEqual(expected.XLocation, actual.XLocation);
            Assert.AreEqual(expected.YLocation, actual.YLocation);
            Assert.AreEqual(expected.Direction, actual.Direction);
        }

        #endregion

    }
}
