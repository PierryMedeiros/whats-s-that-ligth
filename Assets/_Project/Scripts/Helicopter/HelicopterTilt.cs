using UnityEngine;

namespace ProjetoLuz.Helicopter
{
    public static class HelicopterTilt
    {
        public static float Fraction(float value, float max)
        {
            if (max <= 0f)
                return 0f;

            return Mathf.Clamp(value / max, -1f, 1f);
        }

        public static float Pitch(
            float speedFraction, float accelerationFraction,
            float degreesAtFullSpeed, float degreesAtFullAcceleration, float maxDegrees)
        {
            var pitch = speedFraction * degreesAtFullSpeed + accelerationFraction * degreesAtFullAcceleration;
            var limit = Mathf.Max(0f, maxDegrees);
            return Mathf.Clamp(pitch, -limit, limit);
        }

        public static float Roll(float yawFraction, float degreesAtFullYaw)
        {
            return -yawFraction * degreesAtFullYaw;
        }

        public static float Smooth(float current, float target, float sharpness, float deltaTime)
        {
            var blend = 1f - Mathf.Exp(-Mathf.Max(0f, sharpness) * Mathf.Max(0f, deltaTime));
            return current + (target - current) * blend;
        }
    }
}
