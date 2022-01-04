using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public GameObject partsUI;
    // part sprites for render, 0=eng, 1=nose, 2=wngs
    public Sprite[] parts = new Sprite[3];
    public GameObject keysUI;
    // key sprites for render, 0=blue, 1=green, 2=red, 3=yellow
    public Sprite[] keys = new Sprite[4];

    private void addKey(int key)
    {
        SpriteRenderer sr = keysUI.AddComponent<SpriteRenderer>();
        sr.sprite = keys[key];
    }
}