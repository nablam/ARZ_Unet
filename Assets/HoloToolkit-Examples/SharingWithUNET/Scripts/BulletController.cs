// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using UnityEngine;
using UnityEngine.Networking;

namespace HoloToolkit.Examples.SharingWithUNET
{
    /// <summary>
    /// Controls little bullets fired into the world.
    /// </summary>
    public class BulletController : NetworkBehaviour
    {
        public TextMesh tm;
        private void Start()
        {
            // The bullet's transform should be in local space to the Shared Anchor.
            // Make the shared anchor the parent, but we don't want the transform to try
            // to 'preserve' the position, so we set false in SetParent.
            transform.SetParent(SharedCollection.Instance.transform, false);

            // The rigid body has a velocity that needs to be transformed into 
            // the shared coordinate system.
            Rigidbody rb = GetComponentInChildren<Rigidbody>();
            rb.velocity = transform.parent.TransformDirection(rb.velocity*3);

            tm.text += transform.parent.name;
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("hit somthing");
            if (other.gameObject.tag == "Zombie") {
                Debug.Log("hit zomb");
                string uIdentity = other.transform.name;
                CmdWhatZombiGotHit(uIdentity, 10);
                Destroy(this.gameObject, 0.2f);
            }
        }


       [Command]
        void CmdWhatZombiGotHit(string uniqueID, int dmg)
        {
            GameObject go = GameObject.Find(uniqueID);
            go.GetComponent<Zombie_Health>().DeductHealth(dmg);
        }
    }
}
