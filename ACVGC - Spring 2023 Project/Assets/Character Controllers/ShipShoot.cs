using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShoot : MonoBehaviour
{
    public Bullet       bulletScript;
    public GameObject   bulletPrefab1;
    public GameObject   bulletPrefab2;

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "PlayerA" && Input.GetKeyDown(KeyCode.F))
        {

            GameObject bulletInstance = Instantiate(bulletPrefab1, transform.position, Quaternion.identity);
            bulletScript = bulletInstance.GetComponent<Bullet>();
            bulletScript.ShootBullet(transform.up);
        }

        if (gameObject.tag == "PlayerB" && Input.GetKeyDown(KeyCode.RightShift) || gameObject.tag == "PlayerB" && Input.GetKeyDown(KeyCode.PageUp))
        {

            GameObject bulletInstance = Instantiate(bulletPrefab2, transform.position, Quaternion.identity);
            bulletScript = bulletInstance.GetComponent<Bullet>();
            bulletScript.ShootBullet(transform.up);
        }
    }
}
