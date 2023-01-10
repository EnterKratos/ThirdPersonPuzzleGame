using UnityEngine;

namespace EnterKratos
{
    public class TransformMover : MonoBehaviour
    {
        [SerializeField]
        private Axis axis;

        [SerializeField]
        private float amount;

        public void Move()
        {
            var pos = transform.position;
            transform.position = new Vector3(
                axis == Axis.X ? pos.x + amount : pos.x,
                axis == Axis.Y ? pos.y + amount : pos.y,
                axis == Axis.Z ? pos.z + amount : pos.z);
        }
    }
}