using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float movementSpeed = 50f;
    [SerializeField] float turnSpeed = 60f;
    [SerializeField] Thruster[] thruster;
    [SerializeField] float sensitivity = 0.1f;
    public float minY = 60f;
    public float maxY = -60f;
    public Vector3 turn;
    Transform myT;
    private void Awake()
    {
        myT = transform;
    }
    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(myT.position);
        Turn();
        Thrust();
    }
    void Turn()
    {
        float yaw = turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        //turn.x += Input.GetAxis("Mouse X") * sensitivity;
        float pitch= turnSpeed * Time.deltaTime * Input.GetAxis("Pitch");
        float roll = turnSpeed * Time.deltaTime * Input.GetAxis("Roll");
        
        myT.Rotate(pitch, yaw, roll);
       


    }
    void Thrust()
    {
       if(Input.GetAxis("Vertical")>0)
        myT.position += myT.forward * movementSpeed * Time.deltaTime * Input.GetAxis("Vertical");
    }
    
}
