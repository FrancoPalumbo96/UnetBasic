using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsEventsManager : MonoBehaviour
{
    public ButtonsEventsManager instance;
    private event Action HostButtonClick;
    private event Action ConnectButtonClick;
    void Start()
    {
        instance = this;
    }


    public void hostButtonClicked()
    {
        if (HostButtonClick != null)
        {
            HostButtonClick();
        }
    }

    public void connectButtonClicked()
    {
        if (ConnectButtonClick != null)
        {
            ConnectButtonClick();
        }
    }
}
