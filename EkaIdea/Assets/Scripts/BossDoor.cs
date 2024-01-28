using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BossDoor : MonoBehaviour
{
    public GameObject wallObject;
    public Animator wallAnimator;
    public Animator bossAnimator;
    public Collider2D triggerZone;
    public GameObject bossObject; // Reference to your boss GameObject
    public GameObject player;
    public GameObject spawner;
    private bool hasActivated = false;
    [SerializeField] private AudioClip newBackgroundMusic;

    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (!hasActivated && other.CompareTag("Player"))
        {
            // Activate the wall and play the animation
            wallObject.SetActive(true);
            spawner.SetActive(true);
            hasActivated = true;
            MusicManager.instance.PlayBackgroundMusic(newBackgroundMusic);

            player.GetComponent<PlayerAttack>().enabled = false;
            player.GetComponent<PlayerMovement>().enabled = false;

            // Optionally, deactivate the trigger zone
            triggerZone.enabled = false;
            bossObject.SetActive(true);
            bossAnimator.SetTrigger("intro");
            StartCoroutine(ActivatePlayerAfterDelay(1.8f));
            StartCoroutine(ActivateBossAfterDelay(2.0f));

        }
    }

    private IEnumerator ActivateBossAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Activate the boss and its components

        bossObject.GetComponent<BossMovement>().ActivateBoss();
        bossObject.GetComponent<BossRange>().ActivateBoss();
       
    }

    private IEnumerator ActivatePlayerAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        player.GetComponent<PlayerAttack>().enabled = true;
        player.GetComponent<PlayerMovement>().enabled = true;

    }
}