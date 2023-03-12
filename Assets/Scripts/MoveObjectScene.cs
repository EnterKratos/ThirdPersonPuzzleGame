using EnterKratos.Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EnterKratos
{
    public class MoveObjectScene : MonoBehaviour
    {
        public void Move(Collider other)
        {
            if (other.TryGetComponent<ObjectsToMove>(out var objectsToMove))
            {
                foreach (var obj in objectsToMove.objects)
                {
                    MoveObjectToScene(obj);
                }
            }
            else
            {
                MoveObjectToScene(other.gameObject);
            }

        }

        private void MoveObjectToScene(GameObject obj)
        {
            SceneManager.MoveGameObjectToScene(obj, gameObject.scene);

            if (obj.TryGetComponent<SceneArrivalHandler>(out var handler))
            {
                handler.OnSceneArrival();
            }

            if (obj.IsPlayer())
            {
                // TODO: Fix setting active scene lighting issue
                // SceneManager.SetActiveScene(gameObject.scene);
            }
        }
    }
}