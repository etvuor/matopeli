using UnityEngine;

public class EnemyProjectile : EnemyDamage
{
    [SerializeField] private float speed;
    [SerializeField] private float resetTime;
    private float lifetime;
    private Animator anim;
    private BoxCollider2D coll;

    private bool hit;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }

    public void ActivateProjectile()
    {
        hit = false;
        lifetime = 0;
        gameObject.SetActive(true);
        coll.enabled = true;
    }
    private void Update()
    {
        if (hit) return;
        float movementSpeed = speed * Time.deltaTime;
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

        hit = true;
        base.OnTriggerEnter2D(collision); // Execute logic from the parent script first
        coll.enabled = false;

        if (anim != null)
        {
            anim.SetTrigger("explode"); // When the object is an enemy, explode it
        }
        else
        {
            gameObject.SetActive(false); // When this hits any object other than collectibles, deactivate the arrow
        }
    }
    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}