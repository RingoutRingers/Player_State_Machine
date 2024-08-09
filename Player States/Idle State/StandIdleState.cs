namespace FightingGame
{
    /// <summary> 
    /// Player is standing during idle.
    /// Player goes to this state when no buttons are pressed.
    /// It is considered the "default" state for the player.
    /// </summary>
    public class StandIdleState : IdleState
    {
        public StandIdleState() : base(StateType.StandIdle) {; }
        public override PlayerState OnStateExpire(PlayerHandler player) => new StandIdleState();
    }
}