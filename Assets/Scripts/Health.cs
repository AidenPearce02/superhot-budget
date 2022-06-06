using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    int HP = 100;
    public Text HPText;

    private void Update()
    {
        if(HP == 0)
        {
            HPText.enabled = false;
            Time.timeScale = 0f;
        }
    }

    public void Damage(int damage)
    {
        HPText.text = "HP: " + HP;
        HP -= damage;
        if(HP < 0)
        {
            HP = 0;
        }
    }

    public bool isDead()
    {
        return HP == 0;
    }
}
