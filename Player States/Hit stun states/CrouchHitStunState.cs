namespace FightingGame
{
    /// <summary>
    /// Player is in hit stun while crouching.
    /// </summary>
    public class CrouchHitStunState : PlayerState
    {
        public CrouchHitStunState(StateType stateType, int duration) : base(stateType, duration) {; }
        public override PlayerState OnStateExpire(PlayerHandler player) => new CrouchState();
        public override StatePosture Posture => StatePosture.Crouching;
    }
}