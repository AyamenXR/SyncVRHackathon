using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace ChickenFarm {
    public class FpsDisplay : MonoBehaviour
    {
        public TextMeshProUGUI FpsText;
        private int frameCount;
        private float prevTime;
        private float fps;

        void Start()
        {
            frameCount = 0;
            prevTime = 0.0f;
        }

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
}

