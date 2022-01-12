using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChickenFarm
{
    public class CollectingTrigger : MonoBehaviour
    {
        private EggCollectionManager _eggCollectionManager;
        private AudioSource _correctAudio;

        void Start()
        {
            _eggCollectionManager = GameObject.FindGameObjectWithTag("EggCollectionManager").GetComponent<EggCollectionManager>();
            _correctAudio = GetComponent<AudioSource>();
        }

        private void OnTriggerEnter(Collider egg)
        {
            if (egg.gameObject.tag == "Egg" && !egg.gameObject.GetComponent<EggTrigger>().isCollected)
            {
                _eggCollectionManager.ReleaseEgg(egg.gameObject);
                egg.gameObject.GetComponent<EggTrigger>().isCollected = true;
                _correctAudio.Play();
            }
        }
    }
}

