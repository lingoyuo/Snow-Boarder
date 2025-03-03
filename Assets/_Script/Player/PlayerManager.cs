using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Animator animator;
    private static PlayerManager instance;
    public static PlayerManager Instance { get { return instance; } }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()      
    {
        
    }
}
