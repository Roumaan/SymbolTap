using UnityEngine;
using System.Collections;

public class EndlessModeGameOverController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    GameObject recordSaver = GameObject.Find("RecordSaver");
        recordSaver.GetComponent<RecordSaver>().post();
	}
}
