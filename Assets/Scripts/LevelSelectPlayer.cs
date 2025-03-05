using UnityEngine;

public class LevelSelectPlayer : MonoBehaviour
{
    public MapPoint currentPoint;

    public float moveSpeed = 10f;

    private bool levelLoading;

    public LevelSelectManager manager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentPoint.transform.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, currentPoint.transform.position) < .1f && !levelLoading)
        {

        if (Input.GetAxisRaw("Horizontal") > .5f)
        {
            if (currentPoint.right != null)
            {
                SetNextPoint(currentPoint.right);
            }
        }

        if (Input.GetAxisRaw("Horizontal") < -.5f)
        {
            if (currentPoint.left != null)
            {
                SetNextPoint(currentPoint.left);
            }
        }

        if (Input.GetAxisRaw("Vertical") > .5f)
        {
            if (currentPoint.up != null)
            {
                SetNextPoint(currentPoint.up);
            }
        }

        if (Input.GetAxisRaw("Vertical") < -.5f)
        {
            if (currentPoint.down != null)
            {
                SetNextPoint(currentPoint.down);
            }
        }

        if (currentPoint.isLevel && currentPoint.levelToLoad != "")
            {
                if (Input.GetButtonDown("Jump"))
                {
                    levelLoading = true;

                    manager.LoadLevel();
                }
            }
        }
    }

    public void SetNextPoint(MapPoint nextPoint)
    {
        currentPoint = nextPoint;
    }
}
