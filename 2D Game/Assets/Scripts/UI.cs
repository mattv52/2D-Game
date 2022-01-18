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
    public int keySpace = -50;
    private int numKeys = 0;

    // Add specific key to UI
    public void addKey(int key)
    {
        // Create key sprite obj and add as a child
        GameObject obj = new GameObject(key.ToString());
        obj.transform.parent = keysUI.transform;
        // Position in correct place
        obj.transform.localPosition = new Vector3(0, keySpace*numKeys);
        numKeys++;

        // Add sprite to image component
        Image img = obj.AddComponent<Image>();
        img.sprite = keys[key];
    }

    // Remove a specific key from UI and move up remaining if required
    public void removeKey(int key)
    {
        // Loop through keys to find desired one by comparing name
        for (int i=0; i<numKeys; i++)
        {

            GameObject x = keysUI.transform.GetChild(i).gameObject;
            // Once found, destroy it
            if (x.name == key.ToString())
            {
                Destroy(x);
                // If its not the last key, move the others up
                if (i != numKeys-1)
                {
                    for (int j = i; j < numKeys; j++) keysUI.transform.GetChild(j).transform.position -= new Vector3(0, keySpace);
                }
            }
        }
    }
}