using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {

    private TriBoss Boss;
    [SerializeField]
    private int index;

    private void OnTriggerExit(Collider other)
    {
        Boss = other.GetComponent<TriBoss>();
        Boss.TeleportTo(index);
    }
}
