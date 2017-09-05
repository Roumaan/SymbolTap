using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class MainMenuButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void openChooseCampaignPage()
    {
        Debug.Log("Окно выбора кампании");
    }

    public void startEndlessMode()
    {
        Debug.Log("Начать бесконечный режим");
        SceneManager.LoadScene("EndlessMode");
    }

    public void openTableOfRecords()
    {
        Debug.Log("Открыть таблицу рекордов");
    }

    public void openAboutPage()
    {
        Debug.Log("Об игре");
    }
}
