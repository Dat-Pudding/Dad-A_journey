using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkManBehaviour : MonoBehaviour
{
    [Header("References")]
    public Boss bossScript;
    public Transform MilkManShoulder;
    public Transform MilkTruckFrontRay;
    public Transform MilkTruckBackRay;

    void Start()
    {

    }

    void Update()
    {
        if (bossScript.isMilkTruck)
        {
            MilkManPhase1();
            return;
        }

        if (bossScript.isMilkMan)
        {
            MilkManPhase2();
            return;
        }
    }

    public void MilkManPhase1()
    {
        if (bossScript.health <= 0)
        {
            bossScript.health = 0;
            Destroy(bossScript.phase1Instance);
        }
    }

    public void MilkManPhase2()
    {
        if (bossScript.phase2Health <= 0)
        {
            bossScript.health = 0;
            Destroy(gameObject);
        }
    }
}
