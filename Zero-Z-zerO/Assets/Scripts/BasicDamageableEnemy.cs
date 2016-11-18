using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BasicDamageableEnemy : MonoBehaviour, IDamageable, IProjectileOwner
{
    public float hitpoints;
    public GameObject gold;

    // public Animator enemyDestroy;  // animaatiot starttiin ja getcomponent.. etc..
    public List<GameObject> projectiles;

    public void ReceiveHit(float damage)
    {
        hitpoints -= damage;

        if (hitpoints <= 0)
        {
            //Debug.LogError("Popcorn Kamikaza Enemy is destroyed.");
            //enemyDestroy.Play("PopcornKamikazeDestroyAnim");

            //Debug.LogError("Enemy Destroyed.. Generate Diamonds..");

            // if kakuseimode generate diamonds from enemy projectiles.
            GenerateGold();

            Destroy(gameObject, 0.0f);
            // Let's see how many times Unity will crash when I try to add the animation this time...
        }
    }

  public void RegisterProjectile(GameObject projectile)
    {
        projectiles.Add(projectile);  // adds enemy projectiles to list

    }


    // Generate diamonds from Projetile register.
public void GenerateGold()
    {
        foreach (GameObject projectile in projectiles)
        {
            if (projectile!=null)
            {
                Debug.Log("projetile is not nul..");
                GameObject dmd = Instantiate(gold);
                dmd.transform.position = projectile.transform.position;
                Destroy(projectile);
            }

            //Debug.Log("Generate Dmnds....");
            

            //otherD.position = transform.position + transform.forward;
            //otherD.rotation = transform.rotation;


        }
    }




}
