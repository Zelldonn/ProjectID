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
        PlayOneShot(FmodEvents.instance.Music);
    }

    public void PlayOneShot(EventReference sound, Vector3 worldPos = default)
    {
        RuntimeManager.PlayOneShot(sound, worldPos);
    }

    public void PlayOneShotAttached(EventReference sound, GameObject go)
    {
        RuntimeManager.PlayOneShotAttached(sound, go);
    }

    public EventInstance CreateInstance(EventReference sound)
    {
        EventInstance instance = RuntimeManager.CreateInstance(sound);
        return instance;
    }

    public EventInstance AttachInstanceToGameObject(EventInstance instance, Transform transform, Rigidbody rb)
    {
        RuntimeManager.AttachInstanceToGameObject(instance, transform, rb);

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
