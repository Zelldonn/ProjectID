using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance {  get; private set; }
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Audio Manager in the scene.");
        }
        instance = this;
    }

    public void PlayOneShot(EventReference sound, Vector3 worldPos)
    {
        RuntimeManager.PlayOneShot(sound, worldPos);
    }

    public void PlayOneShotAttached(EventReference sound, GameObject go)
    {
        RuntimeManager.PlayOneShotAttached(sound, go);
    }

    public EventInstance CreateInstance(GameObject go, EventReference sound)
    {
        EventInstance instance = RuntimeManager.CreateInstance(sound);
        RuntimeManager.AttachInstanceToGameObject(instance, go.transform);

        return instance;
    }

    public void StartInstance(EventInstance eventInstance)
    {
        eventInstance.start();
    }

    public void SetInstanceParameterByName(EventInstance eventInstance, string paramName, float value)
    {
        eventInstance.setParameterByName(paramName, value);
    }
}
