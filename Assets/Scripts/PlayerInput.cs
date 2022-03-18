using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float range = 300f;
    public Transform myT;
    [SerializeField] GameObject explosion   ;
    Hp hpObject;
    Explosion ForceObject;
    private void Awake()
    {
        myT = transform;
    }
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Aim();
        }
    }
    void Aim()
    {
        GameObject go = Instantiate(explosion, myT.transform.position + myT.transform.forward * 10, Quaternion.identity);
        Destroy(go, 0.5f);  
        RaycastHit hit;
        Debug.DrawRay(myT.transform.position,myT.transform.forward*range, Color.red);
        if (Physics.Raycast(myT.transform.position,myT.transform.forward,out hit, range)){

            hpObject = hit.transform.GetComponent<Hp>();
            hpObject.takeDamage();
            ForceObject = hit.transform.GetComponent<Explosion>();
            ForceObject.AddForce(hit.point, myT);
            
        }
    }
}
