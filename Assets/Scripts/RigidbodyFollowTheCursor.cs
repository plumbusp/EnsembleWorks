using UnityEngine;

public class RigidbodyFollowTheCursor : MonoBehaviour
{
    [SerializeField] private float _maxSpeed;
    private Rigidbody2D rb;
    private bool isDragging = false;
    private Vector3 offset;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnMouseDown()
    {
        isDragging = true;
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    void FixedUpdate()
    {
        if (isDragging)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)) + offset;
            if(rb.linearVelocity.x > _maxSpeed)
            {
                rb.linearVelocity = new Vector2(_maxSpeed, rb.linearVelocity.y);
            }
            if (rb.linearVelocity.y > _maxSpeed)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, _maxSpeed);
            }
            rb.MovePosition(newPosition);
        }
    }
}
