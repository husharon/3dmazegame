using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public int sceneNum;
    GameManagerScript GMS;


    private void Awake()
    {
       GMS = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GMS.gameWon = true;
            StartCoroutine(WaitFiveSeconds());
        }
    }

    private IEnumerator WaitFiveSeconds()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(sceneNum);
    }
}
