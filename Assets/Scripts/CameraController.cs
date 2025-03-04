using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    
    public Transform target;

    public Transform farBackground, middleBackground;

    public float minHeight, maxHeight;

    public bool stopFollow;

    private Vector2 lastPos;

    void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {   
        if (!stopFollow)
        {
            transform.position = new Vector3(target.position.x, Mathf.Clamp(target.transform.position.y, minHeight, maxHeight), transform.position.z);

            Vector2 amountToMove = new Vector2(transform.position.x - lastPos.x, transform.position.y - lastPos.y);

            farBackground.position += new Vector3(amountToMove.x, amountToMove.y, 0f);
            middleBackground.position += new Vector3(amountToMove.x, amountToMove.y, 0f) * .5f;

            lastPos = transform.position;
        }
        
    }
}
