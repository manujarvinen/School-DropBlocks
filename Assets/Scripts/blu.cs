using UnityEngine;

public class blu : MonoBehaviour
{
    float speed = 10f;
    public float smallerScale = 0.9f;
    public GameObject UIText;

    private GameObject lastTriggeredBlock = null; // Store last triggered block

    void Update()
    {
        move();
        border();
    }

    void move()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }

    void border()
    {
        if (transform.position.x > 8.38f)
        {
            transform.position = new Vector3(8.38f, transform.position.y, transform.position.z);
        }

        if (transform.position.x < -8.38f)
        {
            transform.position = new Vector3(-8.38f, transform.position.y, transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Block"))
        { 
            // Check if it's the same block triggering again
            if (other.gameObject == lastTriggeredBlock) return;

            // Store the new triggering block
            lastTriggeredBlock = other.gameObject;

            // Apply shrinking effect
            smallerScale -= 0.1f;
            transform.localScale = new Vector3(smallerScale, smallerScale, smallerScale);

            // If scale is too small, destroy object
            if (transform.localScale.x < 0.1f)
            {
                UIText.SetActive(false);
                Destroy(gameObject);
            }
        }
    }
}
