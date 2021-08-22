namespace RobotSimulatorLib
{
    public interface IToyRobot
    {
        bool Place(Placement placement);
        bool Move();
        bool Left();
        bool Right();
        Placement Report();

    }
}
