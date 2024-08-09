namespace FightingGame
{
    /// <summary>
    /// A brief lockout window before the player jumps.
    /// It also calculates if the input is a hop or a full jump.
    /// </summary>
    public class PrejumpState : PlayerState
    {
        /// the direction of the jump once the player is launched.
        /// </summary>
        private readonly int direction;

        public PrejumpState(int direction, StateType stateType) : base(stateType, 5)
        {
            this.direction = direction;
        }

        /// <summary>
        /// When the state expires, the proper force for the jump is applied.
        /// </summary>
        /// <param name="player">The player in the state</param>
        public override PlayerState OnStateExpire(PlayerHandler player)
        {
            JumpArcData jumpArc;
            if (player.RewiredPlayer.GetButtonTimePressed("Vertical") >= 4 / 60f) 
                jumpArc = player.MyCharacter.NormalJumpArc;
            else jumpArc = player.MyCharacter.HopArc;
            player.StartJump(jumpArc, direction);
            return new AirIdleState();
        }
    }
}