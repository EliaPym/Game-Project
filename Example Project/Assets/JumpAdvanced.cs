using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpAdvanced : MonoBehaviour
{
    public Rigidbody targetPhysics;
    public float defaultJumpForce = 4500;
    public float JumpForce;
    private Vector3 change;
    public float ForceY = 0.0f;
    public float floorCheckLevel = 0.45f;
    private bool OnGround = false;
    public bool AirJump = true;
    public Vector3 SpinRotation = new Vector3(-5, 0, 0);
    public bool SpinRunning = false;
    // Start is called before the first frame update
    void Start()
    {
        JumpForce = defaultJumpForce;
        //StartCoroutine("Spin");
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        bool FingerJump = false;
        if (Input.touches.Length != 0)
        {
            FingerJump = Input.touches[Input.touches.Length - 1].phase == TouchPhase.Stationary; //Detects if there is a swipe indicating jump
        } 
        if ((Input.GetKeyDown("space") == true) || (SceneManager.GetActiveScene().name == "Alien") || (FingerJump) || Input.GetButton("Jump"))
        {
            //Debug.Log(SceneManager.GetActiveScene().name);

            if (gameObject.GetComponent<DetectObject>().detectObject(new Vector3(targetPhysics.position.x, targetPhysics.position.y - floorCheckLevel, targetPhysics.position.z + 0.2f), 0.01f) == true || OnGround == true)
            {
                ForceY = ForceY + JumpForce;
                Debug.Log("Should jump with force "+ForceY);
            }
            /**
            else if (AirJump == false && (Input.GetKeyDown("space") == true || FingerJump || Input.GetButton("Jump")))
            {
                //ForceY = ForceY + JumpForce*5;
                if (SpinRunning == false) //If not alrady running it will allow the player to perform a mid-air jump
                {
                    StartCoroutine("Spin");
                }
                //AirJump = true;
            }
            
            else if ((Input.GetKey("space") == true || (FingerJump)) & (rb.velocity.y > 0.5f) && AirJump == false)
            {
                ForceY = ForceY / 10; //Makes jump last longer
                Debug.Log("Holding jump");
            }
            **/
        }


        else
        {
            ForceY = 0.0f;
        }

        if (ForceY > JumpForce*2)
        {
            ForceY = JumpForce;
        }
        change.y = ForceY;
        targetPhysics.AddForce(change, ForceMode.Force);

    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            AirJump = false;
            if (other.transform.position.z < this.transform.position.z)
            {
                OnGround = true;
            }
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            OnGround = false;
            AirJump = false;
        }
    }
    IEnumerator Spin()
    {
        int x = 0;
        SpinRunning = true;
        Debug.Log("Preparing for mid air jump");
        yield return new WaitForSeconds(0.2f);
        if (AirJump == false)
        {
            Debug.Log("Waiting for mid air jump");
            if ((Input.GetKeyDown("space") == true || Input.GetButton("Jump")))
            {
                Debug.Log("Spin!");
                AirJump = true;
                ForceY = ForceY + JumpForce/2;
                Debug.Log("Should air jump with force " + ForceY);
                for (x = 0; x < (360 / SpinRotation.magnitude); x++)
                {
                    this.transform.Rotate(SpinRotation);
                    //this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y+0.01f, this.transform.position.z);
                    //Debug.Log("Spin " + (x + 1));
                    yield return new WaitForSeconds(0.025f);
                }
            }
        }
        Debug.Log("Stopped checking for mid-air jump");
        SpinRunning = false;
        yield return null;
    }
}
