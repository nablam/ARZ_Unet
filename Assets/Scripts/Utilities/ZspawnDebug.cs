using HoloToolkit.Examples.SharingWithUNET;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZspawnDebug : MonoBehaviour {

    TextMesh[] texts;
	void Start () {
        texts = GetComponentsInChildren<TextMesh>();
        //transform.SetParent(SharedCollection.Instance.transform, false);

    }

    // Update is called once per frame
    void Update () {
        //for (int x = 0; x < texts.Length; x++) {
        //    texts[x].text = " " + x;
        //}

        texts[0].text = this.transform.localPosition.ToString();
        texts[1].text = this.transform.position.ToString();
        texts[2].text = SharedCollection.Instance.transform.localPosition.ToString();
        texts[3].text = SharedCollection.Instance.transform.position.ToString();
    }
}
