using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemymovement : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float rotationDamp = 0.5f;
    [SerializeField] float movementSpeed = 10f;
    [SerializeField] float RaycastOffset = 2.5f;
    [SerializeField] float DetectionDistance = 2.5f;
    private void Update()
    {
        if (!FindTarget())
        {
            //Debug.Log("target found");
            return;
        }
        pathFinding();
        Move();
    }
    private void OnEnable()
    {
        EventManager.onPlayerDeath += FindMainCamera;
    }
    private void OnDisable()
    {
        EventManager.onPlayerDeath -= FindMainCamera;
    }
    void Turn()
    {
        //Debug.Log(target.position);
        Vector3 pos = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(pos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationDamp * Time.deltaTime);

    }
    void Move()
    {
        transform.position += transform.forward * Time.deltaTime * movementSpeed;
    }
    void pathFinding()
    {
        RaycastHit hit;
        Vector3 rayCastoffSet = Vector3.zero;
        Vector3 left = transform.position - transform.right * RaycastOffset;
        Vector3 right = transform.position + transform.right * RaycastOffset;
        Vector3 up = transform.position + transform.up * RaycastOffset;
        Vector3 down = transform.position - transform.up * RaycastOffset;
        Debug.DrawRay(left, transform.forward * DetectionDistance, Color.cyan);
        Debug.DrawRay(right, transform.forward * DetectionDistance, Color.cyan);
        Debug.DrawRay(up, transform.forward * DetectionDistance, Color.cyan);
        Debug.DrawRay(down, transform.forward * DetectionDistance, Color.cyan);
        if (Physics.Raycast(left, transform.forward, out hit, DetectionDistance))
           rayCastoffSet -= Vector3.right;
        else if(Physics.Raycast(right, transform.forward, out hit, DetectionDistance))
            rayCastoffSet += Vector3.right;
        else if(Physics.Raycast(up, transform.forward, out hit, DetectionDistance))
            rayCastoffSet += Vector3.up;
        else if (Physics.Raycast(down, transform.forward, out hit, DetectionDistance))
            rayCastoffSet -= Vector3.up;
        if (rayCastoffSet != Vector3.zero)
        {
            transform.Rotate(rayCastoffSet * 5f * Time.deltaTime);
        }
        else Turn();
    }
    bool FindTarget()
    {
        if (target == null)
        {
            GameObject tempt = GameObject.FindGameObjectWithTag("Player");
            if (tempt != null) target = tempt.transform;
            
        }

        if (target == null) return false;
        return true;
    }
    void FindMainCamera()
    {
        target = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }
}
