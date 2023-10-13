using Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraTransitionZone : MonoBehaviour
{
    public bool flipVertical;
    public bool flipHorizontal;
    
    [Header("Camera")] 
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
            float playerX = playerTransform.position.x;
            float playerY = playerTransform.position.y;
            
            Vector2 movePos = new Vector2(playerX + (flipVertical ? 0 : movementGap), playerY + (flipVertical ? movementGap : 0));
            Vector2 moveNeg= new Vector2(playerX - (flipVertical ? 0 : movementGap), playerY - (flipVertical ? movementGap : 0));
            
            if (virtualCamera.Follow == cameraTarget1)
            {
                virtualCamera.Follow = cameraTarget2;
                
                // Déplacez le joueur légèrement vers la droite (ou la direction que vous préférez)
                playerTransform.position = flipHorizontal ? moveNeg : movePos;
            }
            else
            {
                virtualCamera.Follow = cameraTarget1;
            
                // Déplacez le joueur légèrement vers la gauche (ou la direction que vous préférez)
                playerTransform.position = flipHorizontal ? movePos : moveNeg;
            }
        
            // Si vous voulez vous assurer que le joueur ne se déplace pas de manière inattendue en raison de sa vélocité, réinitialisez la vélocité
            playerRb.velocity = Vector2.zero;
        }
    }
}