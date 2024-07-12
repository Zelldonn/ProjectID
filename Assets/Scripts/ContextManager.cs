using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextManager : MonoBehaviour
{

    public enum EContext
    {
        CharacterContext,
        DroneContext,
    };

    private class Context
    {
        bool b_IsActive;
        GameObject[] GO_objects;
        string s_contextName;

        public Context(string contextName)
        {
            GO_objects = GameObject.FindGameObjectsWithTag(contextName);
            b_IsActive = true;
            s_contextName = contextName;
        }

        public void FindContextGameObject()
        {
            GO_objects = GameObject.FindGameObjectsWithTag(s_contextName);
        }
        public void SetState(bool state)
        {
            if (GO_objects == null) {
                return; 
            }
            foreach (GameObject obj in GO_objects)
            {
                obj.SetActive(state);
            }
            b_IsActive = state;
        }


    }

    string[] ContextNames = { "CharacterContext", "DroneContext" };
    Dictionary<string, Context> ContextDictionnary = new Dictionary<string, Context>();

    EContext currentContext = EContext.CharacterContext;

    void Start()
    {
        foreach(string ContextName in ContextNames)
        {
            ContextDictionnary.Add(ContextName, new Context(ContextName));
        }

        SetContext(EContext.CharacterContext);
    }

    public void SetContext(EContext Context)
    {

        foreach(KeyValuePair<string, Context> entry in ContextDictionnary) {
            entry.Value.SetState(false);
        }
        SetContextState(Context, true);
    }

    public void ForceFindContext(EContext Context)
    {
        string ContextName = Context.ToString("g");
        ContextDictionnary[ContextName].FindContextGameObject();
    }

    public void SetContextState(EContext Context, bool state)
    {
        string ContextName = Context.ToString("g");
        ContextDictionnary[ContextName].SetState(state);
        if(state == true)
            currentContext = Context;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            if(currentContext == EContext.CharacterContext)
            {
                SetContext(EContext.DroneContext);
            }
            else
            {
                SetContext(EContext.CharacterContext);
            }
            
        }
    }

}
