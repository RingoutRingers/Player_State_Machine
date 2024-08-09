namespace FightingGame
{
    /// <summary>
    /// A state where the player long jumps.
    /// After the state expires, the player long jumps.
    /// </summary>
    public class LongJumpState : PlayerState
    {
        /// <summary>
        /// the direction of the jump once the player is launched.
        /// </summary>
        private readonly int direction;
        public LongJumpState(int direction, StateType stateType) : base(stateType, 8)
        {
            this.direction = direction;
        }

        public override void StateFrameEvent(PlayerHandler player)
        {
            player.MovePlayer(direction * (player.MyCharacter.LongJumpArc.horizontalForce / 2f));
        }

        /// <summary>
        /// When the state expires, the proper force for the jump is applied.
        /// </summary>
        /// <param name="player">The player in the state</param>
        public override PlayerState OnStateExpire(PlayerHandler player)
        {
            player.StartJump(player.MyCharacter.LongJumpArc, direction);
            return new AirIdleState();
        }
    }
}