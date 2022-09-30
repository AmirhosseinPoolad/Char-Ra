using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    public Scene turntableScene;
    public Scene tunnelTurningScene;

    public void TurntableMode()
    {
        SceneManager.LoadScene(1);
    }
    public void TunnelTurningMode()
    {
        SceneManager.LoadScene(2);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
