using UnityEngine;

public class StoneHead : EnemyDamage
{
    private Health playerHealth;
    [SerializeField] private GameObject player;

    [Header("StoneHead Attributes")]
    [SerializeField] private float speed;
    [SerializeField] private float range;
    [SerializeField] private float checkDelay;
    [SerializeField] private LayerMask playerLayer;
    private Vector3[] directions = new Vector3[4];
    private Vector3 destination;
    private float checkTimer;
    private bool attacking;
    public bool isActive = false;
    private bool hasSkippedCheckDelay = false;
  

    [Header("NOICE")]
    [SerializeField] private AudioClip noice;

    private void OnEnable()
    {
        Stop();
        playerHealth = player.GetComponent<Health>();
    }

    private void Update()
    {

        if (isActive && playerHealth.currentHealth != 0)
        {
           
            // Move spikehead to destination only if attacking
            

                if (attacking)
                    transform.Translate(destination * Time.deltaTime * speed);
                else
                {
                    checkTimer += Time.deltaTime;

                    if (!hasSkippedCheckDelay){
                        checkTimer = 99f;
                        hasSkippedCheckDelay= true;
                    }

                    if (checkTimer > checkDelay)
                        CheckForPlayer();
                
            }

        }
        else
        {
            Stop();
            hasSkippedCheckDelay = false;
        }
    }

    private void CheckForPlayer()
    {
        if (isActive)
        {
            
            
            CalculateDirections();

            // Check if spikehead sees player in all 4 directions
            for (int i = 0; i < directions.Length; i++)
            {
                Debug.DrawRay(transform.position, directions[i], Color.red);
                RaycastHit2D hit = Physics2D.Raycast(transform.position, directions[i], range, playerLayer);

                if (hit.collider != null && !attacking)
                {
                    attacking = true;
                    destination = directions[i];
                    checkTimer = 0;
                }
            }
            
        }
    }

    
    private void CalculateDirections()
    {
        directions[0] = transform.right * range; // Right direction
        directions[1] = -transform.right * range; // Left direction
        directions[2] = transform.up * range; // Up direction
        directions[3] = -transform.up * range; // Down direction
    }

    private void Stop()
    {
        destination = transform.position; // Set destination as current position so it doesn't move
        attacking = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isActive)
        {
            SoundManager.instance.PlaySound(noice);
            base.OnTriggerEnter2D(collision);
            Stop(); // Stop spikehead once it hits something
        }
    }
}
