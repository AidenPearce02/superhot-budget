using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    PlayerController playerController;
    Vector3 BulletSpreadVariance = new Vector3(0.2f, 0.2f, 0.2f);
    GameObject avatar;
    public GameObject bullet;
    GvrReticlePointerCustom gvrReticlePointerCustom;
    GameObject mainCamera;
    readonly float min = 0.03f;
    readonly float max = 0.13f;
    readonly float recoilTime = 0.5f;
    float currentFireTime = 0f;

    private void Awake()
    {
        avatar = transform.parent.gameObject;
        mainCamera = avatar.transform.Find("Main Camera").gameObject;
        gvrReticlePointerCustom = mainCamera.transform.Find("GvrReticlePointer").GetComponent<GvrReticlePointerCustom>();
        playerController = new PlayerController();
    }

    private void Update()
    {
        UpdateBulletSpreadVariance();
        if ((playerController.DesktopPlayer.Shooting.WasPressedThisFrame() || playerController.JoystickPlayer.Shooting.WasPressedThisFrame()) && currentFireTime >= recoilTime && avatar.GetComponent<Health>().isDead() == false)
        {
            Fire();
            currentFireTime = 0;
        }
        currentFireTime += Time.deltaTime;
    }

    private void UpdateBulletSpreadVariance()
    {
        float reticleInnerDiameter = gvrReticlePointerCustom.GetReticleInnerDiameter();
        if (reticleInnerDiameter >= max)
        {
            reticleInnerDiameter = max;
        }
        else if (reticleInnerDiameter <= min)
        {
            reticleInnerDiameter = min;
        }
        reticleInnerDiameter -= 0.03f;
        reticleInnerDiameter *= 10f;
        if (reticleInnerDiameter == 0)
        {
            BulletSpreadVariance = Vector3.zero;
        }
        else
        {
            BulletSpreadVariance = new Vector3(0.2f * reticleInnerDiameter, 0.2f * reticleInnerDiameter, 0.2f * reticleInnerDiameter);
        }
    }

    private void Fire()
    {
        Vector3 bulletSpawnPosition = mainCamera.transform.position + mainCamera.transform.forward;
        Quaternion bulletSpawnRotation = mainCamera.transform.rotation;
        GameObject bulletTemp =  Instantiate(bullet, bulletSpawnPosition, bulletSpawnRotation, transform);
        bulletTemp.transform.Rotate(90f, 0f, 0f);
        bulletTemp.GetComponent<Renderer>().material.color = new Color(0, 255, 0);
        bulletTemp.GetComponent<Rigidbody>().AddRelativeForce(GetDirection() * 250);
    }

    private Vector3 GetDirection()
    {
        Vector3 direction = Vector3.forward;
        direction += new Vector3(
            Random.Range(-BulletSpreadVariance.x, BulletSpreadVariance.x),
            Random.Range(-BulletSpreadVariance.y, BulletSpreadVariance.y),
            Random.Range(-BulletSpreadVariance.z, BulletSpreadVariance.z)
        );
        direction.Normalize();
        return direction;
    }

    private void OnEnable()
    {
        playerController.DesktopPlayer.Enable();
        playerController.JoystickPlayer.Enable();
    }

    private void OnDisable()
    {
        playerController.DesktopPlayer.Disable();
        playerController.JoystickPlayer.Disable();
    }
}
