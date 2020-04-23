using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class DeathCheck : MonoBehaviour
{
    public bool Dead = false;
    public float voidLevel = -4.0f;
    private Transform _transform;
    public Transform target;
    public GameObject Player;
    private string path;
    // Start is called before the first frame update
    void Start()
    {
        Dead = false;
        

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (target.position.y < voidLevel) //Check if player position is too low
        {
            Dead = true;
            Debug.Log("Died");
        }

        if (Dead == true)
        {
            
            if (PlayerPrefs.GetInt("Auto-respawn", 0) == 1)
            {
                Debug.Log("Auto-repsawning");
                SceneManager.LoadScene(PlayerPrefs.GetString("Selected Level","0"));
            }
            else
            {
                Cursor.visible = true;
                SceneManager.LoadScene(0, LoadSceneMode.Single);
            }
        }
    }
    public void DeathScene()
    {
        SceneManager.LoadScene("Death Scene");
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Trap")
        {
            Debug.Log("Trap hit");
            Dead = true;
        }
    }

}
