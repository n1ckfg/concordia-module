using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LatkOscSender : MonoBehaviour {

    public OSC osc;
    public SolarSystem solarSystem;
    public float sendInterval = 1f;

    IEnumerator Start() {
        foreach (LineRenderer line in solarSystem.lines) {
            Vector3[] points = new Vector3[line.positionCount];
            line.GetPositions(points);
            foreach (Vector3 point in points) {
                OscMessage msg = new OscMessage;
                msg.address = "/foo";
                osc.Send(msg);
                Debug.Log(point);
            }
        }

        yield return new WaitForSeconds(sendInterval);
    }
    
}
