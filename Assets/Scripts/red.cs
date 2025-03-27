using UnityEngine;

public class red : MonoBehaviour
{
    float speed = 10f;

    void Update()/////////////////////////////////////////////////////////////////////////////////
    {
        move();
        border();
    }/////////////////////////////////////////////////////////////////////////////////////////////

    void border()
    {
        if (transform.position.x > 8.38)
        {
            transform.position = new Vector3(8.38f, transform.position.y, transform.position.z);
        }

        if (transform.position.x < -8.38)
        {
            transform.position = new Vector3(-8.38f, transform.position.y, transform.position.z);
        }
    }

    void move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime * -1);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime * 1);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}
