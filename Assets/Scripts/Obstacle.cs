using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Vector3 startingpos;
    const float tau = Mathf.PI * 2;
    
    [SerializeField] Vector3 movvec;
    float movfac;
    public float period = 2f;
    // [SerializeField] [Range(0,1)] float f = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        startingpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
         float cycles = Time.time / period;
         float rawSine = Mathf.Sin(cycles * tau);
        // movfac = (rawSine + 1f) / 2f;
        // Vector3 offset = movvec * movfac;
        transform.position = Vector3.Lerp(startingpos,startingpos+movvec,(Mathf.Sin(rawSine)+1)/2);
    }
}
