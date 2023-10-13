using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    [SerializeField] private Transform playerSpawnPoint;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")) // Assurez-vous que votre joueur a le tag "Player"
        {
            // Téléporte le joueur à son point de spawn
            other.transform.position = playerSpawnPoint.position;
        }
    }
}
