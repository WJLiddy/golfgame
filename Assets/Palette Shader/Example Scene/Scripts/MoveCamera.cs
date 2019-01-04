using UnityEngine;

public class MoveCamera : MonoBehaviour {

    //Update.
    void Update() {
        transform.parent.eulerAngles += new Vector3(0, Time.deltaTime * 15, 0);
        transform.localPosition = new Vector3(Mathf.Sin(Time.fixedTime) * 12, Mathf.Sin(Time.fixedTime) * 5, Mathf.Cos(Time.fixedTime * 0.775f) * 12);
    }
}
