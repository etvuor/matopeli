using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActivation : MonoBehaviour
{
    private Health nodamage;

    private void Start()
    {
        nodamage = GetComponent<Health>();
    }
    public void stopBoss()
    {
        GetComponent<BossMovement>().enabled = false;
        GetComponent<BossRange>().enabled = false;
        GetComponent<BossMelee>().enabled = false;
    }

    public void startBoss(float delay)
    {
        
        nodamage.invulnerable = true;
        Physics2D.IgnoreLayerCollision(10, 11, true);
        StartCoroutine(StartBossCoroutine(delay));
       
    }

    private IEnumerator StartBossCoroutine(float delay)
    {   

        yield return new WaitForSeconds(delay);

        // Activate the boss and its components
        GetComponent<BossMovement>().enabled = true;
        GetComponent<BossRange>().enabled = true;
        GetComponent<BossMelee>().enabled = true;
        
        Physics2D.IgnoreLayerCollision(10, 11, false);
        nodamage.invulnerable = false;

    }
}
