using Cinemachine;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    [SerializeField] public Transform playerSpawnPoint;
    [SerializeField] public GameObject player;
    [SerializeField] public float deathY = -10f;

    [Header("Camera")]
    [SerializeField] public Transform spawnAreaCamera;
    public CinemachineVirtualCamera virtualCamera;
    
    void Update()
    {
        if(player.transform.position.y < deathY)
        {
            RespawnPlayerToSpawnPoint();
        }
    }
          
    void RespawnPlayerToSpawnPoint()
    {
        player.transform.position = playerSpawnPoint.position;
        virtualCamera.Follow = spawnAreaCamera;
    }

}
