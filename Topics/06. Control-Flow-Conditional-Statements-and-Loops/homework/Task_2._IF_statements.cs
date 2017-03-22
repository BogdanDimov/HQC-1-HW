public class IfStatements
{
    public void FirstIfStatement()
    {
        Potato potato = new Potato();

        if (potato != null)
        {
            if (potato.hasBeenPeeled && !potato.isRotten)
            {
                Cook(potato);
            }
        }
    }

    public void SecondIfStatement()
    {
        bool xInRange = MIN_X <= x && x <= MAX_X;
        bool yInRange = MIN_Y <= y && y <= MAX_Y;

        if (xInRange && yInRange && shouldVisitCell)
        {
            VisitCell();
        }
    }
}
