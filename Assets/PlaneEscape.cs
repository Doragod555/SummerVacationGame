using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaneEscape : MonoBehaviour
{
    public float speed; 
    private float EnemyGenerator;
    private int Count = 0;

    void Update()
    {
        transform.Translate(new Vector3(0.1f, 0, 0));
        transform.position += transform.forward * speed;
        if(this.gameObject.transform.position.x >= 2400)
        {
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter(Collider other){
        // もしもぶつかってきたオブジェクトのタグに「Missil_06」という名前がついていたら
        if(other.CompareTag("Missil_06"))
        {
            // ぶつかってきたオブジェクトを破壊（削除）せよ。
            Destroy(other.gameObject);
            Count++;
            if(Count >= 180)
            {
                Destroy(this.gameObject);
            }
        }
        else if(other.gameObject.name == "ZombieRig")
        {
            transform.Rotate(new Vector3(0, 180, 0));
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.name == "ZombieRig")
        {
            transform.position -= Vector3.right;
        }
    }
}
