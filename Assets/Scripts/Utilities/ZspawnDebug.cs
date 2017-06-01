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
        texts[0].text ="inv pos"+ SharedCollection.Instance.transform.InverseTransformPoint(this.transform.position).ToString();
        texts[1].text ="inv loc"+ SharedCollection.Instance.transform.InverseTransformPoint(this.transform.localPosition).ToString();
        texts[2].text = "loc="+this.transform.localPosition.ToString() + "  sharedloc" + SharedCollection.Instance.transform.localPosition.ToString();
        texts[3].text = "pos="+this.transform.position.ToString()+ " sharedpos" + SharedCollection.Instance.transform.position.ToString(); ;
    }
}
