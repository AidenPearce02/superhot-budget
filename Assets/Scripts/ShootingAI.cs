using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAI : MonoBehaviour
{
    public GameObject bullet;
    GameObject Player;
    readonly float distance = 10f;
    readonly float recoilTime = 1f;
    float currentFireTime = 0f;

    private void Start()
    {
        Player = GameObject.Find("Avatar");
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, Player.transform.position) <= distance && currentFireTime >= recoilTime)
        {
            Fire();
            currentFireTime = 0;
        }
        currentFireTime += Time.deltaTime;
    }

    private void Fire()
    {
        Vector3 bulletSpawnPosition = transform.position + transform.forward;
        bulletSpawnPosition.y = 1.5f;
        Quaternion bulletSpawnRotation = transform.rotation;
        GameObject bulletTemp =  Instantiate(bullet, bulletSpawnPosition, bulletSpawnRotation, transform);
        bulletTemp.transform.Rotate(90f, 0f, 0f);
        bulletTemp.transform.Find("Trail").GetComponent<TrailRenderer>().startColor = new Color(255, 0, 0);
        Vector3 vectorFire = Player.transform.forward;
        bulletTemp.GetComponent<Rigidbody>().AddRelativeForce(vectorFire * 150);
    }
}
