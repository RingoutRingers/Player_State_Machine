namespace FightingGame
{
    /// <summary>
    /// An abstract state that IdleStates fall under.
    /// This includes StandIdle.
    /// </summary>
    public abstract class IdleState : PlayerState
    {
        public IdleState(StateType stateType) : base(stateType, 30) {; }
        public override bool CanBlock => true;
        public override void StateFrameEvent(PlayerHandler player)
        {
            // Checks what state to transition idle to.
            static PlayerState IdleStateTransition(PlayerHandler player)
            {
                Rewired.Player rewiredPlayer = player.RewiredPlayer;
                int FaceDirection = player.FaceDirection;

                //Checks for run or backdash.
                if (rewiredPlayer.GetButtonDoublePressDown("Horizontal"))
                    return (FaceDirection == 1) ? new RunStartup() : new BackDashState();
                if (rewiredPlayer.GetNegativeButtonDoublePressDown("Horizontal"))
                    return (FaceDirection == -1) ? new RunStartup() : new BackDashState();

                //Checks for jumps
                if (rewiredPlayer.GetAxis("Vertical") > 0)
                {
                    if (rewiredPlayer.GetAxisRaw("Horizontal") == FaceDirection)
                        return new PrejumpState(1, StateType.PreJumpForward);
                    else if (rewiredPlayer.GetAxisRaw("Horizontal") == -FaceDirection)
                        return new PrejumpState(-1, StateType.PreJumpBack);

                    return new PrejumpState(0, StateType.PreJumpNeutral);
                }

                //Holding downwards
                if (rewiredPlayer.GetAxisRaw("Vertical") < 0)
                    return new CrouchState();

                //Holding forwards
                if (rewiredPlayer.GetAxisRaw("Horizontal") == FaceDirection)
                    return new WalkForwardState();

                //Holding backwards
                if (rewiredPlayer.GetAxisRaw("Horizontal") == -FaceDirection)
                    return new WalkBackState();

                //Goes to idle if not conditions are met.
                return new StandIdleState();
            }
            //Player wants to transition to a new state.
            var setState = IdleStateTransition(player);
            if (player.CurrentPlayerState.stateType != setState.stateType)
            {
                player.SetPlayerState(setState);
                //Updates state. This is so that actions can be preformed on frame 1 of idle.
                setState.UpdateState(player);
            }
            player.UpdateDirection();
            player.CheckAndCastMove(player.MyCharacter.GroundMoves);
        }
    }
}