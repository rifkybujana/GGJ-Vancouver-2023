using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorListHolder : MonoBehaviour
{
    public bool activated;

    public Slider cooldownSlider;
    public List<Image> colorList;

    // Start is called before the first frame update
    void Start()
    {
        activated = false;

        cooldownSlider.gameObject.SetActive(false);
        foreach (Image c in colorList)
        {
            c.gameObject.SetActive(false);
        }
    }

    public void Activated()
    {
        // cooldownSlider.gameObject.SetActive(true);
        activated = true;
    }
}
