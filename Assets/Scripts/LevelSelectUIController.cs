using UnityEngine;
using UnityEngine.UI;


public class LevelSelectUIController : MonoBehaviour
{
    public static LevelSelectUIController instance;

    public Image fadeScreen;
    public float fadeSpeed;
    private bool shouldFadeToBlack, shouldFadeFromBlack;

    public GameObject LevelInfoPanel;

    public Text levelName, gemsFound, gemsTarget, bestTime, timeTarget;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        FadeFromBlack();
    }

    void Update()
    {
        if (shouldFadeToBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
            if (fadeScreen.color.a == 1f)
            {
                shouldFadeToBlack = false;
            }
        }

        if (shouldFadeFromBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
            if (fadeScreen.color.a == 0f)
            {
                shouldFadeFromBlack = false;
            }
        }
    }

    public void FadeToBlack()
    {
        shouldFadeToBlack = true;
        shouldFadeFromBlack = false;
    }

    public void FadeFromBlack()
    {
        shouldFadeFromBlack = true;
        shouldFadeToBlack = false;
    }
    //show level name 
    public void ShowInfo(MapPoint levelInfo)
    {
        levelName.text = levelInfo.levelName;

        gemsFound.text = "FOUND: " + levelInfo.gemsCollected;
        gemsTarget.text = "IN LEVEL: " + levelInfo.totalGems;

        timeTarget.text = "TARGET: " + levelInfo.targetTime + "s";
        if(levelInfo.bestTime == 0)
        {
            bestTime.text = "BEST: ---";
        }
        else
        {
            bestTime.text = "BEST: " + levelInfo.bestTime.ToString("F2") + "s";
        }

        LevelInfoPanel.SetActive(true);
        
    }
    public void HideInfo()
    {
        LevelInfoPanel.SetActive(false);
    }
}
