namespace FightingGame
{
    /// <summary>
    /// A state where the player lays on the floor after being hit by a hard knock down.
    /// </summary>
    public class HardKnockdownDownState : PlayerState
    {
        public HardKnockdownDownState() : base(StateType.HardKnockdownDown, 30) {; }
        public override bool IsInvincible() => true;
        public override PlayerState OnStateExpire(PlayerHandler player) => new HardKnockdownStandupState();
    }
}