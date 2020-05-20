using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{ 

    void Update()
    {
        if (Input.GetKey(KeyCode.T))
        {
            SceneManager.LoadScene(1);
        }

        if (Input.GetKey(KeyCode.Alpha1))
        {
            SceneManager.LoadScene(2);
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            SceneManager.LoadScene(3);
        }

        if (Input.GetKey(KeyCode.Alpha3))
        {
            SceneManager.LoadScene(4);
        }
    }
}
