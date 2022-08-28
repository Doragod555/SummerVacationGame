using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShotA : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Missil_06") //プレイヤーが武器を取ったら消す
        {
            Destroy(other);
            Debug.Log("拾う");
        }
    }
}
