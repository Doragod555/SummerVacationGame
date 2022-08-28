using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieA : MonoBehaviour
{
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Missil_06")
        {
            //「←」入力の場合は変数「pos」のx軸における座標を毎フレーム毎に１だけ減少
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                pos.z += -1;
            }
            //「↑」入力の場合は変数「pos」のz軸における座標を毎フレーム毎に１だけ増加
            if (Input.GetKey(KeyCode.UpArrow))
            {
                pos.x += -1;
            }
            //「↓」入力の場合は変数「pos」のz軸における座標を毎フレーム毎に１だけ減少
            if (Input.GetKey(KeyCode.DownArrow))
            {
                pos.x += -1;
            }
        }
        else
        {
            //「←」入力の場合は変数「pos」のx軸における座標を毎フレーム毎に１だけ減少
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                pos.z += 0;
            }
            //「↑」入力の場合は変数「pos」のz軸における座標を毎フレーム毎に１だけ増加
            if (Input.GetKey(KeyCode.UpArrow))
            {
                pos.x += 0;
            }
            //「↓」入力の場合は変数「pos」のz軸における座標を毎フレーム毎に１だけ減少
            if (Input.GetKey(KeyCode.DownArrow))
            {
                pos.x -= 0;
            }
            transform.position = pos;
        }
    }
        // Update is called once per frame
    void Update()
    {
        //「→」入力の場合は変数「pos」のx軸における座標を毎フレーム毎に１だけ増加
        if (Input.GetKey(KeyCode.RightArrow))
        {
            pos.z -= 1;
        }
        //「←」入力の場合は変数「pos」のx軸における座標を毎フレーム毎に１だけ減少
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            pos.z += 1;
        }
        //「↑」入力の場合は変数「pos」のz軸における座標を毎フレーム毎に１だけ増加
        if (Input.GetKey(KeyCode.UpArrow))
        {
            pos.x += 1;
        }
        //「↓」入力の場合は変数「pos」のz軸における座標を毎フレーム毎に１だけ減少
        if (Input.GetKey(KeyCode.DownArrow))
        {
            pos.x -= 1;
        }
        //変数「pos」の値をオブジェクトの座標に反映させる
        transform.position = pos;
    }
}
