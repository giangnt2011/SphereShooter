using UnityEngine;
using UnityEngine.SceneManagement;


public class UtilityScript : MonoBehaviour
{
    void Start()
    {
        Pause();
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Pause()
    {
        Time.timeScale = 0.0f;
    }
    public void UnPause()
    {
        Time.timeScale = 1.0f;
    }
}
