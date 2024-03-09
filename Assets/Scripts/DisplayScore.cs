
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] Text State;
    private void Start()
    {
        text.text = "Your Score: " + GameValues.finalScore.ToString();
        if (Enumerations.getInstance() == Enumerations.UIState.Losing)
        {
            State.text = "You Lost";
            State.color = Color.red;
        }
        else
        {
            State.text = "You Won";
            State.color = Color.green;
        }
    }
}
