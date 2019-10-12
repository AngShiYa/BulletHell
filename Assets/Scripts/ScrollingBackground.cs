using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public GameObject[] backgrounds;
    public float speed;

    private int currentBackground;
    private float bgLength;
    private float offset;

    // Start is called before the first frame update
    void Start()
    {
        currentBackground = 0;
        bgLength = backgrounds[0].GetComponent<SpriteRenderer>().size.y;
        offset = bgLength * (backgrounds.Length - 1);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < backgrounds.Length; ++i) {
            backgrounds[i].transform.position -= new Vector3(0, speed, 0);
        }

        if (backgrounds[currentBackground].transform.position.y < -bgLength) {
            int nextBackground = (currentBackground + 1) % backgrounds.Length;
            backgrounds[currentBackground].transform.position = backgrounds[nextBackground].transform.position + new Vector3(0, offset, 0);
            currentBackground = nextBackground;
        }
    }
}
