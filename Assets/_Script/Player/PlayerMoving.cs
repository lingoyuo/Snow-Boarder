using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    [SerializeField] float torqueAmount = 100f;
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

    public TextMeshProUGUI pointPerRotationText;

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

    // down để giảm tốc

    private void RespondToBoost()
    {
        if (surfaceEffector2D != null)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                surfaceEffector2D.speed = boostSpeed; // Tăng tốc
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                surfaceEffector2D.speed = baseSpeed / 2; // Giảm tốc độ xuống 50%
            }
            else
            {
                surfaceEffector2D.speed = baseSpeed; // Tốc độ bình thường
            }
        }
    }


    void RotateParent()
    {
        float currentTorque = torqueAmount / (1 + Mathf.Abs(parentRb.angularVelocity) * 0.1f); 

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            parentRb.AddTorque(currentTorque);
            TrackRotation();
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            parentRb.AddTorque(-currentTorque);
            TrackRotation();
        }
    }



    //đặt giới hạn chỉ cộng điểm khi đang ở trên không.
    //Chỉ tính điểm khi isGrounded == false, tránh lạm dụng cộng điểm khi tiếp đất.
    void TrackRotation()
    {
        if (!isGrounded) // Chỉ tính điểm khi ở trên không
        {
            accumulatedRotation += parentRb.angularVelocity * Time.deltaTime;

            if (Mathf.Abs(accumulatedRotation) >= 180f)
            {
                rotationCount += Mathf.FloorToInt(Mathf.Abs(accumulatedRotation) / 180f);
                accumulatedRotation %= 180f;
                StartCoroutine(ShowAndHidePointText("+" + pointPerRotation));
                playerPointReceive.AddPoint(pointPerRotation);
            }
        }
    }


    IEnumerator ShowAndHidePointText(string pointText)
    {
        pointPerRotationText.text = pointText;
        yield return new WaitForSeconds(1f);
        pointPerRotationText.text = "";
    }


    void HandleJump()
    {
        if (isGrounded && Input.GetKey(KeyCode.Space))
        {
            jumpHoldTime += Time.deltaTime * jumpChargeRate;
            jumpHoldTime = Mathf.Clamp(jumpHoldTime, jumpForce, maxJumpForce);
        }

        if (isGrounded && Input.GetKeyUp(KeyCode.Space))
        {
            parentRb.linearVelocity = new Vector2(parentRb.linearVelocity.x, jumpHoldTime);
            isGrounded = false;
            jumpHoldTime = jumpForce;
        }
    }

    /*
     Khi va vào chướng ngại vật (Obstacle), tốc độ bị giảm đi 50%.
Hiển thị điểm -10 trên màn hình.
Trừ điểm người chơi.

     */

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            rotationCount = 0;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Va chạm với chướng ngại vật! Bị đẩy ra sau.");

            // Giảm tốc độ + đẩy ngược về phía sau
            float knockbackForce = -5f; // Lực đẩy ngược về sau
            float upwardForce = 2f; // Lực đẩy nhẹ lên trên

            parentRb.linearVelocity = new Vector2(knockbackForce, upwardForce);

            // Hiển thị -10 điểm
            StartCoroutine(ShowAndHidePointText("-10"));
            playerPointReceive.AddPoint(-10);
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
