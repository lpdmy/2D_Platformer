using UnityEngine;

public class Pickup : MonoBehaviour
{
    public bool isGem, isHeal;

    private bool isCollected;
    public GameObject pickupEffect;

    void Start()
    {
        
    }

    void Update()
    {

    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            if (isGem)
            {
                LevelManager.instance.gemsCollected++;
                isCollected = true;
                Destroy(gameObject);
                AudioManager.instance.PlaySFX(6);
                Instantiate(pickupEffect, transform.position, transform.rotation);


                UIController.instance.UpdateGemCount();

                
            }
            if (isHeal)
            {
                if (PlayerHealthController.instance.currentHealth != PlayerHealthController.instance.maxHealth)
                {
                    PlayerHealthController.instance.HealPlayer();
                    isCollected = true;
                    Destroy(gameObject);
                    AudioManager.instance.PlaySFX(7);
                    Instantiate(pickupEffect, transform.position, transform.rotation);
                    
                }
            }
        }
      
    }
}
