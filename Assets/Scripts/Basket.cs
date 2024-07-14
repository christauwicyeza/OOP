using UnityEngine;

public class Basket : MonoBehaviour
{
    public float speed = 10f;
    private float yPosition;

    void Start()
    {
        yPosition = transform.position.y;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Command.Execute(new Command.MoveLeftCommand(this));
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Command.Execute(new Command.MoveRightCommand(this));
        }
    }

    public void MoveLeft()
    {
        Vector3 newPosition = transform.position + Vector3.left * speed * Time.deltaTime;
        newPosition.y = yPosition;
        transform.position = newPosition;
    }

    public void MoveRight()
    {
        Vector3 newPosition = transform.position + Vector3.right * speed * Time.deltaTime;
        newPosition.y = yPosition;
        transform.position = newPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FallingObject"))
        {
            other.GetComponent<FallingObject>().StopFalling();
            other.transform.SetParent(transform);
            other.transform.localPosition = new Vector3(0, 0.5f, 0); // Adjust the y offset as needed
        }
    }
}
