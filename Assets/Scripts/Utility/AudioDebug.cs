using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDebug : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(gameObject.name + " : Playing=" + gameObject.GetComponent<AudioSource>().isPlaying + " : Clip=" + gameObject.GetComponent<AudioSource>().clip);
    }
}
