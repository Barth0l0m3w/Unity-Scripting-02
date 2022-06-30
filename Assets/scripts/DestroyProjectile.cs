using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProjectile : MonoBehaviour
{
    public float timer = 3f;

    void Update()
    {
        //destroy the projectiles when time runs out
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Destroy(this.gameObject);
        }
    }

    //or destroy the projectile after it hits anything
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
