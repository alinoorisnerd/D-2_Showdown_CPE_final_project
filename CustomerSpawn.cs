using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CustomerSpawn : MonoBehaviour
{
    // Inspector variables
    public GameObject[] customers;

    public TextMeshProUGUI orderText;
    public TextMeshProUGUI scoreText;

    // Variables to store customer order and score
    private int orderValue;
    private int score = 300;

    // Reference to FoodChecker script
    public FoodChecker foodChecker;

    private void Start()
    {
        // Find and store the FoodChecker script
        foodChecker = FindObjectOfType<FoodChecker>();

        // Spawn the first customer when the game starts
        SpawnCustomer();
    }

    private void Update()
    {
        // Reduce score every 10 seconds
        if (Time.time % 10 == 0)
        {
            ReduceScore(10);
        }
    }

    // Function to spawn a new customer
    private void SpawnCustomer()
    {
        // Randomly select a customer from the array
        int randomIndex = Random.Range(0, customers.Length);
        GameObject customer = Instantiate(customers[randomIndex], new Vector3(12.3f, 0.06f, 33f), Quaternion.identity);

        // Generate a random order for the customer
        GenerateRandomOrder();

        // Display the order text
        DisplayOrderText();

        // Display the initial score
        DisplayScoreText();

        // Assign the FoodChecker script reference
        foodChecker = FindObjectOfType<FoodChecker>();

        // Call AddObjectToFoodValue for each ingredient in the order
        if (orderValue >= 1000)
        {
            foodChecker.AddObjectToFoodValue(foodChecker.cheese);
        }

        if (orderValue >= 100)
        {
            foodChecker.AddObjectToFoodValue(foodChecker.ham);
        }

        foodChecker.AddObjectToFoodValue(foodChecker.topBun);
        foodChecker.AddObjectToFoodValue(foodChecker.bottomBun);
    }

    // Function to generate a random order
    private void GenerateRandomOrder()
    {
        // Randomly generate values for each component of the order
        int topBunValue = Random.Range(0, 2); // 0 or 1
        int cheeseValue = Random.Range(0, 2); // 0 or 1
        int hamValue = Random.Range(0, 4);   // 0, 1, 2, or 3
        int friesValue = Random.Range(0, 2);  // 0 or 1

        // Construct the order value based on the randomly generated values
        orderValue = topBunValue * 1000 + cheeseValue * 100 + hamValue * 10 + friesValue * 1;
    }

    // Function to display the order text
    private void DisplayOrderText()
    {
        // Display order based on the orderValue
        string orderString = "";

        if (orderValue < 11000)
        {
            orderString = "1 top bun";
            if (orderValue == 0)
            {
                orderString += "\nNo cheese";
            }
            else if (orderValue >= 1000)
            {
                int numThousands = orderValue / 1000;
                orderString += $"\n{numThousands} cheese";
            }

            if (orderValue >= 100)
            {
                int numHundreds = (orderValue % 1000) / 100;
                orderString += $"\n{numHundreds} hams";
            }

            orderString += "\n1 bottom bun";

            if (orderValue % 10 == 1)
            {
                orderString += "\n1 fries";
            }
            else if (orderValue % 10 == 0)
            {
                orderString += "\nNo fries";
            }
        }

        orderText.text = orderString;
    }

    // Function to reduce the score
    private void ReduceScore(int amount)
    {
        score -= amount;
        DisplayScoreText();
    }

    // Function to display the score text
    private void DisplayScoreText()
    {
        scoreText.text = $"Score: {score}";
    }

    // Function to get the order value
    public int GetOrderValue()
    {
        return orderValue;
    }
}
