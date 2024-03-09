using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SLider : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Text text;

    private void Start()
    {
        slider.onValueChanged.AddListener((v) =>
        {
            text.text = v.ToString("0.00");
            GameValues.sliderfact = v;
        });
    }
    public void movetoGame()
    {
        SceneManager.LoadScene(1);
        Enumerations.SetInstance(Enumerations.UIState.Playing);
    }

}
