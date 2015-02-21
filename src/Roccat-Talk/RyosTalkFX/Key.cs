namespace Roccat_Talk.RyosTalkFX
{
    public struct Key
    {
        public byte Code { get; private set; }

        public Key(byte code)
            : this()
        {
            Code = code;
        }
    }
}