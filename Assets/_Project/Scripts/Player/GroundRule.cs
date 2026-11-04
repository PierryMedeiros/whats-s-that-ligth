using UnityEngine;

namespace ProjetoLuz.Player
{
    public static class GroundRule
    {
        public static bool IsWalkable(Vector3 surfaceNormal, float maxSlopeDegrees)
        {
            return Vector3.Angle(surfaceNormal, Vector3.up) <= maxSlopeDegrees;
        }
    }
}
