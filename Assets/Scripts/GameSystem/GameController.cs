using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public enum Season
{
    Spring, //March, April, May
    Summer, //June, July, August
    Fall, //September, October, November
    Winter //December, January, February
           //reference : https://weatherspark.com/h/s/26327/2020/0/Historical-Weather-Spring-2020-in-Worcester-Massachusetts-United-States
}

public enum Weather
{
    Sunny,
    Cloudy,
    Windy,
    Rainy,
    Snowy
}

public enum Tempurature
{
    Hot,
    Warm,
    Cold,
    Freezing
}
public class GameController : MonoBehaviour
{
    //Date Time System
    public int day;
    public float runSpeed;
    public DateTime currentDate;
    public Text currentDateInString;
    public Slider daytime;
    float daypass;

    //Weather System
    public Text currentSeasonInString;
    public Text currentWeatherInString;
    public Text currentTempuratureInString;

    Season currentSeason;
    Weather currentWeather;
    Tempurature currentTempurature;
    

    List<Weather> weatherLoot;
    List<Tempurature> tempuratureLoot;
    //Seasonal Weather and Temperature Weight
    int[] springWeatherLoot = { 0,0,0,1,1,2,2,3,3,4 };
    int[] summerWeatherLoot = { 0, 0, 0, 0, 0, 1, 2, 2, 3, 3 };
    int[] fallWeatherLoot = { 0, 0, 0, 1, 1, 2, 2, 3, 3, 4 };
    int[] winterWeatherLoot = {0,1,2,3,4,4,4,4,4,4};

    int[] springTempuratureLoot = {1,1,1,1,2,2,2,3,3};
    int[] summerTempuratureLoot = {0,0,0,0,0,0,0,1,1,2};
    int[] fallTempuratureLoot = { 0,0,0,1,1,1,2,2,3,3};
    int[] winterTempuratureLoot = {1,2,3,3,3,3,3,3,3};


    //Passenger System
    int totalPassenger = 0;
    int currentPassenger = 0;
    public Text currentPassengerInString;
    public Text totalPassengerInString;
    Passenger passenger;

    //Fare System
    float totalFare = 0f;
    float currentFare = 0f;
    float operationCost = 0f;
    float profit = 0f;
    public Text currentFareInString;
    public Text totalFareInString;
    public Text operationCostInString;
    public Text profitInString;
    Fare fare;


    // Start is called before the first frame update
    void Start()
    {
        currentDate = DateTime.Parse("2021-Jan-01");
        passenger = GetComponent<Passenger>();
        totalPassenger = 0;
        fare = GetComponent<Fare>();
        totalFare = 0;
        profit = 0;
    }

    void StartNewDay()
    {
        day += 1;
        currentDate+=TimeSpan.FromDays(1);
        currentDateInString.text = currentDate.ToString("yyyy/MM/dd");

        if(currentDate.Month==3|| currentDate.Month == 4 || currentDate.Month == 5)
        {
            currentSeason = Season.Spring;
            currentWeather = (Weather)springWeatherLoot[UnityEngine.Random.Range(0, springWeatherLoot.Length)];
            currentTempurature = (Tempurature)springTempuratureLoot[UnityEngine.Random.Range(0, springTempuratureLoot.Length)];
        }
        if (currentDate.Month == 6 || currentDate.Month == 7 || currentDate.Month == 8)
        {
            currentSeason = Season.Summer;
            currentWeather = (Weather)summerWeatherLoot[UnityEngine.Random.Range(0, summerWeatherLoot.Length)];
            currentTempurature = (Tempurature)summerTempuratureLoot[UnityEngine.Random.Range(0, summerTempuratureLoot.Length)];
        }
        if (currentDate.Month == 9 || currentDate.Month == 10 || currentDate.Month == 11)
        {
            currentSeason = Season.Fall;
            currentWeather = (Weather)fallWeatherLoot[UnityEngine.Random.Range(0, fallWeatherLoot.Length)];
            currentTempurature = (Tempurature)fallTempuratureLoot[UnityEngine.Random.Range(0, fallTempuratureLoot.Length)];
        }
        if (currentDate.Month == 12 || currentDate.Month == 1 || currentDate.Month == 2)
        {
            currentSeason = Season.Winter;
            currentWeather = (Weather)winterWeatherLoot[UnityEngine.Random.Range(0, winterWeatherLoot.Length)];
            currentTempurature = (Tempurature)winterTempuratureLoot[UnityEngine.Random.Range(0, winterTempuratureLoot.Length)];
        }
        currentSeasonInString.text = currentSeason.ToString();
        currentWeatherInString.text = currentWeather.ToString();
        currentTempuratureInString.text = currentTempurature.ToString();

        currentPassenger = passenger.PassengerCalculator(currentDate,currentSeason,currentWeather,currentTempurature);
        totalPassenger += currentPassenger;
        currentPassengerInString.text = currentPassenger.ToString();
        totalPassengerInString.text = totalPassenger.ToString();

        currentFare = fare.FareCalculator(currentPassenger);
        totalFare += currentFare;
        if(currentDate.Day == 2)
        {
            operationCost += fare.operationCostPerMonth;
            profit -= operationCost;
        }
        profit += currentFare;
        currentFareInString.text = currentFare.ToString();
        totalFareInString.text = totalFare.ToString();
        operationCostInString.text = operationCost.ToString();
        profitInString.text = profit.ToString();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        daypass += Time.deltaTime;
        
        if (daypass >= runSpeed)
        {
            StartNewDay();
            daypass = 0;
        }
    }

    public void UpdateRunSpeed()
    {
        runSpeed = 1f/daytime.value;
    }
}

