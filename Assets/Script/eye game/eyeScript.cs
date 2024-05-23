using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyeScript : MonoBehaviour
{
    public EyeManager eyeManager;
    public Transform dropSpawnPoint;
    public GameObject dropPrefab;
    public float dropSpeed;
    [SerializeField]
    private float _frequency;
    [SerializeField]
    private float _magnitude;
    private Vector3 _startPosition;
    public float life;
    public Animator animator;

    void Start()
    {
        _startPosition = new Vector3(0, 3f, 0);
        StartCoroutine("Attack");

    }


    void Update()
    {
        transform.localPosition = _startPosition + Vector3.right * Mathf.Sin(_frequency *Time.time) * _magnitude;

        if(life <=0)
        {
            animator.SetBool("death", true);
            StopCoroutine(Attack());
            StartCoroutine(eyeManager.Dead());
        }
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(3f);
        while (true)
        {
            animator.SetTrigger("attack");
            var drop = Instantiate(dropPrefab, dropSpawnPoint.position, dropSpawnPoint.rotation);
            drop.GetComponent<Rigidbody2D>().velocity = dropSpawnPoint.up * dropSpeed * -1;



            yield return new WaitForSeconds(2f);
        }
       
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        life--;
        print(life);
    }

}
