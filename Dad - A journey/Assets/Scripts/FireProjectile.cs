using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    [Header("Pot Specifiers")]
    public Sprite projectileSprite;
    public ParticleSystem particles;
    public Light inherentGlow;
    public AudioSource sound;
    public FirePotAction PotAction;

    [Header("Projectile Stats")]
    public float projectileSpeed;
    public float projetileFriction;
    public float projectileLifetime;
    public float projectileDamage;

    Rigidbody2D projectileRB;

    void Start()
    {
        PotAction = FindAnyObjectByType<FirePotAction>();
        projectileRB = this.GetComponent<Rigidbody2D>();

        projectileDamage = PotAction.damage;
        Vector2 impulseVector = transform.up * projectileSpeed;
        projectileRB.AddForce(impulseVector, ForceMode2D.Impulse);
    }

    void Update()
    {
        Destroy(gameObject, projectileLifetime * 2);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            Destroy(gameObject, projectileLifetime);
        }
        if (collision == null)
        {
            Destroy(gameObject, projectileLifetime * 1.5f);
        }
    }
}
