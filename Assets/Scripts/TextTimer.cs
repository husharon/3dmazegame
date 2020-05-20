using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTimer : MonoBehaviour
{
    public float duration; // seconds to read the text

    void Start()
    {
        Invoke("Disappear", duration);
    }

    void Disappear()
    {
        Destroy(gameObject);
    }
}
