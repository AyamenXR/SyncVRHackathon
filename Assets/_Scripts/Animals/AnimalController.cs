using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    public float walkSpeed = 0.5f;

    private Animator _animator;
    private GameManager gameManager;
    private bool _isWalking;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        IdleAndWalk();
        //gameManager.onStartActivated.AddListener(Walk);
    }

    private void FixedUpdate()
    {
        if (_isWalking)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * walkSpeed);
        }

    }

    private void IdleAndWalk()
    {
        StartCoroutine(WaitAndWalk());
    }

    private IEnumerator WaitAndWalk()
    {
        while (true)
        {
            float randomSec = Random.Range(5, 15);
            yield return new WaitForSeconds(randomSec);

            //if (!_animator.GetBool("Eat"))
            //{
                _animator.SetBool("Walk", true);
                _isWalking = true;

                yield return new WaitForSeconds(3);

                _animator.SetBool("Walk", false);
                _isWalking = false;
            //}

        }

    }

}
