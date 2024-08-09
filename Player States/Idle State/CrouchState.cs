namespace FightingGame
{
    /// <summary>
    /// Player is crouching during idle.
    /// </summary>
    public class CrouchState : IdleState
    {
        public CrouchState() : base(StateType.Crouch) {; }
        public override PlayerState OnStateExpire(PlayerHandler player) => new CrouchState();
        public override StatePosture Posture => StatePosture.Crouching;
    }
}