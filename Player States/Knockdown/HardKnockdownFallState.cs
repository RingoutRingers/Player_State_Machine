namespace FightingGame
{
    /// <summary>
    /// A state where the player falls before a hard knockdown.
    /// After landing, they will be grounded.
    /// </summary>
    public class HardKnockdownFallState : PlayerState
    {
        public HardKnockdownFallState() : base(StateType.HardKnockdownFall, 10) {; }
        public override PlayerState OnStateExpire(PlayerHandler player) => new HardKnockdownFallState();
        public override bool IsInvincible() => true;
        public override void OnLandLogic(PlayerHandler player) => player.SetPlayerState(new HardKnockdownDownState());
    }
}