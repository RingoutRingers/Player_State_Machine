namespace FightingGame
{
    /// <summary> A state where the player is idle in the air.</summary>
    public class AirIdleState : PlayerState
    {
        public AirIdleState() : base(stateType: StateType.AirIdle, 30) {; }
        public override void StateFrameEvent(PlayerHandler player)
        {
            //Checks and attempts to cast air moves.
            player.CheckAndCastMove(player.MyCharacter.AirMoves);
        }
        public override PlayerState OnStateExpire(PlayerHandler player) => new AirIdleState();
    }
}