using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotShip : MonoBehaviour
{
    Vector3 offset;
    Vector3 target;
    float deg;

    [SerializeField]
    [Tooltip("弾の発射場所")]
    private GameObject firingPoint;

    [SerializeField]
    [Tooltip("弾")]
    private GameObject bullet;

    [SerializeField]
    [Tooltip("弾の速さ")]
    private float speed;

    [SerializeField]
    private GameObject Enemy;

    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
        GameObject T3 = GameObject.Find("aircraft-A-A");
        if(other.gameObject.tag == "ZombieRig")
        {
            if(T3 == null)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    // 弾を発射する
                    SetTarget(Enemy.transform.position, 15);
                }
            }
        }
    }
    /// <summary>
	/// 弾の発射
	/// </summary>
    IEnumerator ThrowMissile()
    {
        float b = Mathf.Tan (deg * Mathf.Deg2Rad);
        float a = (target.y - b * target.z) / (target.z * target.z);
      
        for (float z = 0; z <= this.target.z; z+= 10f)
        {
            float y = a * z * z + b * z;
            transform.position = new Vector3 (0, 0, 0) + offset;
            yield return null;
        }
    }
    public void SetTarget(Vector3 target, float deg)
    {
        Vector3 bulletPosition = firingPoint.transform.position;
        GameObject newBall = Instantiate(bullet, bulletPosition, transform.rotation);
        Vector3 direction = newBall.transform.forward;
        newBall.GetComponent<Rigidbody>().AddForce(direction * speed, ForceMode.Impulse);
        newBall.name = "Sphere 1";
        Destroy(newBall, 2.0f);
        this.offset = transform.position;
        this.target = target - this.offset;
        this.deg = deg;

        StartCoroutine ("ThrowMissile");
    }
}
