namespace FightingGame
{
    /// <summary>
    /// Player walks fowards based on their character's FowardsWalkSpeed.
    /// </summary>
    public class WalkForwardState : IdleState
    {
        public WalkForwardState() : base(StateType.WalkForward) {; }
        public override void StateFrameEvent(PlayerHandler player)
        {
            player.MovePlayer(player.MyCharacter.WalkForwardSpeed);
            base.StateFrameEvent(player);
        }
        public override PlayerState OnStateExpire(PlayerHandler player) => new WalkForwardState();
    }
}