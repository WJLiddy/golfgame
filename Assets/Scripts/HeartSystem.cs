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
    void Awake ()
    {
        heartSprites = Resources.LoadAll<Sprite>("ui/heartsprites");
        shownObjects = new List<GameObject>();
        heartPrefab = Instantiate(Resources.Load<GameObject>("ui/heartprefab"));
    }

    private void clearHeartElements()
    {
        if(shownObjects == null)
        {
            return;
        }
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

    public void hurt()
    {
        setHeartPieceCount(heartPieces - 1);
    }

    public void setMaxHeartCount(int count)
    {
        maxHearts = count;
        clearHeartElements();
        reDraw();
    }

    void reDraw()
    {
        if (shownObjects == null)
        {
            return;

        }
        for (int i = 0; i != maxHearts; ++i)
        {
            var heart = Instantiate(heartPrefab);
            heart.transform.SetParent(this.transform);
            heart.transform.localPosition = firstHeartLoc.transform.localPosition + new Vector3(i * 40 + -(40 / 2), -(33 / 2), 0);
            heart.transform.localScale = Vector3.one;
            shownObjects.Add(heart);

            if(heartPieces >= ((i+1) * 4))
            {
                // full
                heart.GetComponent<UnityEngine.UI.Image>().sprite = heartSprites[4];

            }
            else if(heartPieces < (i * 4))
            {
                //empty
                heart.GetComponent<UnityEngine.UI.Image>().sprite = heartSprites[0];
            }
            else
            {
                heart.GetComponent<UnityEngine.UI.Image>().sprite = heartSprites[heartPieces % 4];
            }
        }
    }
}
