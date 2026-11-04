namespace ProjetoLuz.Player
{
    public static class JumpRule
    {
        public static bool CanJump(bool isGrounded, float secondsSinceLastJump, float cooldownSeconds)
        {
            return isGrounded && secondsSinceLastJump >= cooldownSeconds;
        }
    }
}
