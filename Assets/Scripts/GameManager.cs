using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static float timeSpent=0;
   [SerializeField] Text pause;
    private void Update()
    {
        if (Enumerations.getInstance() == Enumerations.UIState.Playing)
        {
            timeSpent += Time.deltaTime;
           // Score.text=timeSpent.ToString();

        }
    }
   public void moveToPause()
    {
        if (Enumerations.getInstance() == Enumerations.UIState.Playing)
        {
            Time.timeScale = 0;
            Enumerations.SetInstance(Enumerations.UIState.Pause);
            pause.text = "Play";
        }
        else
        {
            Time.timeScale = 1;
            Enumerations.SetInstance(Enumerations.UIState.Playing);
            pause.text = "Pause";
        }
    }
}
