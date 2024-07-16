using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Digicode : Interactable
{
    public GameObject[] garageDoors;
    DigicodeUI ui;
    //public GarageDoor garageDoor_;

    private void Start()
    {
        ui = GetComponentInChildren<DigicodeUI>();
    }
    public override void Interact()
    {
        foreach (GameObject go in garageDoors) 
        {
            if (!go) continue;
            go.GetComponentInChildren<GarageDoor>().SwitchState();
        }
        
    }

    public override void ShowUI()
    {
        ui.setUIVisible(true);
    }
}
