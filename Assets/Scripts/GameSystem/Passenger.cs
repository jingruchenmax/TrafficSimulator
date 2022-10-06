using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passenger : MonoBehaviour
{
    public int basicRidership = 1000;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Season, weather, temparature
    /* -Increase in the number of tickets sold by up to 5% when it rains on weekdays.
       -Increase in the number of tickets sold with decreasing temperatures on weekdays(up to 30% on extremely cold days with temperatures <-5°C.
       -Increase in the number of tickets sold with increasing temperatures on Sundays under dry conditions(12% increase between 0°C and 20°C).
       -Wet and cold conditions lead to the highest/lowest ticket sales on weekdays/Sundays, respectively.
       -Increase in ticket sales with increasing temperatures during the night on all days*/
    //reference: https://iopscience.iop.org/article/10.1088/1748-9326/ab8ec3 for Berlin
    //needs to change to Worcester
    public float NatureImpact(DateTime _date, Season _season, Weather _weather, Tempurature _tempurature)
    {
        float seasonImpact = 1.0f;

        // Weekend
        if (_date.DayOfWeek == DayOfWeek.Saturday || _date.DayOfWeek == DayOfWeek.Sunday)
        {
            //warm +12%
            if (_tempurature == Tempurature.Warm)
            {
                seasonImpact += 0.12f;
            }
        }
        else // Weekday
        {
            if(_weather == Weather.Rainy)
            {
                seasonImpact += 0.05f;
            }

            //cold +15%; freezing +30%;
            if(_tempurature == Tempurature.Cold)
            {
                seasonImpact += 0.15f;
            }
            if(_tempurature == Tempurature.Freezing)
            {
                seasonImpact += 0.3f;
            }
            
        }
        return seasonImpact;
    }

    //Fare, walking distance to bus stop, ...
    public float TransporationImpact()
    {
        float transImpact = 1.0f;
        return transImpact;
    }

    //Spetial events, holiday, ...
    public float OtherImpact()
    {
        float otherImpact = 1.0f;
        return otherImpact;
    }

    public int PassengerCalculator(DateTime _date, Season _season, Weather _weather, Tempurature _tempurature)
    {
        float ridership = 0;
        float natureImp = NatureImpact(_date, _season, _weather, _tempurature);
        float transImp = TransporationImpact();
        float otherImp = OtherImpact();
        ridership = basicRidership * natureImp * transImp * otherImp;
        return (int)ridership;
    }

}
