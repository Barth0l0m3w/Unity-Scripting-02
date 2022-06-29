using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 3;
    public int CurrentHealth;

    public HealthBar healthBar;

    void Start()
    {
        CurrentHealth = maxHealth;
        healthBar.MaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("auch");
            TakeDamage(1);
        }
    }

    private void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        healthBar.SetHealth(CurrentHealth);
    }
}
