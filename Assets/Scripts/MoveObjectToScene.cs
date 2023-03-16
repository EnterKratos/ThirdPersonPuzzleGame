using EnterKratos.Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EnterKratos
{
    public class MoveObjectToScene : MonoBehaviour
    {
        public void Move(Collider other)
        {
            MoveInternal(other.gameObject);
        }

        public void Move(GameObject other)
        {
            MoveInternal(other);
        }

        private void MoveInternal(GameObject other)
        {
            if (other.TryGetComponent<ObjectsToMove>(out var objectsToMove))
            {
                foreach (var obj in objectsToMove.objects)
                {
                    MoveGameObjectToScene(obj);
                }
            }
            else
            {
                MoveGameObjectToScene(other.gameObject);
            }
        }

        private void MoveGameObjectToScene(GameObject obj)
        {
            SceneManager.MoveGameObjectToScene(obj, gameObject.scene);

            if (obj.TryGetComponent<SceneArrivalHandler>(out var handler))
            {
                handler.OnSceneArrival();
            }

            if (obj.IsPlayer())
            {
                SceneManager.SetActiveScene(gameObject.scene);
            }
        }
    }
}