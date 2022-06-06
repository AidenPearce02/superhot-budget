using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifetime : MonoBehaviour
{
    readonly float maxLifetime = 5f;
    float currentLifeTime = 0f;
    bool isShootedByPlayer = false;

    private void Start()
    {
        if (transform.parent.name == "Settings"){
            isShootedByPlayer = true;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        currentLifeTime += Time.deltaTime;
        if(maxLifetime < currentLifeTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Avatar" && !isShootedByPlayer){
            collision.gameObject.GetComponent<Health>().Damage(1);
        }
        else if (collision.gameObject.CompareTag("Enemy") && isShootedByPlayer){
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }
}
