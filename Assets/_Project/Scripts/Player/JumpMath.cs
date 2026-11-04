using UnityEngine;

namespace ProjetoLuz.Player
{
    public static class JumpMath
    {
        public static float VelocityForHeight(float height, float gravityMagnitude)
        {
            return Mathf.Sqrt(2f * Mathf.Max(0f, gravityMagnitude) * Mathf.Max(0f, height));
        }
    }
}
