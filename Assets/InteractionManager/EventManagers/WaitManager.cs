﻿using UnityEngine;
using System;

public class WaitManager : MonoBehaviour {

    public InteractionManager interactionManager;

    void Start()
    {
        interactionManager = GameObject.Find("Timeline").GetComponent<InteractionManager>();
    }
    public void Waiting(float seconds)
    {
        interactionManager.startWaiting();
        Invoke("StopWaiting", seconds);
    }

    public void StopWaiting()
    {
        interactionManager.stopWaiting();
    }
}
