namespace ProjetoLuz.Helicopter
{
    public static class PilotSeatRule
    {
        public static bool CanEnter(bool isOccupied, float distanceToSeat, float maxDistance)
        {
            return !isOccupied && distanceToSeat <= maxDistance;
        }
    }
}
