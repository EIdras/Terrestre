using Cinemachine;
using UnityEngine;

public class CameraTransitionZone : MonoBehaviour
{
    [Header("Camera")] 
    public bool isVertical;
    public Transform cameraTarget1;
    public Transform cameraTarget2;
    public CinemachineVirtualCamera virtualCamera;
    
    [Header("Player")]
    public Transform playerTransform;
    public Rigidbody2D playerRb;
    public float movementGap = 1.5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (virtualCamera.Follow == cameraTarget1)
            {
                virtualCamera.Follow = cameraTarget2;
            
                // Déplacez le joueur légèrement vers la droite (ou la direction que vous préférez)
                playerTransform.position = new Vector2(playerTransform.position.x + (isVertical ? 0 : movementGap), playerTransform.position.y + (isVertical ? movementGap : 0));
            }
            else
            {
                virtualCamera.Follow = cameraTarget1;
            
                // Déplacez le joueur légèrement vers la gauche (ou la direction que vous préférez)
                playerTransform.position = new Vector2(playerTransform.position.x - (isVertical ? 0 : movementGap), playerTransform.position.y - (isVertical ? movementGap : 0));
            }
        
            // Si vous voulez vous assurer que le joueur ne se déplace pas de manière inattendue en raison de sa vélocité, réinitialisez la vélocité
            playerRb.velocity = Vector2.zero;
        }
    }
}