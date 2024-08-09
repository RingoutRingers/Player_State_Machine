namespace FightingGame
{
    /// <summary>
    /// Represents a state where the player is in hitstun in the air.
    /// </summary>
    public class AirJuggleState : PlayerState
    {
        public AirJuggleState(int duration) : base(StateType.AirJuggle, duration) {; }
        public override PlayerState OnStateExpire(PlayerHandler player) => new AirIdleState();
        public override void OnLandLogic(PlayerHandler player) => player.SetPlayerState(new HandstandDownState());
    }
}