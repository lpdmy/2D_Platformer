using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //FindObjectOfType loi thoi
            //FindAnyObjectByType<PlayerHealthController>().DealDamage();
            PlayerHealthController.instance.DealDamage();
        }
    }
}
