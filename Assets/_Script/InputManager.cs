using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance { get { return instance; } }

    [SerializeField] protected Vector3 moveDirection;
    public Vector3 MoveDirection { get { return moveDirection; } }

    public bool Jump { get; private set; } = false;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Update()
    {
        GetInput();
    }

    protected virtual void GetInput()
    {
        float horizontal = Input.GetAxis("Horizontal");

        moveDirection = new Vector3(horizontal, 0f, 0f).normalized;

        Jump = Input.GetKeyDown(KeyCode.Space);
    }

}
