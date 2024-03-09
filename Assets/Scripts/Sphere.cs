using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sphere : MonoBehaviour
{
   // public bool isFlat = true;
    private Rigidbody rb;
    Vector3 tilt;
    public float speed = 5f;
    Vector3 xforce;
    Vector3 yforce;
    GameObject GameManagerr;
    public float sphspeed = 10f;
    float factor;
    [SerializeField] AudioClip audiod, audiof;//audioh;
    AudioSource Asource;
    // Start is called before the first frame update
    void Start()
    {
        rb =GetComponent<Rigidbody>();
        xforce= new Vector3(0f, 0, speed);
        yforce= new Vector3(speed, 0f, 0f);
        GameManagerr = GameObject.FindGameObjectWithTag("GameController");
        Asource = GameManagerr.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SystemInfo.deviceType==DeviceType.Handheld)
        {
            factor = sphspeed + 10 * GameValues.sliderfact;
            tilt = Input.acceleration;
             tilt = Quaternion.Euler(90, 0, 0)*tilt;
            
            rb.AddForce(-tilt.z * factor, 0,tilt.x * factor);
        }
        else
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                rb.AddForce(xforce);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rb.AddForce(-xforce);
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                rb.AddForce(-yforce);
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                
                rb.AddForce(yforce);
            }
        }
     
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Danger"))
        {
            Asource.clip = audiod;
            Asource.Play();
            GameManager.timeSpent += GameValues.penalize;
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            Asource.clip = audiof;
            Asource.Play();
            GameValues.finalScore = Mathf.Max(0, GameValues.levelMaxTime - GameManager.timeSpent) * GameValues.levelScore;
            if (GameValues.finalScore == 0)
            {
                Enumerations.SetInstance(Enumerations.UIState.Losing);
            }
            else
            {
                Enumerations.SetInstance(Enumerations.UIState.Winning);
            }
            SceneManager.LoadScene(2);
        }
        //if (collision.gameObject.CompareTag("Walls"))
        //{
        //    Asource.clip = audioh;
        //    Asource.Play();
        //}
    }
}
