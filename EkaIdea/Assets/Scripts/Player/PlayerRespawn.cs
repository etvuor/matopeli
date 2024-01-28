using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private UIManagement uiManagement;


    private void Awake()
    {
        uiManagement = FindObjectOfType<UIManagement>();
    }

    public void Respawn()
    {
    
        uiManagement.GameOver();
        return;
    }
}
