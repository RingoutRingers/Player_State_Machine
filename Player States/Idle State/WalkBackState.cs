namespace FightingGame
{
    /// <summary>
    /// Player walks backwards based on their character's BackwardsWalkSpeed.
    /// </summary>
    public class WalkBackState : IdleState
    {
        public WalkBackState() : base(StateType.WalkBack) {; }
        public override void StateFrameEvent(PlayerHandler player)
        {
            player.MovePlayer(player.MyCharacter.WalkBackSpeed);
            base.StateFrameEvent(player);
        }
        public override PlayerState OnStateExpire(PlayerHandler player) => new WalkBackState();
    }
}