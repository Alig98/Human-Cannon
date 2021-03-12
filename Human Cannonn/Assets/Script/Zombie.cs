using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public bool canStart;
    public int currentHealth;
    public int maxHealth;
    private Animator myAnim;
    public healthBar healthbar1;

    void Start()
    {
        currentHealth = maxHealth;
        healthbar1.setMaxHealth(maxHealth);
        myAnim = GetComponent<Animator>();
        canStart = false;
    }

    void Update()
    {
        healthbar1.setHealth(currentHealth);
        if (canStart && currentHealth != 0 && !myAnim.GetCurrentAnimatorStateInfo(0).IsTag("animation"))
        {
            transform.position += transform.forward * 3f * Time.deltaTime;
        }
        if(currentHealth == 0)
        {
            myAnim.SetBool("dying", true);
        }
    }
}
