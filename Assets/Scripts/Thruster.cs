using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thruster : MonoBehaviour
{
    TrailRenderer tr;
    // Start is called before the first frame update
    private void Awake()
    {
        tr = GetComponent<TrailRenderer>();

    }
    public void Activate(bool activate = true)
    {
        if (activate)
        {
            tr.enabled = true;
        }
        else
        {
            tr.enabled = false;
        }
    }
}
