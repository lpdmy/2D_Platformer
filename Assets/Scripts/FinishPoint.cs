using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") //other.CompareTag("Player")
        {
            SceneController.instance.NextLevel();
        }
    }
}
