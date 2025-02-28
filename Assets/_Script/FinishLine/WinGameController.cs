using UnityEngine;

public class WinGameController : MonoBehaviour
{
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (WinManager.Instance != null)
            WinManager.Instance.CheckWinCondition();
    }
}
