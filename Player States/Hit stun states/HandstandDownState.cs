namespace FightingGame
{
    /// <summary>
    /// A state where the player reaches the ground during juggle.
    /// It functions like a soft recoverable knockdown.
    /// </summary>
    public class HandstandDownState : PlayerState
    {
        public HandstandDownState() : base(StateType.HandstandDown, 10) {; }
        //Checks what recover type to enter.
        public override PlayerState OnStateExpire(PlayerHandler player)
        {
            if(player.RewiredPlayer.GetAxisRaw("Horizontal") == player.FaceDirection)
                return new HandStandRecoveryState(1, StateType.HandstandRecoverForwards);
            if(player.RewiredPlayer.GetAxisRaw("Horizontal") == -player.FaceDirection)
                return new HandStandRecoveryState(-1, StateType.HandstandRecoverBackwards);
            return new HandStandRecoveryState(0, StateType.HandstandRecoverNeutral);
        }
        /// <summary>
        /// Ignores player landing.
        /// </summary>
        public override void OnLandLogic(PlayerHandler player) {; }
        public override bool IsInvincible() => true;
    }
}