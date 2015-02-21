using System;

namespace Roccat_Talk
{
    /// <summary>
    /// Provides a TalkFX connection. 
    /// Extend this class for implementing keyboard specific functionality.
    /// </summary>
    public abstract class BasicTalkFxConnection : IDisposable
    {
        /// <summary>
        /// Opaque pointer to the unmanaged CROCCAT_Talk class instance
        /// </summary>
        protected readonly IntPtr RoccatHandle;

        protected readonly Func<IntPtr> NewRoccatTalkHandle;
        protected readonly Action<IntPtr> DestroyRoccatTalkHandle;

        protected BasicTalkFxConnection()
        {
            if (Environment.Is64BitProcess)
            {
                NewRoccatTalkHandle = TalkFxBindings.newRoccatTalkHandle_x64;
                DestroyRoccatTalkHandle = TalkFxBindings.destroyRoccatTalkHandle_x64;
            }
            else
            {
                NewRoccatTalkHandle = TalkFxBindings.newRoccatTalkHandle_x86;
                DestroyRoccatTalkHandle = TalkFxBindings.destroyRoccatTalkHandle_x86;
            }

            RoccatHandle = NewRoccatTalkHandle();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~BasicTalkFxConnection()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (RoccatHandle != IntPtr.Zero)
                DestroyRoccatTalkHandle(RoccatHandle);
        }
    }
}