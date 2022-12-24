using UnityEngine;

namespace EnterKratos
{
    public class Rotate : MonoBehaviour
    {
        public enum Axis { X, Y, Z }

        public float speed;
        public Axis axis;


        private void Update()
        {
            var rotation = Time.deltaTime * speed;
            var x = axis == Axis.X ? rotation : 0;
            var y = axis == Axis.Y ? rotation : 0;
            var z = axis == Axis.Z ? rotation : 0;

            transform.Rotate(new Vector3(x, y, z));
        }
    }
}
