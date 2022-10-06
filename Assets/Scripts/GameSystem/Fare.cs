using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fare : MonoBehaviour
{
    public float transporataionFare = 1.75f; // Reference: https://www.therta.com/fare/
    public float operationCostPerMonth = 10000; // per month
                                // TODO:needs to check reference

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float FareCalculator(int _ridership)
    {
        return _ridership * transporataionFare;
    }

}
