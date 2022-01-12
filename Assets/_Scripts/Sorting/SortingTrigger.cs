using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChickenFarm
{
    public class SortingTrigger : MonoBehaviour
    {
        public string triggerTag;
        private SortingManager _sortingManager;
        private AudioSource _correctAudio;

        void Start()
        {
            triggerTag = this.gameObject.tag;
            _sortingManager = GameObject.FindGameObjectWithTag("SortingManager").GetComponent<SortingManager>();
            _correctAudio = GetComponent<AudioSource>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (triggerTag == "SortingChick" && other.gameObject.tag == "Chick")
            {
                SortAnimal(other);
            }
            if (triggerTag == "SortingChicken" && other.gameObject.tag == "Chicken")
            {
                SortAnimal(other);
            }
        }

        private void SortAnimal(Collider animal)
        {
            if (!animal.gameObject.GetComponent<AnimalTrigger>().isSorted)
            {
                _sortingManager.ReleaseAnimal(animal.gameObject);
                animal.gameObject.GetComponent<AnimalTrigger>().isSorted = true;
                _correctAudio.Play();
            }
        }
    }

}
