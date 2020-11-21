using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VehicleMovementController : MonoBehaviour
{
    
    public Rigidbody vehicle;
    private float tilt, baseTilt;

    public Transform topOfLever;

    void Start(){
        baseTilt = topOfLever.rotation.eulerAngles.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move(){
        tilt = topOfLever.rotation.eulerAngles.x;
        var speed = baseTilt - tilt;
        //Not working
        //vehicle.MovePosition(vehicle.transform.position + new Vector3(vehicle.transform.position.x, vehicle.transform.position.y, vehicle.transform.position.z + speed) * 0.2f);
    }

}
