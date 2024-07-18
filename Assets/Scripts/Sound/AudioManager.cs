using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance {  get; private set; }
    void Awake()
    {
        if (!instance)
        {
            Debug.Log("Found more than one Audio Manager in the scene.");
        }
        instance = this;
    }

    public void PlayOnShot(EventReference sound, Vector3 worldPos)
    {
        RuntimeManager.PlayOneShot(sound, worldPos);
    }
}
