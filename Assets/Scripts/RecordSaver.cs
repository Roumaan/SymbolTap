using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class RecordSaver : MonoBehaviour {

    public int record;
    public int score;

    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(transform);
        score = 0;   
    }

    void OnEnable()
    {
        //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Level Loaded");
        record = PlayerPrefs.GetInt("record" + scene);
    }

    // Update is called once per frame
    void Update () {

    }

    public void save (int score)
    {
        this.score = score;
        if (score > record) record = score;

        PlayerPrefs.SetInt("record" + SceneManager.GetActiveScene(), record);
        PlayerPrefs.Save();
    }

    public void post ()
    {
        GameObject recordObject = GameObject.Find("Record");
        recordObject.GetComponent<UnityEngine.UI.Text>().text = "Record: " + record;

        GameObject resultObject = GameObject.Find("Result");
        resultObject.GetComponent<UnityEngine.UI.Text>().text = "Result: " + score;

        score = 0;

        Destroy(transform.gameObject);
    }

    public int Record
    {
        get
        {
            return record;
        }
    }

    public int Score
    {
        get
        {
            return score;
        }
    }
}
