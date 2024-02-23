using UnityEngine;
using UnityEngine.UI;

public class HotBarBehaviour : MonoBehaviour
{

    [Header("Hotbar Sprites")]
    public Image FirePotSprite;
    public Image WaterPotSprite;
    public Image AirPotSprite;
    public Image LightPotSprite;
    public Image EmptyPotSprite;

    [Header("Item Prefabs")]
    public GameObject FirePotPrefab;
    public GameObject WaterPotPrefab;
    public GameObject AirPotPrefab;
    public GameObject LightPotPrefab;
    public GameObject EmptyPotPrefab;

    [Header("Item Behaviours")]
    public PotBehaviour FirePotBehaviour;
    public PotBehaviour WaterPotBehaviour;
    public PotBehaviour AirPotBehaviour;
    public PotBehaviour LightPotBehaviour;
    public PotBehaviour EmptyPotBehaviour;

    [Header("Pot Action Scripts")]
    public FirePotAction firePotSkill;
    public WaterPotAction waterPotSkill;

    [Header("Spawn Location")]
    public Transform hand;

    int hotKeyHit;

    private void Start()
    {
        hotKeyHit = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            hotKeyHit = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            hotKeyHit = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            hotKeyHit = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            hotKeyHit = 4;
        }
        if(Input.GetKeyDown(KeyCode.Alpha5))
        {
            hotKeyHit = 5;
        }
    }

    private void FixedUpdate()
    {
        CheckIfAcquired();
        SelectCurrentPot();
    }

    void CheckIfAcquired()
    {
        if (FirePotBehaviour.potData.hasAcquired)
        {
            FirePotSprite.color = Color.white;
        }
        if (WaterPotBehaviour.potData.hasAcquired)
        {
            WaterPotSprite.color = Color.white;
        }
        if (AirPotBehaviour.potData.hasAcquired)
        {
            AirPotSprite.color = Color.white;
        }
        if (LightPotBehaviour.potData.hasAcquired)
        {
            LightPotSprite.color = Color.white;
        }
    }
    void SelectCurrentPot()
    {
        switch (hotKeyHit)
        {
            case 0:
                return;

            case 1:

                if (FirePotBehaviour.potData.hasAcquired)
                {
                    ActivateFirePot();
                }
                hotKeyHit = 0;
                return;

            case 2:
                // set currentPot to WaterPot
                if (WaterPotBehaviour.potData.hasAcquired)
                {
                    ActivateWaterPot();
                }
                hotKeyHit = 0;
                return;

            case 3:
                // set currentPot to AirPot
                if (AirPotBehaviour.potData.hasAcquired)
                {
                    ActivateAirPot();
                }
                hotKeyHit = 0;
                return;

            case 4:
                // set currentPot to LightPot
                if (LightPotBehaviour.potData.hasAcquired)
                {
                    ActivateLightPot();
                }
                hotKeyHit = 0;
                return;

            case 5:
                // set currentPot to CrackedPot/EmptyPot
                if (EmptyPotBehaviour.potData.hasAcquired)
                {
                    ActivateEmptyPot();
                }
                hotKeyHit = 0;
                return;
        }
    }

    void ActivateFirePot()
    {
        firePotSkill.enabled = true;
        waterPotSkill.enabled = false;

        FirePotPrefab.SetActive(true);
        WaterPotPrefab.SetActive(false);
        AirPotPrefab.SetActive(false);
        LightPotPrefab.SetActive(false);
        EmptyPotPrefab.SetActive(false);
    }
    void ActivateWaterPot()
    {
        firePotSkill.enabled = false;
        waterPotSkill.enabled = true;

        FirePotPrefab.SetActive(false);
        WaterPotPrefab.SetActive(true);
        AirPotPrefab.SetActive(false);
        LightPotPrefab.SetActive(false);
        EmptyPotPrefab.SetActive(false);
    }
    void ActivateAirPot()
    {
        firePotSkill.enabled = false;
        waterPotSkill.enabled = false;

        FirePotPrefab.SetActive(false);
        WaterPotPrefab.SetActive(false);
        AirPotPrefab.SetActive(true);
        LightPotPrefab.SetActive(false);
        EmptyPotPrefab.SetActive(false);
    }
    void ActivateLightPot()
    {
        firePotSkill.enabled = false;
        waterPotSkill.enabled = false;

        FirePotPrefab.SetActive(false);
        WaterPotPrefab.SetActive(false);
        AirPotPrefab.SetActive(false);
        LightPotPrefab.SetActive(true);
        EmptyPotPrefab.SetActive(false);
    }
    void ActivateEmptyPot()
    {
        firePotSkill.enabled = false;
        waterPotSkill.enabled = false;

        FirePotPrefab.SetActive(false);
        WaterPotPrefab.SetActive(false);
        AirPotPrefab.SetActive(false);
        LightPotPrefab.SetActive(false);
        EmptyPotPrefab.SetActive(true);
    }
}