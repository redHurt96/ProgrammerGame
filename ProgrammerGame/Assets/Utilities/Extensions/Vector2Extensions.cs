using UnityEngine;

namespace RH.Utilities.Extensions
{
    public static class Vector3Extensions
    {
        public static Vector3 AddRandomInBox(this Vector3 origin, Vector3 size)
        {
            return origin + new Vector3(
                         Random.Range(-size.x, size.x),
                         Random.Range(-size.y, size.y),
                         Random.Range(-size.z, size.z));
        }
    }

    public static class Vector2Extensions
    {
        public static bool Approximately(this Vector2 a, Vector2 b)
        {
            return Mathf.Approximately(a.x, b.x) && Mathf.Approximately(a.y, b.y);
        }
    }
}