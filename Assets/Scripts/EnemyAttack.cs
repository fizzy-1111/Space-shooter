using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Laser laser;
    [SerializeField] float fireRate = 1f;
    private float nextfire = 0f;
    Vector3 hitPosition;

    private void Update()
    {
        if (!FindTarget())
        {
            return;
        }
        Infront();
        haveLineofSight();
        if (Infront() && haveLineofSight())
        {
            if (Time.time > nextfire)
            {
                nextfire = Time.time + fireRate;
                fireLaser();
            }

        }
    }
    bool Infront()
    {
        Vector3 directionToTarget = transform.position - target.position;
        float angle = Vector3.Angle(transform.forward, directionToTarget);
        if (Mathf.Abs(angle) > 90 && Mathf.Abs(angle) < 270)
        {
            //Debug.DrawLine(transform.position, target.position, Color.blue);
            return true;
        }
        // Debug.DrawLine(transform.position, target.position, Color.yellow);
        return false;
    }
    bool haveLineofSight()
    {
        RaycastHit hit;
        Vector3 direction = target.position - laser.transform.position;
        if (Physics.Raycast(laser.transform.position, direction, out hit, laser.Distance()))
        {
            if (hit.transform.CompareTag("Player"))
            {
                Debug.DrawRay(laser.transform.position, direction, Color.green);
                hitPosition = hit.transform.position;
                return true;

            }
        }
        return false;
    }
    void fireLaser()
    {
        laser.FireLaser(hitPosition, target);
    }
    bool FindTarget()
    {
        if (target == null)
        {
            //Debug.Log("still work");
            GameObject tempt = GameObject.FindGameObjectWithTag("Player");
            //Debug.Log("still work");
            if (tempt != null) target = tempt.transform;
        }

        if (target == null) return false;
        return true;
    }
}