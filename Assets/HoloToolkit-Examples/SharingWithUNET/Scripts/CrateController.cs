using HoloToolkit.Examples.SharingWithUNET;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateController : MonoBehaviour {

    public TextMesh tm;
    private void Start()
    {
        // The Crates's transform should be in local space to the Shared Anchor.
        // Make the shared anchor the parent, but we don't want the transform to try
        // to 'preserve' the position, so we set false in SetParent.
        transform.SetParent(SharedCollection.Instance.transform, false);
        tm.text += transform.parent.name;
    }
}
