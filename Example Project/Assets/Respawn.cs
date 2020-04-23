using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.timeSinceLevelLoad > 4)//Time before respawn
        {
            Respawner();
        }
    }
    public void Respawner()
    {
        Cursor.visible = false;
        SceneManager.LoadSceneAsync(0);
    }
}
