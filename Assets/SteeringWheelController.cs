using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringWheelController : MonoBehaviour
{
    //Vehicle
    public GameObject vehicle;
    private Rigidbody rb;
    //turn damping, higher number reponds more accurately to wheel rotation.
    public float turnDampening = 50;
    private float turn, baseTurn;
    private bool handOnWheel;

    void Start()
    {
        rb = vehicle.GetComponent<Rigidbody>();
        baseTurn = this.transform.rotation.eulerAngles.z;
        handOnWheel = false;
    }

    // Update is called once per frame
    void Update()
    {
        TurnVehicle();
    }

    private void TurnVehicle(){
        if(handOnWheel){
            turn = this.transform.rotation.eulerAngles.z;
            float turnForce = baseTurn - turn;
            if(turnForce > 70 || turnForce < -70)
                rb.MoveRotation(Quaternion.RotateTowards(vehicle.transform.rotation, Quaternion.Euler(0,vehicle.transform.rotation.eulerAngles.y + turnForce,0), Time.deltaTime * turnDampening));
        }
        else
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.Euler(this.transform.rotation.eulerAngles.x,this.transform.rotation.eulerAngles.y,baseTurn), 0.1f);
    }

    void OnTriggerStay(Collider other){
        if(other.tag == "PlayerHand")
            handOnWheel = true;
    }    

    void OnTriggerExit(Collider other){
        if(other.tag == "PlayerHand")
            handOnWheel = false;
    }

}
