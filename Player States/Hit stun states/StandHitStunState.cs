namespace FightingGame
{
    /// <summary>
    /// Player is in hitstun while standing.
    /// </summary>
    public class StandHitStunState : PlayerState
    {
        public StandHitStunState(StateType stateType, int duration) : base(stateType, duration) {; }
        public override PlayerState OnStateExpire(PlayerHandler player) => new StandIdleState();
    }
}