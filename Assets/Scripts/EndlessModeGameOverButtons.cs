using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class EndlessModeGameOverButtons : MonoBehaviour {

    public void restart()
    {
        SceneManager.LoadScene("EndlessMode");
    }

    public void exit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
