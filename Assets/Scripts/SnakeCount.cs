using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnakeCount : MonoBehaviour {

    public Text myText;
    public int maxSnakes;

    int numSnakesInScene;

    void Update()
    {
        numSnakesInScene = GameObject.FindGameObjectsWithTag("Mother Snake").Length;
        setSnakeCount(numSnakesInScene);
    }

    public int getSnakeCount()
    {
        return numSnakesInScene;
    }

    public void setSnakeCount(int snakeCount)
    {
        myText.text = snakeCount.ToString().PadLeft(2, '0');
    }
}
