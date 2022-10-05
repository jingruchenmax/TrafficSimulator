using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SpriteMapAuto : MonoBehaviour
{
    public Sprite[] mapSegs;

    // Start is called before the first frame update
    void Start()
    {
        if (this.transform.childCount<mapSegs.Length)
        for (int i=0;i<mapSegs.Length;i++)
        {
            GameObject temp = new GameObject();
            temp.transform.parent = this.transform;
            temp.transform.position = new Vector3((i % 10) * 10.8f, -(i / 10) * 13.8f, 0);
            temp.AddComponent<SpriteRenderer>();
            temp.GetComponent<SpriteRenderer>().sprite = mapSegs[i];
        }

    }


}
