using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform target; //Target will be set to the player
    public Rigidbody targetPhysics; //Will be set to the player's physics
    public float defaultMoveForce = 0.3f; //The standard force added when no power up activated (used for block spawning algorithm)
    public float moveForce = 0.3f; //Force added when a movement related key is pressed
    public float dragFactor = 5.0f;
    public float limitFactor = 5;
    // Start is called before the first frame update
    private void Awake() //Sets default controls if none are assigned
    {
        //PlayerPrefs.DeleteAll();
        Debug.Log("Checking inputs");
        if (PlayerPrefs.GetString("forwards") == "")
        {
            Debug.Log("Default forwards key");
            PlayerPrefs.SetString("forwards","w");
        }

        if (PlayerPrefs.GetString("backwards") == "")
        {
            Debug.Log("Default backwards key");
            PlayerPrefs.SetString("backwards", "s");
        }


        if (PlayerPrefs.GetString("left") == "")
        {
            Debug.Log("Default left key");
            PlayerPrefs.SetString("left", "a");
        }
        if (PlayerPrefs.GetString("right") == "")
        {
            Debug.Log("Default right key");
            PlayerPrefs.SetString("right", "d");
        }
    }
    void Start()
    {
        moveForce = defaultMoveForce;
    }
    private float ForceZ = 0.0f; //All forces set to 0 when level started
    private float ForceX = 0.0f;
    //private float ForceY = 0.0f;
    private Vector3 change;
    private Vector3 dragChange;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(PlayerPrefs.GetString("forwards")) == true || (Input.touches.Length > 1 && Input.touches[Input.touches.Length-1].deltaPosition.y > 20)) //Will check if forwards key is held or touch input given
        {
            if (ForceZ*limitFactor < moveForce)
            {

                ForceZ += moveForce;
                //Debug.Log("Forwards pressed" + ForceZ + "m" + moveForce);
            }
        }
        else if (Input.GetKey(PlayerPrefs.GetString("backwards")) == false)
        {
            ForceZ = 0.0f;
        }

        if (Input.GetKey(PlayerPrefs.GetString("backwards")) == true)
        {
            if (ForceZ*limitFactor > -moveForce)
            {
                //Debug.Log("Backwards pressed");
                ForceZ = ForceZ - moveForce;
            }
        }
        else if (Input.GetKey(PlayerPrefs.GetString("forwards")) == false)
        {
            ForceZ = 0.0f;
        }
        

        if (Input.GetKey(PlayerPrefs.GetString("left")) == true || (Input.touches.Length > 1 && Input.touches[Input.touches.Length - 1].deltaPosition.x < -20))
        {
            if (ForceX * limitFactor > -moveForce)
            {
                ForceX = ForceX - moveForce;
            }
        }
        else if (Input.GetKey(PlayerPrefs.GetString("right")) == false)
        {
            ForceX = 0.0f;
        }


        if (Input.GetKey(PlayerPrefs.GetString("right")) == true || (Input.touches.Length > 1 && Input.touches[Input.touches.Length - 1].deltaPosition.x > 20))
        {
            if (ForceX * limitFactor < moveForce)
            {
                ForceX = ForceX + moveForce;
            }
        }
        else if (Input.GetKey(PlayerPrefs.GetString("left")) == false)
        {
            ForceX = 0.0f;
        }


        change.x = ForceX;
        change.z = ForceZ;
        change.y = 0.0F;
        //targetPhysics.AddForce(Input.gyro.rotationRate, ForceMode.VelocityChange);
        
        if (change == new Vector3(0,0,0)) //Drag whith no inputs
        {
            //Debug.Log("No movement");
            dragChange = -targetPhysics.velocity / dragFactor;
            targetPhysics.AddForce(new Vector3(dragChange.x, -0.1f, dragChange.z), ForceMode.VelocityChange);
            //targetPhysics.AddForce(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")*2), ForceMode.VelocityChange);
            if (Input.touches.Length>0 && Input.touches[Input.touches.Length - 1].deltaPosition.magnitude > 5)
            {
                targetPhysics.AddForce(new Vector3(Input.touches[Input.touches.Length - 1].deltaPosition.x / 20, 0, (Input.touches[Input.touches.Length - 1].deltaPosition.y - 5) / 20), ForceMode.VelocityChange);
            }
        }
        else
        {
            //Debug.Log("A movement");
            if ((-moveForce * limitFactor <= targetPhysics.velocity.z) && (targetPhysics.velocity.z <= moveForce * limitFactor))
            {
                targetPhysics.AddForce(change, ForceMode.VelocityChange);
            }
            else
            {
                targetPhysics.AddForce(new Vector3(change.x,0,0), ForceMode.VelocityChange);
            }
            if ((-moveForce * limitFactor <= targetPhysics.velocity.x) && (targetPhysics.velocity.x <= moveForce * limitFactor))
            {
                targetPhysics.AddForce(change, ForceMode.VelocityChange);
            }
            else
            {
                targetPhysics.AddForce(new Vector3(0,0,change.z), ForceMode.VelocityChange);
            }
        }
    
        //targetPhysics.velocity = new Vector3(ForceX, targetPhysics.velocity.y, ForceZ);
        
    }
}
