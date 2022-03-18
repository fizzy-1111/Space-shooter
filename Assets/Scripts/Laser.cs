using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Laser : MonoBehaviour
{
    [SerializeField] float laserOfftime = 0.5f;
    [SerializeField] float maxDistance = 300f;
    bool canFire = true;
    LineRenderer lr;
    private void Update()
    {
        //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * maxDistance, Color.yellow);
    }
    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }
    private void Start()
    {
        lr.enabled = false;
    }
    Vector3 Cast()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance))
        {
            Debug.Log("hit target" + hit.transform.name);
            spawnExplosion(hit.point, hit.transform);
            return hit.point;
        }
        Debug.Log("We missed...");
        return transform.forward * maxDistance;
    }
    public void spawnExplosion(Vector3 hitPosition,Transform target)
    {
        Explosion Tempt = target.GetComponent<Explosion>();
        if (Tempt != null)
        {
            Tempt.AddForce(hitPosition, transform);
        }
            
    }
    public void FireLaser()
    {
        if (canFire)
        {
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1,Cast());
            lr.enabled = true;
            canFire = false;
        }
        Invoke("TurnOffLaser", laserOfftime);
    }
    public void FireLaser(Vector3 targetPosition,Transform target=null)
    {
        if (canFire)
        {
            if (target != null)
                spawnExplosion(targetPosition, target);
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, targetPosition);
            lr.enabled = true;
            canFire = false;
        }
        Invoke("TurnOffLaser", laserOfftime);
    }   
    void TurnOffLaser()
    {
        lr.enabled = false;
        canFire = true;
    }
    public float Distance()
    {
         return maxDistance; 
    }
    public int random()
    {
        return 3;
    }
}
