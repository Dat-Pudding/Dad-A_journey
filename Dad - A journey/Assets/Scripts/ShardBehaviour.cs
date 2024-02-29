using UnityEngine;

public class ShardBehaviour : MonoBehaviour
{
    public Inventory playerInv;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger)
        {
            ++playerInv.currentShards;
            Destroy(gameObject);
        }
    }
}
