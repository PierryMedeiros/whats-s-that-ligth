using UnityEngine;

namespace ProjetoLuz.Player
{
    public static class GroundMovement
    {
        public static Vector3 TargetVelocity(Vector2 input, float yawDegrees, float speed)
        {
            var clampedInput = Vector2.ClampMagnitude(input, 1f);
            var localDirection = new Vector3(clampedInput.x, 0f, clampedInput.y);
            var worldDirection = Quaternion.Euler(0f, yawDegrees, 0f) * localDirection;
            return worldDirection * Mathf.Max(0f, speed);
        }

        public static Vector3 Accelerate(Vector3 current, Vector3 target, float acceleration, float deltaTime)
        {
            var maxChange = Mathf.Max(0f, acceleration) * Mathf.Max(0f, deltaTime);
            return Vector3.MoveTowards(current, target, maxChange);
        }
    }
}
