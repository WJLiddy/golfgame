using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSystem : MonoBehaviour
{
    Sprite[] heartSprites;
    List<GameObject> shownObjects;
    GameObject heartPrefab;
    public GameObject firstHeartLoc;

    int maxHearts;
    int heartPieces;
    // Use this for initialization
    void Start ()
    {
        heartSprites = Resources.LoadAll<Sprite>("heartsprites");
        shownObjects = new List<GameObject>();
        heartPrefab = Instantiate(Resources.Load<GameObject>("ui/heartprefab"));
    }

    private void clearHeartElements()
    {
        foreach (GameObject go in shownObjects)
        {
            Destroy(go);
        }
        shownObjects = new List<GameObject>();
    }

    public void setHeartPieceCount(int parts)
    {
        heartPieces = parts;
        clearHeartElements();
        reDraw();
    }

    public void setMaxHeartCount(int count)
    {
        maxHearts = count;
        clearHeartElements();
        reDraw();
    }

    void reDraw()
    {
        for(int i = 0; i != maxHearts; ++i)
        {
            var heart = Instantiate(heartPrefab);
            heart.transform.SetParent(this.transform);
            heart.transform.localPosition = firstHeartLoc.transform.localPosition + new Vector3(i * 40 + -(40 / 2), -(33 / 2), 0);
            heart.transform.localScale = Vector3.one;
            shownObjects.Add(heart);
            //heart.
        }
    }
}
