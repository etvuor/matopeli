
using UnityEngine;

public class BossSaw : EnemyDamage
{
    [SerializeField] public float speed;
    [SerializeField] private float resetTime;
    [SerializeField] private Transform player;
    [SerializeField] private Transform boss;
   
    private float lifetime;
    public Animator anim;
    private BoxCollider2D coll;
    public bool sawAngry = false;
    private bool firstTime = true;
    public float direction;

    private bool hit;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
        
    }
    public void SetDireciton()
    {
    
        if (player.position.x < boss.position.x)

        {
            
            direction = 1f;
        }
        else
        {
            direction = -1f;
           
        }
       
    }
    public void ActivateProjectile()
    {
        Debug.Log("ActivateProjectile called for BossSaw: " + gameObject.name);
        
        hit = false;
        lifetime = 0;
        gameObject.SetActive(true);
        coll.enabled = true;
        // Set the scale based on the direction
        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != direction)
            localScaleX = -localScaleX;

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }
    private void Update()
    {
       
        if (sawAngry && firstTime)
        {
            anim.SetBool("Angry", true);
            firstTime = false;
        }
        if (hit) return;

        SetDireciton();
        float movementSpeed = speed * Time.deltaTime * direction; // Adjust speed based on direction
        transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > resetTime)
            gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectible"))
        {
            // If it's a collectible, do nothing and let it pass through
            return;
        }

        else if (collision.CompareTag("BasicAttack"))
        {
            // If it's a basic attack, destroy it
            collision.gameObject.SetActive(false);
        }

        else
        {
            hit = true;
            base.OnTriggerEnter2D(collision); //Execute logic from parent script first
            coll.enabled = false;


            gameObject.SetActive(false); //When this hits any object deactivate arrow
        }

        
    }

    
    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}