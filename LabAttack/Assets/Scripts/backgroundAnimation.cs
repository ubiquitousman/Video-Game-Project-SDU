using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class backgroundAnimation : MonoBehaviour
{
    public Sprite[] animatedImages;
    public SpriteRenderer animateImagebg;
    // Update is called once per frame
    void Update()
    {
        animateImagebg.sprite = animatedImages[(int)(Time.time * 10) % animatedImages.Length];
    }
}
