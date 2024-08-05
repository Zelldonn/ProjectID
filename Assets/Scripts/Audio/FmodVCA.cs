using UnityEngine;
using FMODUnity;


public class FmodVCA : MonoBehaviour
{
    [field: Header("Master")]
    [field: SerializeField] public FMOD.Studio.VCA MasterVCA { get; private set; }

    public static FmodVCA instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one FMOD Events instance in the scene.");

        }
        instance = this;

        MasterVCA = RuntimeManager.GetVCA("vca:/Master");
    }


}

