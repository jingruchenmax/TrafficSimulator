using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System;

public class BusRouteManager : MonoBehaviour
{
    public List<BusRoute> busRouteValues;
    public List<BusRouteRenderer> busRouteRenderers;
    public string file = "New "+ DateTime.Now.ToString("yy-mm-dd");
    public void AddBusStop(int routeID, Transform point)
    {
        List<Vector2> stops = new List<Vector2>();
        bool isExist = false;
        foreach (BusRoute br in busRouteValues)
        {
            if (br.id == routeID)
            {
                br.stops.Add(point);
                isExist = true;
            }
        }
        if (isExist == false)
        {
            busRouteValues.Add(new BusRoute(routeID,point));
        }
    }

    private void Start()
    {


    }


    public void SaveRoutes(string fileName)
    {
        string json = JsonConvert.SerializeObject(busRouteValues);
        Debug.Log(json);
        File.WriteAllText(Application.streamingAssetsPath + "/" + fileName + ".json", json);
    }

    public void LoadRoutes(string fileName)
    {
        string json = File.ReadAllText(Application.streamingAssetsPath + "/" + fileName + ".json");
        busRouteValues = JsonConvert.DeserializeObject<List<BusRoute>>(json);
    }


    private void OnApplicationQuit()
    {
      //  SaveRoutes(file);
    }


}
[Serializable]
public class BusRoute{
    public int id;
    public List<Transform> stops = new List<Transform>();
    public BusRoute(int id, Transform stop)
    {
        this.id = id;
        this.stops.Add(stop);
    }
}

