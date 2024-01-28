using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioClip finishSound;
    [SerializeField] GameObject player;
    public int waitTime = 5;
    private PlayerMovement playerMovement;
    private UIManagement uiManagement;


    


    private void Start()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
        uiManagement = FindObjectOfType<UIManagement>();
    }

    private bool levelCompleted = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && levelCompleted == false)
        {
            playerMovement.enabled = false;
            SoundManager.instance.PlaySound(finishSound);
            levelCompleted = true;

            Invoke("ProgressionInvoker", 1);
            Invoke("CompleteLevel", waitTime);
            
        }
    }
    
    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void ProgressionInvoker()
    {
        uiManagement.Progression();
    }

}
