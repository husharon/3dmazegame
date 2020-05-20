using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior : MonoBehaviour
{
    GameManagerScript GMS;
    private float rotateSpeed = 5f;

    void Awake()
    {
        GMS = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        GMS.coinCount++;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.back * rotateSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            GMS.coinCount--;
            // adding score
            GMS.UpdateUI();
        }
    }
}
