using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float speed;
    public GameManager manager;

    Material m;
    float offset;
    // Start is called before the first frame update
    void Start()
    {
        m = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.isPlaying())
        {
            offset = offset + Time.deltaTime;
            m.mainTextureOffset = new Vector2(offset * speed, 0);
        }


    }
       
}
