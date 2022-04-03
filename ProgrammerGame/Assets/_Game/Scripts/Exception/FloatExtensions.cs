namespace _Game.Scripts.Exception
{
    public static class FloatExtensions
    {
        public static string ToPriceString(this float value)
        {
            return value.ToString();
        }
        
        public static string ToPriceString(this long value)
        {
            return value.ToString();
        }
    }
}