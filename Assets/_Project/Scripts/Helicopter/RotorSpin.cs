using UnityEngine;

namespace ProjetoLuz.Helicopter
{
    public static class RotorSpin
    {
        public static float Step(
            float currentSpeed, bool isEngineOn, float maxSpeed, float spinUpRate, float spinDownRate, float deltaTime)
        {
            var target = isEngineOn ? Mathf.Max(0f, maxSpeed) : 0f;
            var rate = isEngineOn ? spinUpRate : spinDownRate;
            return Mathf.MoveTowards(currentSpeed, target, Mathf.Max(0f, rate) * Mathf.Max(0f, deltaTime));
        }
    }
}
