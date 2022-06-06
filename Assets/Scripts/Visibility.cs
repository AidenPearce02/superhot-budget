using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visibility : MonoBehaviour
{
    public void Apear()
    {
        GetComponent<MeshRenderer>().enabled = true;
    }

    public void Disapear()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }
}
