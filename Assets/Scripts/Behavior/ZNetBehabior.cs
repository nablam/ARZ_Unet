using HoloToolkit.Examples.SharingWithUNET;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ZombieState
{
    IDLE,
    WALKING,
    CHASING,
    ATTACKING,
    DEAD,
    PAUSED,
    REACHING,
};

public class ZNetBehabior : MonoBehaviour {

    [HideInInspector]
    public ZombieState state { get; private set; }

    Rigidbody rb;
    CapsuleCollider cc;
    Animator[] animator;
    public TextMesh tm;


    float moveSpeed;                // movement speed
    float multiplier = 1.0f;        // multiplier of animation speed
    int deathType = 0;              // deathType for animator
    int reachType = 0;
    ZombieState lastState;

    // Use this for initialization
    void Awake () {
        state = ZombieState.CHASING;
        rb = gameObject.GetComponent<Rigidbody>();
        cc = GetComponent<CapsuleCollider>();
        animator = GetComponentsInChildren<Animator>();
        transform.SetParent(SharedCollection.Instance.transform, false);
        //tm = GetComponentInChildren<TextMesh>();
        tm.text =transform.parent.name;
    }


    void UpdateAnimation()
    {
        for (int i = 0; i < animator.Length; i++)
        {
            animator[i].SetInteger("state", (int)state);
            animator[i].SetFloat("multiplier", multiplier);
            animator[i].SetInteger("deathType", deathType);
            animator[i].SetInteger("reachType", reachType);
        }
    }

    // Update is called once per frame
    void Update () {
        UpdateAnimation();
    }

    public void AddTOtextMesh(string argStr) {
        tm.text += " " +argStr;
    }
}
