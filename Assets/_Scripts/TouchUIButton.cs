using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TouchUIButton : MonoBehaviour
{
    public UnityEvent onClick;
    //public UnityEvent closeThisUi;
    public bool isTouched;

    private void OnTriggerEnter(Collider other)
    {
        if (!isTouched)
        {
            if (other.gameObject.CompareTag("RightHand") || other.gameObject.CompareTag("LeftHand"))
            {
                isTouched = true;
                StartCoroutine(WaitAndInvoke());
            }
        }

    }
    private IEnumerator WaitAndInvoke()
    {
        this.gameObject.GetComponent<Image>().enabled = false;
        this.gameObject.GetComponent<Collider>().enabled = false;
        this.gameObject.GetComponentInChildren<TextMeshProUGUI>().enabled = false;
        //closeThisUi.Invoke();
        yield return new WaitForSeconds(1f);
        onClick.Invoke();
    }
}
