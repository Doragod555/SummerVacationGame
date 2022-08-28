using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    Vector3 offset;
    Vector3 target;
    float deg;

    [SerializeField]
    private GameObject MissilePrefab;

    [SerializeField]
    private GameObject Enemy;

    [SerializeField]
    private GameObject colliTransform;

    public static void DestoryIfExist( string name )
    {
        var gameObject = GameObject.Find("Missil_06 1(clone)");
        if ( gameObject == null )
        {
            return;
        }
        GameObject.Destroy( gameObject );
    }
    IEnumerator ThrowMissile()
    {
        float b = Mathf.Tan (deg * Mathf.Deg2Rad);
        float a = (target.y - b * target.x) / (target.x * target.x);
      
        for (float x = 0; x <= this.target.x; x+= 10f)
        {
            float y = a * x * x + b * x;
            transform.position = new Vector3 (x, y, 0) + offset;
            yield return null;
        }
    }
    public void SetTarget(Vector3 target, float deg)
    {
        this.offset = transform.position;
        this.target = target - this.offset;
        this.deg = deg;

        StartCoroutine ("ThrowMissile");
    }
    void Update()
    {
        GameObject T3 = GameObject.Find("aircraft-A-A");
        if(T3 == null)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "ZombieRig")
        {
            Vector3 MissilePosition = colliTransform.transform.position;
            GameObject newBall = Instantiate(MissilePrefab, MissilePosition, transform.rotation);
            Vector3 direction = newBall.transform.forward;
            newBall.name = "Missil_06 1(clone)";
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SetTarget(Enemy.transform.position, 60);
        }  
    }
    private void OnTriggerExit(Collider other)
    {
        GameObject T0 = GameObject.Find("Missil_06 1");
        GameObject T1 = GameObject.Find("Missil_06 1(clone)");
        if(other.gameObject.tag == "ZombieRig")
        {
            T0.SetActive(true);
            Destroy(T1, 0.001f);
            Vector3 MissilePosition = colliTransform.transform.position;
            GameObject newBall = Instantiate(MissilePrefab, MissilePosition, transform.rotation);
            newBall.name = "Missil_06 1";
        }
    }     
}
