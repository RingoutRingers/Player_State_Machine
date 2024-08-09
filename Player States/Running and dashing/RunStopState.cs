namespace FightingGame
{
    /// <summary>
    /// A state that gives the player a brief lockout window before they are allowed to run.
    /// </summary>
    public class RunStopState : PlayerState
    {
        public RunStopState() : base(StateType.RunStop, 6) {; }
        public override void StateFrameEvent(PlayerHandler player)
        {
            player.UpdateDirection();
            player.CheckAndCastMove(player.MyCharacter.GroundMoves);
        }
        public override PlayerState OnStateExpire(PlayerHandler player) => new StandIdleState();
    }
}