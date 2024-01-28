using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.SceneManagement;

public class BossMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    private BossTurn boss;
   
    private BossActivation activation;
    private BossRange bossRange;
    private Finish finishScript;
    private bool isActivated = false; // Flag to track if the boss is activated.
    private bool isAngry = false;
    private Health bossHealth;
    private FloatingHealthbar startingHealth;
    private Animator anim;
    [SerializeField] private GameObject[] saws;
    [SerializeField] private AudioClip newBackgroundMusic;
    [SerializeField] private AudioClip rageBoss;
    [SerializeField] private AudioClip BossDeath;
    [SerializeField] private GameObject finishGame;
    public float speed;

    private void Start()
    {
        
        bossRange = GetComponent<BossRange>();
        boss = GetComponent<BossTurn>(); // Get the BossTurn component on this GameObject
        activation = GetComponent<BossActivation>(); // Get the Bossactivation component on this GameObject
        bossHealth = GetComponent<Health>(); // Get the Health component on this GameObject
        startingHealth = GetComponentInChildren<FloatingHealthbar>(); // Get the FloatingHealthbar component on this GameObject
        anim = GetComponent<Animator>();
        finishScript = finishGame.GetComponent<Finish>();
        print(startingHealth.maxHealth);
        print(bossHealth.currentHealth);
        
        if (boss == null)
        {
            Debug.LogError("BossTurn component not found.");

            
        }

        if (bossHealth == null)
        {
            Debug.LogError("Health component not found.");
        }

        if (startingHealth == null)
        {
            Debug.LogError("FloatingHealthbar component not found.");
        }
    }


    private void Update()
    {
        if (isActivated)
        {
            
            Vector2 target = new Vector2(player.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
            boss.LookAtPlayer(); // Call the LookAtPlayer method from the BossTurn script
           
            if (!isAngry && bossHealth.currentHealth <= 0.5 * startingHealth.maxHealth)
            {
                DeactivateSaws();
                SetAnryState();
            }
            

        }
    }

    private void SetAnryState()
    {

        SoundManager.instance.PlaySound(rageBoss);
        isAngry = true;
        activation.stopBoss();
        MusicManager.instance.PlayBackgroundMusic(newBackgroundMusic);
        anim.SetTrigger("angry");
        Debug.Log("the boss is now angry");
        bossRange.attackCooldown = 4f;
        speed = 2f;
        foreach (GameObject saw in saws)
        {
            // Check if the GameObject has the BossSaw component
            BossSaw bossSaw = saw.GetComponent<BossSaw>();

            if (bossSaw != null)
            {
                bossSaw.speed = 4f; // Modify the speed of each BossSaw
                bossSaw.sawAngry = true;
                // Access the Animator component of the BossSaw
                
                
            }
        }




        activation.startBoss(2);
       
    }
    // Public method to activate the boss.
    public void ActivateBoss()
    {

        isActivated = true;
    }
    private void DeactivateSaws()
    {
        foreach (GameObject saw in saws)
        {
            // Check if the GameObject has the BossSaw component
            BossSaw bossSaw = saw.GetComponent<BossSaw>();
            if (bossSaw != null && bossSaw.gameObject.activeSelf)
            {
                bossSaw.gameObject.SetActive(false);
            }
        }
    }

    private void DeactivateBoss()
    {
        finishGame.SetActive(true);
        finishScript.waitTime = 5;

        MusicManager.instance.stopMusic();
       
        gameObject.SetActive(false);
    }
}
