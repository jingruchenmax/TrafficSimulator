using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapController : MonoBehaviour
{
    public GameObject streetMap;
    public GameObject routeMap;

    //condition 0 - street map, 1 - WRTA system Map
    // Start is called before the first frame update
    void Start()
    {
        streetMap.SetActive(true);
        routeMap.SetActive(false);
    }

    public void SwitchState(int value)
    {
        if (value == 0)
        {
            streetMap.SetActive(true);
            routeMap.SetActive(false);
        }
        if (value == 1)
        {
            streetMap.SetActive(false);
            routeMap.SetActive(true);
        }
    }
}
