using UnityEngine;

public class BossTankMine : MonoBehaviour
{
    public GameObject explosion;

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
        if(other.tag == "Player")
        {
            Destroy(gameObject);

            Instantiate(explosion,transform.position,transform.rotation);

            PlayerHealthController.instance.DealDamage();

            AudioManager.instance.PlaySFX(3);
        }
    }

    public void Explode()
    {
        Destroy(gameObject);

        AudioManager.instance.PlaySFX(3);

        Instantiate(explosion, transform.position, transform.rotation);
    }
}
