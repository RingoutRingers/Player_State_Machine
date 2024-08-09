namespace FightingGame
{
    /// <summary>
    /// Player stands up after being downed with a hard Knockdown.
    /// </summary>
    public class HardKnockdownStandupState : PlayerState
    {
        public HardKnockdownStandupState() : base(StateType.HardKnockdownStandup, 30) {; }
        public override bool IsInvincible() => true;
        public override PlayerState OnStateExpire(PlayerHandler player) => new StandIdleState();
    }
}