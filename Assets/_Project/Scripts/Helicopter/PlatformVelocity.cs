using UnityEngine;

namespace ProjetoLuz.Helicopter
{
    public static class PlatformVelocity
    {
        public static Vector3 Track(
            Vector3 smoothedVelocity, Vector3 previousPosition, Vector3 position, float sharpness, float deltaTime)
        {
            if (deltaTime <= 0f)
                return smoothedVelocity;

            var measured = (position - previousPosition) / deltaTime;
            var blend = 1f - Mathf.Exp(-Mathf.Max(0f, sharpness) * deltaTime);
            return Vector3.Lerp(smoothedVelocity, measured, blend);
        }

        public static Vector3 ToRelative(Vector3 worldVelocity, Vector3 platformVelocity)
        {
            return worldVelocity - platformVelocity;
        }

        public static Vector3 ToWorld(Vector3 relativeVelocity, Vector3 platformVelocity)
        {
            return relativeVelocity + platformVelocity;
        }
    }
}
