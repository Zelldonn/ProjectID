using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FmodEvents : MonoBehaviour
{
    [field: Header("DoorSFX")]
    [field: SerializeField] public EventReference garageDoor { get; private set; }

    [field: Header("InteractionSFX")]
    [field: SerializeField] public EventReference HackInteration { get; private set; }
    
    [field: Header("DroneSFX")]
    [field: SerializeField] public EventReference Drone { get; private set; }
    public static FmodEvents instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one FMOD Events instance in the scene.");

        }
        instance = this;
    }

}

