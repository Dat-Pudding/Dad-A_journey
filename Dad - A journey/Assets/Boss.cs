using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [Header("Boss Data")]
    public int health;
    public int phase2Health;
    public int maxHealth;
    public int shield;
    public float speed;
    public float fireRate;
    public string weakness;
    public GameObject phase1Instance;

    [Header("Boss Settings")]
    public string bossWeakness;

    public bool isMilkMan;
    public bool isMilkTruck;
    public bool isSewageWorker;
    public bool isSewageTruck;
    public bool isNeighbour;
    public bool isCashier;
    public bool isCashRegister;

    void Start()
    {
        weakness = bossWeakness;
        health = maxHealth;
        phase2Health = maxHealth + ((maxHealth / 2) * 1000) / 1000;
    }

    void Update()
    {

    }



}
