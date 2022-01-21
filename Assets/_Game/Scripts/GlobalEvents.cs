using System;

namespace AP.ProgrammerGame
{
    public class GlobalEvents
    {
        public static event Action CodeWritten;

        public static void WriteCode() => CodeWritten?.Invoke();
    }
}