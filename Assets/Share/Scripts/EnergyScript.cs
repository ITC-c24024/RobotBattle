using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyScript : MonoBehaviour
{
    //エネルギー量
    float energyAmount = 0;

    void Start()
    {
        IncEnergy();
    }

    void Update()
    {
        
    }

    //一定時間ごとにエネルギー量を増やす
    void IncEnergy()
    {
        energyAmount++;
        //Debug.Log(energyAmount);

        Invoke("IncEnergy", 1);
    }

    //エネルギー消費関数
    public bool UseEnergy(float useAmount)//関数を呼ぶ側で消費量を指定
    {
        if (energyAmount - useAmount >= 0)//必要エネルギーがあるとき
        {
            energyAmount -= useAmount;

            return true;
        }
        else //ないとき
        {
            return false;
        }
    }
}
