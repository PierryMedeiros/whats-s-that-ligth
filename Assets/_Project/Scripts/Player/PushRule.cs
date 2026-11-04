using UnityEngine;

namespace ProjetoLuz.Player
{
    public static class PushRule
    {
        public static bool IsCooldownOver(float lastPushTime, float now, float cooldownSeconds)
        {
            return now - lastPushTime >= cooldownSeconds;
        }

        public static bool IsInRange(Vector3 pusherPosition, Vector3 targetPosition, float maxRange)
        {
            return (targetPosition - pusherPosition).sqrMagnitude <= maxRange * maxRange;
        }

        public static Vector3 KnockbackVelocity(
            Vector3 pusherPosition, Vector3 targetPosition, Vector3 fallbackDirection,
            float horizontalSpeed, float upwardSpeed)
        {
            var direction = Flatten(targetPosition - pusherPosition);
            if (direction == Vector3.zero)
                direction = Flatten(fallbackDirection);

            return direction * Mathf.Max(0f, horizontalSpeed) + Vector3.up * Mathf.Max(0f, upwardSpeed);
        }

        private static Vector3 Flatten(Vector3 vector)
        {
            return new Vector3(vector.x, 0f, vector.z).normalized;
        }
    }
}
