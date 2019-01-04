using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ApplyPalettes : MonoBehaviour {

    //Properties.
    public Toggle[] toggles;
    public GameObject[] paletteShaders;

    //Start.
    void Start() {

        //Disable all cameras except the one without a palette shader to begin with.
        for (int i = 0; i < paletteShaders.Length; i++)
            paletteShaders[i].SetActive(i == 0);
    }

    //Called when a palette checkbox is checked - enable the game object that contains that palette.
    public void setPalette(bool isOn) {
        for (int i = 0; i < toggles.Length; i++)
            if (toggles[i] == EventSystem.current.currentSelectedGameObject.GetComponent<Toggle>()) {
                for (int j = 0; j < paletteShaders.Length; j++)
                    paletteShaders[j].SetActive(i == j);
                break;
            }
    }
}
