namespace FightingGame
{
    /// <summary>
    /// A start where the player dashes backwards.
    /// The player only moves backwards between certain frames of the move.
    /// </summary>
    public class BackDashState : PlayerState
    {
        public BackDashState() : base(StateType.BackDash, 25) {; }
        public override void StateFrameEvent(PlayerHandler player)
        {
            //if the current frame is within backdash range.
            if (CurrentFrame >= 4 && CurrentFrame < duration - 6)
            {
                player.MovePlayer(player.MyCharacter.BackDashSpeed);
                if (player.RewiredPlayer.GetButtonDown("Vertical"))
                    player.SetPlayerState(new LongJumpState(-1, StateType.LongJumpBack));
            }
        }
        public override bool IsInvincible() => CurrentFrame >= duration - 6;
        public override PlayerState OnStateExpire(PlayerHandler player) => new StandIdleState();
    }
}