using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelSelectManager : MonoBehaviour
{

    public LevelSelectPlayer thePlayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private MapPoint[] allPoints;

    void Start()
    {
        //load the player's position in map point 
        allPoints = FindObjectsOfType<MapPoint>();

        if (PlayerPrefs.HasKey("CurrentLevel"))
        {
            foreach (MapPoint point in allPoints)
            {
                if (point.levelToLoad == PlayerPrefs.GetString("CurrentLevel"))
                {
                    thePlayer.transform.position = point.transform.position;
                    thePlayer.currentPoint = point;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel()
    {
        StartCoroutine(LoadLevelCo());
    }

    public IEnumerator LoadLevelCo()
    {
        AudioManager.instance.PlaySFX(4);
        LevelSelectUIController.instance.FadeToBlack();

        yield return new WaitForSeconds(1f / LevelSelectUIController.instance.fadeSpeed * .25f);

        SceneManager.LoadScene(thePlayer.currentPoint.levelToLoad);
    }
}
