using UnityEngine;
using UnityEngine.SceneManagement;
public class Victory : MonoBehaviour
{
    public string mainMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }
}
