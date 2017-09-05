using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class EndlessModeController : MonoBehaviour
{

    bool gameStarted = false;

    public GameObject recordSaver;
    public GameObject scoreCounter;
    int score;

    public GameObject getReadyImg;

    public GameObject timer;

    const float time = 30;
    float remainingTime;

    public GameObject boardSymbolImg;
    public GameObject[] buttonsSymbolImgs;
    public Sprite[] sprites;

    byte[] buttonsSymbolIds = new byte[20];

    byte trueButtonId;
    byte trueSymbolId;

    // Use this for initialization
    void Start()
    {
        Image img = boardSymbolImg.GetComponent<Image>();
        img.color = new Color(img.color.r, img.color.g, img.color.b, 0);

        for (int i = 0; i < buttonsSymbolImgs.Length; i++)
        {
            img = buttonsSymbolImgs[i].GetComponent<Image>();
            img.color = new Color(img.color.r, img.color.g, img.color.b, 0);

        }

        remainingTime = 4;

    }

    // Update is called once per frame
    void Update()
    {
        if (gameStarted)
        {

            float remainingTimePercent = ((remainingTime * 1) / time);

            RectTransform timerTransform = (RectTransform)timer.transform;
            timerTransform.anchoredPosition = new Vector2((-(timerTransform.rect.width * 0.85F) * (1 - remainingTimePercent)), timerTransform.anchoredPosition.y);

            remainingTime -= Time.deltaTime;
            if (remainingTime <= 0)
            {
                gameOver();
            }
        }
        else
        {
            remainingTime -= Time.deltaTime;

            if (remainingTime <= 4)
            {
                Image img = getReadyImg.GetComponent<Image>();
                img.color = new Color(img.color.r, img.color.g, img.color.b, remainingTime - 3f);
                //getReadyImg.SetActive(false);
            }

            if (remainingTime <= 3 && remainingTime > 2)
            {
                Debug.Log(3);
            }
            else if (remainingTime <= 2 && remainingTime > 1)
            {
                Debug.Log(2);
            }
            else if (remainingTime <= 1 && remainingTime > 0)
            {
                Debug.Log(1);
            }
            else if (remainingTime < 0)
            {
                Image img = boardSymbolImg.GetComponent<Image>();
                img.color = new Color(img.color.r, img.color.g, img.color.b, 1);

                for (int i = 0; i < buttonsSymbolImgs.Length; i++)
                {
                    img = buttonsSymbolImgs[i].GetComponent<Image>();
                    img.color = new Color(img.color.r, img.color.g, img.color.b, 1);

                }

                remainingTime = time;
                randomiseSymbols();
                applySymbols();
                gameStarted = true;
            }
        }
    }

    public void onClick(int buttonId)
    {
        if (gameStarted)
        {
            if (buttonId == trueButtonId)
            {
                score++;
                scoreCounter.GetComponent<UnityEngine.UI.Text>().text = score.ToString();

                remainingTime += 0.5f;
                randomiseSymbols();
                applySymbols();
            }
            else
            {
                gameOver();
            }
        }
    }

    void randomiseSymbols()
    {

        ArrayList availibleSymbols = new ArrayList();
        for (int i = 0; i < 10; i++)
        {
            availibleSymbols.Add((byte)i);
        }

        trueButtonId = (byte)Random.Range(0, 3);
        trueSymbolId = (byte)availibleSymbols[Random.Range(0, availibleSymbols.Count)];
        availibleSymbols.Remove(trueSymbolId);

        for (int i = 0; i < buttonsSymbolImgs.Length; i++)
        {
            buttonsSymbolIds[i] = (byte)availibleSymbols[Random.Range(0, availibleSymbols.Count)];
            availibleSymbols.Remove(buttonsSymbolIds[i]);
        }

        buttonsSymbolIds[trueButtonId] = trueSymbolId;
    }

    void applySymbols()
    {
        boardSymbolImg.transform.GetComponent<Image>().sprite = sprites[trueSymbolId];

        for (int i = 0; i < buttonsSymbolImgs.Length; i++)
        {
            buttonsSymbolImgs[i].transform.GetComponent<Image>().sprite = sprites[buttonsSymbolIds[i]];
        }
    }

    void gameOver()
    {
        recordSaver.GetComponent<RecordSaver>().save(score);
        SceneManager.LoadScene("EndlessModeGameOver");
    }
}
