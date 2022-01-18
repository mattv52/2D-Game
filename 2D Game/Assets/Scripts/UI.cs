using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject partsUI;
    // part sprites for render, 0=eng, 1=nose, 2=wngs
    public Sprite[] parts = new Sprite[3];
    public GameObject keysUI;
    // key sprites for render, 0=blue, 1=green, 2=red, 3=yellow
    public Sprite[] keys = new Sprite[4];
    private int numKeys = 0;

    // Start is called before the first frame update
    private void Start()
    {
        addKey(2);
        addKey(3);
    }
    private void addKey(int key)
    {
        // Create key sprite obj and add as a child
        GameObject obj = new GameObject();
        obj.transform.parent = keysUI.transform;

        // Position in correct place
        obj.transform.position = new Vector3(0f, -50f*numKeys);

        // Add sprite to image component
        Image img = obj.AddComponent<Image>();
        img.sprite = keys[key];
    }
}