using UnityEngine;
using UnityEngine.SceneManagement;

namespace EnterKratos
{
    public class RestartLevel : MonoBehaviour
    {
        public void Restart()
        {
            var activeScene = SceneManager.GetActiveScene().buildIndex;

            SceneManager.LoadSceneAsync(activeScene);
        }
    }
}
