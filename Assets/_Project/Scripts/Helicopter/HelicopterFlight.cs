using UnityEngine;

namespace ProjetoLuz.Helicopter
{
    public static class HelicopterFlight
    {
        public static Vector3 TargetVelocity(
            float forwardInput, float liftInput, float headingDegrees, float maxForwardSpeed, float maxVerticalSpeed)
        {
            var forward = Quaternion.Euler(0f, headingDegrees, 0f) * Vector3.forward;
            var horizontal = forward * (Mathf.Clamp(forwardInput, -1f, 1f) * Mathf.Max(0f, maxForwardSpeed));
            var vertical = Vector3.up * (Mathf.Clamp(liftInput, -1f, 1f) * Mathf.Max(0f, maxVerticalSpeed));
            return horizontal + vertical;
        }

        public static Vector3 Accelerate(
            Vector3 current, Vector3 target, float horizontalAcceleration, float verticalAcceleration, float deltaTime)
        {
            var step = Mathf.Max(0f, deltaTime);
            var currentHorizontal = new Vector3(current.x, 0f, current.z);
            var targetHorizontal = new Vector3(target.x, 0f, target.z);
            var horizontal = Vector3.MoveTowards(
                currentHorizontal, targetHorizontal, Mathf.Max(0f, horizontalAcceleration) * step);
            var vertical = Mathf.MoveTowards(current.y, target.y, Mathf.Max(0f, verticalAcceleration) * step);
            return new Vector3(horizontal.x, vertical, horizontal.z);
        }

        public static float YawRate(
            float currentDegreesPerSecond, float turnInput, float maxDegreesPerSecond, float acceleration, float deltaTime)
        {
            var target = Mathf.Clamp(turnInput, -1f, 1f) * Mathf.Max(0f, maxDegreesPerSecond);
            return Mathf.MoveTowards(currentDegreesPerSecond, target, Mathf.Max(0f, acceleration) * Mathf.Max(0f, deltaTime));
        }
    }
}
