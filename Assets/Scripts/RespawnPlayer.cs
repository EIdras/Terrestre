using Cinemachine;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    [SerializeField] public Transform playerSpawnPoint;

    [Header("Camera")]
    [SerializeField] public Transform spawnAreaCamera;
    public CinemachineVirtualCamera virtualCamera;
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            // Téléporte le joueur à son point de spawn
            Debug.Log("Player has fallen");
            other.transform.position = playerSpawnPoint.position;
            virtualCamera.Follow = spawnAreaCamera;
        }
    }
}
