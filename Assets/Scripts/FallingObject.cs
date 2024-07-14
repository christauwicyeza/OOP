using UnityEngine;

public class FallingObject : MonoBehaviour
{
    public float fallingSpeed = 5f;
    private bool isFalling = true;

    void Update()
    {
        if (isFalling)
        {
            transform.position += Vector3.down * fallingSpeed * Time.deltaTime;
        }
    }

    public void StopFalling()
    {
        isFalling = false;
    }

    public void Fall()
    {
        isFalling = true;
    }
}
