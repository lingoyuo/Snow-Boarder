using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    [SerializeField] float torqueAmount = 30f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float baseSpeed = 20f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] float maxJumpForce = 20f; 
    [SerializeField] float jumpChargeRate = 10f;
    private Rigidbody2D parentRb; 
    private SurfaceEffector2D surfaceEffector2D;
    private bool canMove = true;
    private bool isGrounded = true;
    private float jumpHoldTime = 0f;

    private int rotationCount = 0; 
    public PLayerPointReceive playerPointReceive; 
    public int pointPerRotation = 10;
    private float accumulatedRotation = 0f;

    void Start()
    {
        if (transform.parent != null)
        {
            parentRb = transform.parent.GetComponent<Rigidbody2D>();
        }

        surfaceEffector2D = FindAnyObjectByType<SurfaceEffector2D>();
        playerPointReceive = FindAnyObjectByType<PLayerPointReceive>();
    }

    void Update()
    {
        if (canMove && parentRb != null)
        {
            RotateParent();
            RespondToBoost();
            HandleJump();
        }
    }

    public void DisableControls()
    {
        canMove = false;
    }

    private void RespondToBoost()
    {
        if (surfaceEffector2D != null)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                surfaceEffector2D.speed = boostSpeed;
            }
            else
            {
                surfaceEffector2D.speed = baseSpeed;
            }
        }
    }

    void RotateParent()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            parentRb.AddTorque(torqueAmount);
            TrackRotation();
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            parentRb.AddTorque(-torqueAmount);
            TrackRotation();
        }
    }

    void TrackRotation()
    {
        accumulatedRotation += parentRb.angularVelocity * Time.deltaTime;

        // Kiểm tra vòng quay
        if (Mathf.Abs(accumulatedRotation) >= 360f)
        {
            rotationCount += Mathf.FloorToInt(Mathf.Abs(accumulatedRotation) / 360f);
            accumulatedRotation %= 360f; // Giữ góc xoay trong phạm vi 360 độ
            playerPointReceive.AddPoint(pointPerRotation); // Cộng điểm
        }
    }

    void HandleJump()
    {
        if (isGrounded)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                // Giữ Space để tăng lực nhảy
                jumpHoldTime += Time.deltaTime * jumpChargeRate;
                jumpHoldTime = Mathf.Clamp(jumpHoldTime, jumpForce, maxJumpForce);
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                // Khi thả Space thì nhảy với lực đã nạp
                parentRb.linearVelocity = new Vector2(parentRb.linearVelocity.x, jumpHoldTime);
                isGrounded = false;
                jumpHoldTime = jumpForce; // Reset lực nhảy về giá trị tối thiểu
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            rotationCount = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
