using System.Collections.Generic;
namespace FightingGame
{
    /// <summary>
    /// A player state where the player casts a move from their character's moveset.
    /// </summary>
    public class MoveState : PlayerState
    {
        /// <summary>
        /// The move that this MoveState uses for it's logic.
        /// </summary>
        private readonly MoveData moveData;
        
        /// <summary>
        /// The hitbox that is currently being played.
        /// </summary>
        public Hitbox CurrentMoveHitbox { get; set; } = null;

        /// <summary>
        /// If this move has hit on not, and therefore can be canceled into magic series.
        /// </summary>
        private bool moveHit = false;

        public MoveState(MoveData moveData) : base(StateType.CastingMove, moveData.TotalFrames)
        {
            this.moveData = moveData;
        }

        /// <summary>
        /// Scans if the hitbox has hit anyone or not.
        /// </summary>
        /// <param name="target">The player that this hitbox is scanning for.</param>
        private void UpdateHitbox(PlayerHandler target)
        {
            //Checks to see if hitbox expires.
            if (CurrentMoveHitbox.remainingFrames <= 0)
               CurrentMoveHitbox = null;
            //Checks if the hitbox has made contact with the player.
            else if (CurrentMoveHitbox.TryToHit(target))
            {
                moveHit = true;
                CurrentMoveHitbox = null;
            }
            else CurrentMoveHitbox.remainingFrames--;
        }

        /// <summary>
        /// Fires off all frame events on the current frame.
        /// </summary>
        /// <param name="player">The player preforming the state.</param>
        public override void StateFrameEvent(PlayerHandler player)
        {
            player.CheckAndCastMove(GetMagicSeriesMoves(player));
            //Casts corrisponding events every frame.
            moveData.CastFrameEvent(player, CurrentFrame);
            if (CurrentMoveHitbox != null)
                UpdateHitbox(player);
        }

        //#Debugging.
        /// Issue: Invincability prioritizes player 0
        public override bool IsInvincible() => CurrentFrame > moveData.GetStartup();

        /// <summary>
        /// Gets as list of moves that the player can cancel into base don this move state.
        /// If this move has hit, it will allow canceling of any move of a high rank but if it is not it 
        /// will only allow specials or supers of a higher rank.
        /// </summary>
        /// <param name="player">The player who holds the moves.</param>
        /// <returns>A list of all the moves that a player can chain this move into.</returns>
        private List<MoveData> GetMagicSeriesMoves(PlayerHandler player)
        {
            List<MoveData> magicSeriesMoves = new();
            //Gets the moves that will be searched and filtered through.
            List<MoveData> targetPlayerMoves = player.TouchingFloor ? player.MyCharacter.GroundMoves : player.MyCharacter.AirMoves;
            foreach (var move in targetPlayerMoves)
            {
                //Special moves ranks or higher can be canceled regaurdles if the move hits or not.
                if (move.MagicSeriesLevel >= MagicSeriesLevel.SpecialMove || (move.MagicSeriesLevel > moveData.MagicSeriesLevel && moveHit))
                    magicSeriesMoves.Add(move);
            }
            return magicSeriesMoves;
        }

        public override StatePosture Posture => moveData.MovePosture;

        // Moves will counterhit if the current frame is before the startup or they are casting a hitbox.
        public override bool IsCounterHit() => CurrentFrame >= moveData.GetStartup() || CurrentMoveHitbox != null;

        /// <summary>
        /// Sets the player to stand idle if the player is grounded, or air idle if the player is airborne.
        /// </summary>
        /// <param name="player">The player preforming the state.</param>
        public override PlayerState OnStateExpire(PlayerHandler player) 
        {
            if(player.TouchingFloor)
                return Posture == StatePosture.Standing ? new StandIdleState() : new CrouchState();
            else return new AirIdleState();
        }
    }
}