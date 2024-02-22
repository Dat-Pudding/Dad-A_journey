using System.Collections;
using System.Collections.Generic;
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
                // set currentPot to FirePot
                Debug.Log("FirePot equipped");
                hotKeyHit = 0;
                return;

            case 2:
                // set currentPot to WaterPot
                return;

            case 3:
                // set currentPot to AirPot
                return;

            case 4:
                // set currentPot to LightPot
                return;

            case 5:
                // set currentPot to CrackedPot/EmptyPot
                return;
        }
    }
}