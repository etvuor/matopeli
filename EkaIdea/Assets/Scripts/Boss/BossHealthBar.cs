using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{

    public int health;
    public int damage;
  


 
    public Slider healthBar;
  

    private void Update()
    {

        healthBar.value = health;
    }

   
}