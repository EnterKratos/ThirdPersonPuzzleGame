using UnityEngine;

namespace EnterKratos.Extensions
{
    public static class GameObjectExtensions
    {
        private const string PlayerTag = "Player";

        public static bool IsPlayer(this GameObject gameObject)
        {
            return gameObject.CompareTag(PlayerTag);
        }
    }
}