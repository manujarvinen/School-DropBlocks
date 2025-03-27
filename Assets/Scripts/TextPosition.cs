using UnityEngine;

public class TextPosition : MonoBehaviour
{
    public Transform ballPosition;
    public float lerpSpeed = 5f; // Adjust for smoothness

    void Update()
    {
        if (ballPosition != null)
        {
            // Smoothly Lerp only the X position, keeping Y unchanged
            float targetX = ballPosition.position.x;
            transform.position = new Vector2(Mathf.Lerp(transform.position.x, targetX, Time.deltaTime * lerpSpeed), transform.position.y);
        }
    }
}
