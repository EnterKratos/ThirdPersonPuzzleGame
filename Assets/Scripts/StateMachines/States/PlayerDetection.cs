using System;
using UnityEngine;

namespace EnterKratos.StateMachines.States
{
    public static class PlayerDetection
    {
        public const int BufferSize = 1;

        public static bool DetectPlayer(Vector3 position, float detectionRadius, Collider[] colliderBuffer, LayerMask layerMask)
        {
            Array.Clear(colliderBuffer, 0, BufferSize);
            var foundColliders = Physics.OverlapSphereNonAlloc(position, detectionRadius, colliderBuffer, layerMask);
            return foundColliders > 0;
        }
    }
}