using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour {

    public Transform target;

    public float smoothspeed = 0.125f;
    public Vector3 positionOffset;
    public Vector3 angleOffset;
    public bool cameraPreset = true;

    private void Start()
    {
        if (cameraPreset == true)
        {
            if (SceneManager.GetActiveScene().name != "Classic")
            {
                if (PlayerPrefs.GetInt("Camera Angle") == 1)
                {
                    positionOffset = new Vector3(0, 2, -1.5f);
                    angleOffset = new Vector3(0, 0.8f, 0.5f);
                    Debug.Log("Camera angle 1");
                }
                else if (PlayerPrefs.GetInt("Camera Angle") == 2)
                {
                    positionOffset = new Vector3(0, 3, -1.8f);
                    angleOffset = new Vector3(0, 0.7f, 0.9f);
                    Debug.Log("Camera angle 2");
                }
                else if (PlayerPrefs.GetInt("Camera Angle") == 3)
                {
                    positionOffset = new Vector3(0, 4, -2.8f);
                    angleOffset = new Vector3(0, 0.6f, 1.2f);
                    Debug.Log("Camera angle 3");
                }
                else
                {
                    Debug.Log("Defaulting to camera angle 1");
                    positionOffset = new Vector3(0, 2, -1.5f);
                    angleOffset = new Vector3(0, 0.8f, 0.5f);
                    Debug.Log("Camera angle 1");
                }
                Debug.Log("Defaulting to camera angle 1");
            }
        }
    }
    void FixedUpdate ()
    {
        Vector3 exactfollow = target.position + positionOffset;
        Vector3 smoothfollow = Vector3.Lerp(transform.position, exactfollow, smoothspeed);
        transform.position = smoothfollow;
        

        transform.LookAt(target.position + angleOffset);
    }
}
