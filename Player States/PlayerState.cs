using UnityEngine;
namespace FightingGame
{
    /// <summary>
    /// A class that holds the data and logic for each state a player can be in.
    /// </summary>
    public abstract class PlayerState
    {
        /// <summary> The state type of this state.</summary>
        public readonly StateType stateType;
        /// <summary> How many frames this state lasts for.</summary>
        public readonly int duration;
        /// <summary> How many frames the player has been in this state for.</summary>
        private int currentFrame = 0;
        public int CurrentFrame => currentFrame;

        public PlayerState(StateType stateType, int duration)
        {
            this.stateType = stateType;
            this.duration = duration;
        }

        /// <summary>
        /// What type of posture this state is.
        /// </summary>
        public virtual StatePosture Posture => StatePosture.Standing;

        /// <summary>
        /// If the player can block while in this state.
        /// </summary>
        public virtual bool CanBlock => false;

        /// <summary>
        /// If the state is currently invincble and therefore unable to be hit by attacks.
        /// </summary>
        public virtual bool IsInvincible() => false;

        /// <summary>
        /// If the player got hit on this frame, would it be a counter hit?
        /// By default, this always returns false, as most states are not abled to be counter hit,
        /// but it can be overriden to apply counter hit logic to it.
        /// </summary>
        /// <returns>True if the result is a counter it. Otherwise it returns false.</returns>
        public virtual bool IsCounterHit() => false;

        /// <summary> Player calls this action every frame.</summary>
        /// <param name="player">The player who is preforming the logic for the state.</param>.
        public void UpdateState(PlayerHandler player)
        {
            Debug.Log($"CurrentFrame {currentFrame}");
            StateFrameEvent(player);
            currentFrame++;
            if (currentFrame >= duration)
                player.SetPlayerState(OnStateExpire(player));
        }

        /// <summary> Preforms X logic every frame.</summary>
        /// <param name="player">The player preforming this state.</param>
        public virtual void StateFrameEvent(PlayerHandler player) {; }

        /// <summary>
        /// Preforms X logic when the current frame reaches the duration, 
        /// and returns the state the player is forced into on end.
        /// This is done so it can force the player into a state when it ends.
        /// </summary>
        /// <param name="player">The player preforming this state.</param>
        /// <returns> The state that the player is forced to upon ending.</returns>
        public abstract PlayerState OnStateExpire(PlayerHandler player);

        /// <summary>
        /// Logic that is preformed whenever the player lands during this state.
        /// By default, this is simply set to force the player into the "Landing" state but can be overridden
        /// so that different state logic can be applied on landing.
        /// </summary>
        /// <param name="player">The player who is preforming the logic for the state.</param>.
        public virtual void OnLandLogic(PlayerHandler player) => player.SetPlayerState(new LandingState());
        public override string ToString() => stateType.ToString();
    }
}