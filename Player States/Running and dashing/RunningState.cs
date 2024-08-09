namespace FightingGame
{
    /// <summary>
    /// A looping state where the player runs fowards.
    /// </summary>
    public class RunningState : PlayerState
    {
        public RunningState() : base(StateType.Running, 30) {; }
        public override void StateFrameEvent(PlayerHandler player)
        {
            player.MovePlayer(player.MyCharacter.RunSpeed);
            //Checks for transitions.
            if (player.RewiredPlayer.GetButtonDown("Vertical"))
                player.SetPlayerState(new LongJumpState(1, StateType.LongJumpFowards));
            else if (player.RewiredPlayer.GetAxisRaw("Horizontal") != player.FaceDirection)
                player.SetPlayerState(new RunStopState());
            player.CheckAndCastMove(player.MyCharacter.GroundMoves);
        }
        public override PlayerState OnStateExpire(PlayerHandler player) => new RunningState();
    }
}