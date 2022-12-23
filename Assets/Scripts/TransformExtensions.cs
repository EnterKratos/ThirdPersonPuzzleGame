using UnityEngine;

namespace EnterKratos
{
    public static class TransformExtensions
    {
        public static void RotateTowards(this Transform transform, Transform target, float rotationSpeed)
        {
            var direction = (target.position - transform.position).normalized;
            var lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
        }
    }
}