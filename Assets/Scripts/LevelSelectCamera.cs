using UnityEngine;

public class LevelSelectCamera : MonoBehaviour
{
    public Vector2 minPos, maxPos;
    public Transform target;
    void Start()
    {
        
    }

    void LateUpdate()
    {
        float xPos = Mathf.Clamp(target.position.x, minPos.x, maxPos.x);
        float yPos = Mathf.Clamp(target.position.y, minPos.y, maxPos.y);
        transform.position = new Vector3(xPos, yPos, transform.position.z);
    }
}
