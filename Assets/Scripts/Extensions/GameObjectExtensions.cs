using UnityEngine;

namespace EnterKratos.Extensions
{
    public static class GameObjectExtensions
    {
        public const string PlayerTag = "Player";

        public static bool IsPlayer(this GameObject gameObject)
        {
            return gameObject.CompareTag(PlayerTag);
        }
    }
}