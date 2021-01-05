using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting_Star : MonoBehaviour
{
    public GameObject Projectile;
    public ParticleSystem projectileParticle;
    private float timer;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 6 && Projectile.activeSelf == false)
        {
            Projectile.SetActive(true);
            timer = 0;
        }
        if (projectileParticle.IsAlive() == false)
            Projectile.SetActive(false);
    }
}
