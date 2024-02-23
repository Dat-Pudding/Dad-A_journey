using UnityEngine;

public class FirePotAction : MonoBehaviour
{
    [Header("Player References")]
    public PlayerAim aimScript;
    public Transform hand;
    public HotBarBehaviour hotBarScript;
    public PlayerItemUsing playerUseScript;
    public GameObject projectilePrefab;

    [Header("Fire Pot Stats")]
    public float fireRatePerMinute = 30;
    public float coolDownInSeconds;
    public float coolDownTimeStamp;
    public int damage = 20;
    public bool canCast;

    void Start()
    {
        canCast = true;
        coolDownInSeconds = (1 / (fireRatePerMinute / 60f)) * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > coolDownTimeStamp)
        {
            canCast = true;
            coolDownTimeStamp = Time.time + coolDownInSeconds;
        }
        if (Input.GetMouseButton(0) && canCast)
        {
            CastFire();
        }
    }

    void CastFire()
    {
        Instantiate(projectilePrefab, hand.position, hand.rotation);
        canCast = false;
    }
}
