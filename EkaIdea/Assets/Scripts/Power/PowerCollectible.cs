using UnityEngine;

public class PowerCollectible : MonoBehaviour
{
    [SerializeField] private float PowerValue;
    [SerializeField] private AudioClip pickupSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SoundManager.instance.PlaySound(pickupSound);
            collision.GetComponent<Power>().AddPower(PowerValue);
            gameObject.SetActive(false);
        }
    }
}