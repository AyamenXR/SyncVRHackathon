using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FpsDisplay : MonoBehaviour
{
    public TextMeshProUGUI FpsText;
    private int frameCount;
    private float prevTime;
    private float fps;

    // Start is called before the first frame update
    void Start()
    {
        frameCount = 0;
        prevTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        frameCount++;
        float time = Time.realtimeSinceStartup - prevTime;

        if (time >= 0.5f)
        {
            fps = frameCount / time;
            FpsText.text = "FPS: " + fps.ToString();

            frameCount = 0;
            prevTime = Time.realtimeSinceStartup;
        }
    }
}
