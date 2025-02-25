using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private bool isGrounded = true;

    void Update()
    {
        if (InputManager.Instance != null)
        {
            MoveParent(InputManager.Instance.MoveDirection);
        }
        Jump();
    }

    private void MoveParent(Vector3 direction)
    {
        if (transform.parent == null)
        {
            Debug.LogWarning("No parent GameObject!");
            return;
        }
        float moveX = Mathf.Max(direction.x, 0f);

        Vector3 moveDirection = new Vector3(moveX, 0f, 0f);
        transform.parent.position += moveDirection * speed * Time.deltaTime;
    }

    private void Jump()
    {
        if (InputManager.Instance != null)
        {
            if (InputManager.Instance.Jump)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                isGrounded = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
