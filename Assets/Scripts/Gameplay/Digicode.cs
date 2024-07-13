using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Digicode : Interactable
{
    public GameObject garageDoor;
    DigicodeUI ui;
    //public GarageDoor garageDoor_;

    private void Start()
    {
        ui = GetComponentInChildren<DigicodeUI>();
    }
    public override void Interact()
    {
        garageDoor.GetComponentInChildren<GarageDoor>().SwitchState();
    }

    public override void ShowUI()
    {
        ui.setUIVisible(true);
    }
}
