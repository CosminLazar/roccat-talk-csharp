namespace Roccat_Talk.TalkFX
{
    public enum Zone : byte
    {
        /// <summary>
        /// Represents slow changing atmospheric lighting, for example a Ambilight-style lighting effect. Or a slow green pulse when the player is poisoned in an adventure game
        /// Use Ambient when you have a low rate of updates. (When in doubt: use Event)
        /// </summary>
        Ambient = 0,

        /// <summary>
        /// Represents short atmospheric blinks. For example a red flash, when being struck by an enemy, or a white flash when a checkpoint is reached
        /// Use Event for fast paced updates. (When in doubt: use Event)
        /// </summary>
        Event = 1
    }
}
