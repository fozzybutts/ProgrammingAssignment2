using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    // Written by AJ.
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
