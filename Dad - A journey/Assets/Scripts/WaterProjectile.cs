using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterProjectile : MonoBehaviour
{
    [Header("Pot Specifiers")]
    public Sprite projectileSprite;
    public ParticleSystem particles;
    public Light inherentGlow;
    public AudioSource sound;
    public WaterPotAction PotAction;

    [Header("Projectile Stats")]
    public float projectileSpeed;
    public float projectileLifetime;
    public float projectileDamage;

    Rigidbody2D projectileRB;

    void Start()
    {
        PotAction = FindAnyObjectByType<WaterPotAction>();
        projectileRB = this.GetComponent<Rigidbody2D>();
        projectileDamage = PotAction.damage;
        Vector2 impulseVector = transform.up * projectileSpeed;
        projectileRB.AddForce(impulseVector, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            Destroy(gameObject, projectileLifetime);
        }
    }
}
