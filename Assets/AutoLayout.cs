using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class AutoLayout : MonoBehaviour
{
    // Start is called before the first frame update
    public int space = 5;
    void Start()
    {
        GetComponent<RectTransform>().sizeDelta = new Vector2(transform.GetChild(0).GetComponent<RectTransform>().rect.width, transform.childCount * (transform.GetChild(0).GetComponent<RectTransform>().rect.height + space));
    }

}
