using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public int spacing = -50;

    public GameObject partsUI;
    // part sprites for render, 0=eng, 1=nose, 2=wngs
    public Sprite[] parts = new Sprite[3];
    private int numParts = 0;
    
    public GameObject keysUI;
    // key sprites for render, 0=blue, 1=green, 2=red, 3=yellow
    public Sprite[] keys = new Sprite[4];
    private int numKeys = 0;

    // Add specific part to UI
    public void addPart(int part)
    {
        // Create part sprite obj and add as a child
        GameObject obj = new GameObject(part.ToString());
        obj.transform.parent = partsUI.transform;
        obj.transform.localScale = new Vector3(parts[part].rect.width/100, parts[part].rect.height/100);

        // Position in correct place
        obj.transform.localPosition = new Vector3(0, 2*spacing*numParts);
        numParts++;

        // Add sprite to image component
        Image img = obj.AddComponent<Image>();
        img.sprite = parts[part];
    }
    
    // Remove all parts from UI
    public void removeParts()
    {
        for (int i = 0; i < numKeys; i++) Destroy(partsUI.transform.GetChild(i).gameObject);
        numParts = 0;
    }

    // Add specific key to UI
    public void addKey(int key)
    {
        // Create key sprite obj and add as a child
        GameObject obj = new GameObject(key.ToString());
        obj.transform.parent = keysUI.transform;
        
        // Position in correct place
        obj.transform.localPosition = new Vector3(0, spacing*numKeys);
        numKeys++;

        // Add sprite to image component
        Image img = obj.AddComponent<Image>();
        img.sprite = keys[key];
    }

    // Remove a specific key from UI and move up remaining if required
    public void removeKey(int key)
    {
        // Loop through keys to find desired one by comparing name
        for (int i = 0; i < numKeys; i++)
        {
            GameObject x = keysUI.transform.GetChild(i).gameObject;
            // Once found, destroy it
            if (x.name == key.ToString())
            {
                Destroy(x);
                numKeys--;
                
                // If its not the last key, move the others up
                if (i != numKeys)
                {
                    for (int j = i; j < numKeys+1; j++) keysUI.transform.GetChild(j).transform.position -= new Vector3(0, spacing);
                }
            }
        }
    }
}