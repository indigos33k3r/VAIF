﻿using UnityEngine;
using System.Collections.Generic;


public class InAgentRange : MonoBehaviour
{
    public float timeInRange;
    protected GameObject PlayerCollider;
    string tagged = "Player";

    void OnTriggerEnter(Collider other)
    {
        PlayerCollider = other.gameObject;
        //Debug.Log(PlayerCollider.tag + " " + tagged);
        if (PlayerCollider.tag == tagged)
        {
            Invoke("InCharacterRange", timeInRange);
        }
    }

    void OnTriggerExit(Collider other)
    {
        PlayerCollider = other.gameObject;
        if (PlayerCollider.tag == tagged && this.gameObject.GetComponentInParent<AgentStatusManager>().name==this.transform.parent.name)
        {
            this.gameObject.GetComponentInParent<AgentStatusManager>().stopInRange();
            //Debug.Log("not in range of: " + this.gameObject.GetComponentInParent<AgentStatusManager>().name);
            CancelInvoke("InCharacterRange");
        }
    }

    void InCharacterRange()
    {
        if (this.gameObject.GetComponentInParent<AgentStatusManager>().name == this.transform.parent.name)
        {
            this.gameObject.GetComponentInParent<AgentStatusManager>().startInRange();
            //Debug.Log("in range of: " + this.gameObject.GetComponentInParent<AgentStatusManager>().name);
        }
    }
}
