using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  public Rigidbody player;
    public float bounceAmount = 10f;

    public Transform deathParticles;
    public AudioSource deathSound;

    public Transform colliders;
    public Animator enemyAnim;
    private Animator centerAnim;

    void Awake()
    {
        centerAnim = GetComponent<Animator>();
    }

    public void Die()
    {
        player.velocity = new Vector3(player.velocity.x, bounceAmount, player.velocity.z);
        Instantiate(deathParticles, enemyAnim.transform.position, enemyAnim.transform.rotation);
        
        enemyAnim.SetTrigger("Die");
        centerAnim.SetTrigger("Stop");
        Destroy(colliders.gameObject);
        // Destroy(gameObject);
    }
}
