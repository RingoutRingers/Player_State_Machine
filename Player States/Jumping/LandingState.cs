namespace FightingGame
{
    /// <summary>
    /// A brief lockout
    /// </summary>
    public class LandingState : PlayerState
    {
        public LandingState() : base(StateType.Landing, 3) {; }
        public override bool CanBlock => true;
        public override void StateFrameEvent(PlayerHandler player) => player.UpdateDirection();
        public override PlayerState OnStateExpire(PlayerHandler player) => new StandIdleState();
    }
}