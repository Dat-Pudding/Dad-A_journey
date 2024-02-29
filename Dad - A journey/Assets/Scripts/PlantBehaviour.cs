using System.Collections;
using UnityEngine;

public class PlantBehaviour : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public bool isBurning;
    public int burnDamage;
    public Color normal = Color.white;
    public Color burning = Color.red;

    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        if (health <= 0)
        {
            health = 0;
            Destroy(gameObject);
        }
        if (isBurning)
        {
            StartCoroutine(BurnTimer());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Fire"))
        {
            isBurning = true;
        }
    }

    public IEnumerator BurnTimer()
    {
        float timer = 1f;
        yield return new WaitForSeconds(timer);
        health -= burnDamage;
        this.GetComponent <SpriteRenderer>().material.color = burning;
        yield return new WaitForSeconds(timer);
        this.GetComponent<SpriteRenderer>().material.color = normal;
        yield return new WaitForSeconds(timer);
    }
}