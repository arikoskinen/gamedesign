using UnityEngine;
using System.Collections;

// Background mover Script

public class bgmover : MonoBehaviour
{
    public GameObject background;
    public float bgspeed = 0.16f;
    public float bgx;
    public float bgy;


    void Start()
    {
        // Start position.... (...)
        bgx = background.transform.position.x;
        bgy = background.transform.position.y;
    }

    void Update()
    {


        if (bgy > -3.0f)
        {
            background.transform.position = new Vector2(bgx, bgy - Time.deltaTime * bgspeed);

            bgx = background.transform.position.x;
            bgy = background.transform.position.y;

        }
        else
        {

            // "back to start"... quick solution

            gameObject.transform.position = new Vector2(bgx, bgy * Time.deltaTime * bgspeed);

            bgx = background.transform.position.x;
            bgy = background.transform.position.y;
        }

    }
}
