using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMoveScript : MonoBehaviour
{
    [SerializeField, Header("エネルギー管理スクリプト")]
    EnergyScript energyScript;

    //ロボットのRigidbody
    Rigidbody robotRB;
    [SerializeField, Header("ロボットの密度")]
    float density = 1.0f;
    [SerializeField,Header("移動力")]
    float force = 1.0f;

    void Start()
    {
        robotRB = GetComponent<Rigidbody>();

        //ロボットの質量を計算
        robotRB.mass = transform.localScale.x * transform.localScale.y * transform.localScale.z * density;
    }

    void Update()
    {
        //テスト用
        if (Input.GetKeyDown(KeyCode.A)) MoveLeft();
        if (Input.GetKeyDown(KeyCode.D)) MoveRight();
        if (Input.GetKeyDown(KeyCode.W)) MoveFront();                 
        if (Input.GetKeyDown(KeyCode.S)) MoveBack();
        if (Input.GetKeyDown(KeyCode.UpArrow)) MoveUp();
        if (Input.GetKeyDown(KeyCode.DownArrow)) MoveDown();
    }

    public void MoveLeft()//左移動
    {
        if (energyScript.UseEnergy(0.5f))
        {
            robotRB.AddForce(-transform.right * force / robotRB.mass, ForceMode.Impulse);
        }
    }
    public void MoveRight()//右移動
    {
        if (energyScript.UseEnergy(0.5f))
        {
            robotRB.AddForce(transform.right * force / robotRB.mass, ForceMode.Impulse);
        }
    }
    public void MoveFront()//前方移動
    {
        if (energyScript.UseEnergy(0.5f))
        {
            robotRB.AddForce(transform.forward * force / robotRB.mass, ForceMode.Impulse);
        }
    }
    public void MoveBack()//後方移動
    {
        if (energyScript.UseEnergy(0.5f))
        {
            robotRB.AddForce(-transform.forward * force / robotRB.mass, ForceMode.Impulse);
        }
    }
    public void MoveUp()//上移動
    {
        if (energyScript.UseEnergy(0.5f))
        {
            robotRB.AddForce(transform.up * force / robotRB.mass, ForceMode.Impulse);
        }
    }
    public void MoveDown()//下移動
    {
        if (energyScript.UseEnergy(0.5f))
        {
            robotRB.AddForce(-transform.up * force / robotRB.mass, ForceMode.Impulse);
        }
    }
}
