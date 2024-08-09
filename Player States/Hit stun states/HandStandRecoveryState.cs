namespace FightingGame
{
    /// <summary>
    /// Player recovers in the chosen dirrection after handstand down has played.
    /// </summary>
    public class HandStandRecoveryState : PlayerState
    {
        /// <summary>
        /// The horizontal force applied to the player on handstand recovery.
        /// </summary>
        private const int HandstandRecoverForce = 8;

        /// <summary>
        /// The force applied to the player.
        /// </summary>
        private readonly int direction;

        /// <param name="direction">
        /// What direction the recovery will go.
        /// 1 is fowards. 0 is nuetral. -1 is backwards.
        /// </param>
        public HandStandRecoveryState(int direction, StateType stateType) : base(stateType, 15)
        {
            this.direction = direction;
        }

        public override void OnLandLogic(PlayerHandler player) {; }

        //Moves player based on tech direction.
        public override void StateFrameEvent(PlayerHandler player)
        {
            player.MovePlayer(HandstandRecoverForce * direction, 12);
        }

        /// <summary>
        /// Sets the player to stand idle if the player is grounded, or air idle if the player is airborne.
        /// </summary>
        /// <param name="player">The player preforming the state.</param>
        public override PlayerState OnStateExpire(PlayerHandler player)
        {
            //Sets player to a different state depending on if it is grounded or in the air.
            if (player.TouchingFloor)
                return Posture == StatePosture.Standing ? new StandIdleState() : new CrouchState();
            else return new AirIdleState();
        }
        public override bool IsInvincible() => true;
    }
}