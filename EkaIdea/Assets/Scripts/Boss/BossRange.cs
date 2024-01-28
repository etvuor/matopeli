using UnityEngine;

public class BossRange : MonoBehaviour
{
    [Header("Attack Parameters")]
    [SerializeField] public float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;

    [Header("Ranged Attack")]
    [SerializeField] private Transform firepoint;
    [SerializeField] public GameObject[] fireballs;

    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    [Header("Fireball Sound")]
    [SerializeField] private AudioClip fireballSound;

    //References
    private Animator anim;
    private bool isActivated = false; // Flag to track if the boss is activated.


    private void Awake()
    {
        anim = GetComponent<Animator>();
        
    }

    private void Update()
    {
        if (!isActivated)
        {
            return; // Don't perform RangeAttack if not activated
        }
        cooldownTimer += Time.deltaTime;

        //Attack only when player in sight?
        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                anim.SetTrigger("RangeAttack");
            }
        }

           }

    private void RangedAttack()
    {
        SoundManager.instance.PlaySound(fireballSound);
        cooldownTimer = 0;
        for (int i = 0; i < 3; i++)
        {
            GameObject fireball = fireballs[FindFireball()];
            Vector3 spawnPosition = firepoint.position + Vector3.up * (i * 2); // Adjust the vertical offset as needed.
            fireball.transform.position = spawnPosition;
            fireball.GetComponent<BossSaw>().ActivateProjectile();
        }
    }
    private int FindFireball()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
                return i;
        }
        return 0;
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit =
            Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        return hit.collider != null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }
    public void ActivateBoss()
    {
        isActivated = true;
    }
}
