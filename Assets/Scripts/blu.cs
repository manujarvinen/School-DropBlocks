using UnityEngine;

public class blu : MonoBehaviour
{
    float speed = 10f;

    void Update()/////////////////////////////////////////////////////////////////////////////////
    {
        move();
        border();
    }/////////////////////////////////////////////////////////////////////////////////////////////

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
        if (transform.position.x > 8.38)
        {
            transform.position = new Vector3(8.38f, transform.position.y, transform.position.z);
        }

        if (transform.position.x < -8.38)
        {
            transform.position = new Vector3(-8.38f, transform.position.y, transform.position.z);
        }
    }
}
