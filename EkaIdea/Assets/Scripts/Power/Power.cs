using UnityEngine;

public class Power : MonoBehaviour
{
    [Header("Power")]
    [SerializeField] private float startingPower;
    [SerializeField] private Transform firePoint;
    [SerializeField] private AudioClip firestormSound;
    public float currentPower { get; private set; }
    private Animator anim;
    private PlayerMovement playerMovement;
    public GameObject firestormPrefab; // Reference to the Firestorm prefab

    // Define a variable for damage
    private int specialAttackDamage = 0;

    private void Awake()
    {
        currentPower = startingPower;
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(1) && playerMovement.canAttack())
        {
            Sattack();
        }
    }

    private void Sattack()
    {
        int crystalsCollected = (int)currentPower;

        switch (crystalsCollected)
        {
            case 3:
                anim.SetTrigger("SpecialAttack3");
                SoundManager.instance.PlaySound(firestormSound);
                // Perform special attack for three crystals
                specialAttackDamage = 8;// Set damage for three crystals
                LaunchFirestorm(specialAttackDamage);
                break;
            case 2:
                anim.SetTrigger("SpecialAttack2");
                SoundManager.instance.PlaySound(firestormSound);
                // Perform special attack for two crystals
                specialAttackDamage = 5; // Set damage for two crystals
                LaunchFirestorm(specialAttackDamage);
                break;
            case 1:
                anim.SetTrigger("SpecialAttack1");
                SoundManager.instance.PlaySound(firestormSound);
                // Perform special attack for one crystal
                specialAttackDamage = 2; // Set damage for one crystal
                LaunchFirestorm(specialAttackDamage);
                break;
            default:
                // Handle cases where no crystals or an unexpected number of crystals are collected
                specialAttackDamage = 0; // Set damage to 0 for other cases
                break;
        }

        // Reset currentPowerValue regardless of the number of crystals collected
        currentPower = 0f;
    }

    public void AddPower(float _value)
    {
        currentPower = Mathf.Clamp(currentPower + _value, 0, 3);
    }

    private void LaunchFirestorm(int damage)
    {
        // Instantiate the Firestorm prefab at the player's position
        GameObject firestorm = Instantiate(firestormPrefab, firePoint.position, Quaternion.identity);

        // Set the direction of the Firestorm based on the player's facing direction
        float playerDirection = Mathf.Sign(transform.localScale.x);
        firestorm.GetComponent<Projectile>().SetDirection(playerDirection);
        firestorm.GetComponent<Projectile>().damage = damage; // Set the damage for the Firestorm
    }
}
