namespace FightingGame
{
    /// <summary>
    /// A state that gives the player a brief lockout window before they are allowed to run.
    /// </summary>
    public class RunStartup : PlayerState
    {
        public RunStartup() : base(StateType.RunStartup, 6) {; }
        /// <summary> Sets player to run state after lockout window.</summary>
        public override PlayerState OnStateExpire(PlayerHandler player) => new RunningState();
    }
}