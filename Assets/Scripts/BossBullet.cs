using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public float speed;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioManager.instance.PlaySFX(2);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-speed* transform.localScale.x * Time.deltaTime, 0f, 0f); //to flip the bullet
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            PlayerHealthController.instance.DealDamage();
        }
        AudioManager.instance.PlaySFX(1);

        Destroy(gameObject);
    }
}
