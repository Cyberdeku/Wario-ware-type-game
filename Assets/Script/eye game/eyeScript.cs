//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class eyeScript : MonoBehaviour
//{
//    public EyeManager eyeManager;
//    public Transform dropSpawnPoint;
//    public GameObject dropPrefab;
//    public float dropSpeed;
//    [SerializeField]
//    private float _frequency;
//    [SerializeField]
//    private float _magnitude;
//    private Vector3 _startPosition;
//    public float life;
//    public Animator animator;
//    public bool isDead =false;


//    private void OnEnable()
//    {
//        life = 1f;
//        isDead = false;
//        animator.SetBool("death", isDead);
//        _startPosition = new Vector3(0, 3f, 0);
//        StartCoroutine("Attack");
//    }
//    //void Start()
//    //{
//    //    _startPosition = new Vector3(0, 3f, 0);
//    //    StartCoroutine("Attack");

//    //}


//    void Update()
//    {
//        transform.localPosition = _startPosition + Vector3.right * Mathf.Sin(_frequency *Time.time) * _magnitude;

//        if(life<=0)
//        {
//            isDead = true;
//            animator.SetBool("death", isDead);
//            StartCoroutine(eyeManager.Win());
//        }
//    }

//    IEnumerator Attack()
//    {
//        yield return new WaitForSeconds(3f);
//        while (!isDead)
//        {
//            animator.SetTrigger("attack");
//            var drop = Instantiate(dropPrefab, dropSpawnPoint.position, dropSpawnPoint.rotation);
//            drop.GetComponent<Rigidbody2D>().velocity = dropSpawnPoint.up * dropSpeed * -1;



//            yield return new WaitForSeconds(2f);
//        }

//    }


//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        if(collision.gameObject.tag=="drop")
//        {
//            life--;
//        }

//    }

//}
using System.Collections;
using UnityEngine;

public class EyeScript : MonoBehaviour
{
    public EyeManager eyeManager;
    public Transform dropSpawnPoint;
    public GameObject dropPrefab;
    public float dropSpeed;
    [SerializeField] private float _frequency;
    [SerializeField] private float _magnitude;
    private Vector3 _startPosition;
    public float life;
    public Animator animator;
    public bool isDead = false;

    private void OnEnable()
    {
        life = 1f;
        isDead = false;
        if (animator != null)
        {
            animator.SetBool("death", isDead);
        }
        _startPosition = new Vector3(0, 3f, 0);
        StartCoroutine(AttackRoutine());
    }

    void Update()
    {
        if (Time.timeScale == 0)
            return;

        MoveEye();
        CheckLife();
    }

    private void MoveEye()
    {
        transform.localPosition = _startPosition + Vector3.right * Mathf.Sin(_frequency * Time.time) * _magnitude;
    }

    private void CheckLife()
    {
        if (life <= 0 && !isDead)
        {
            isDead = true;
            if (animator != null)
            {
                animator.SetBool("death", isDead);
            }
            StartCoroutine(eyeManager.Win());
        }
    }

    private IEnumerator AttackRoutine()
    {
        yield return new WaitForSeconds(3f);
        while (!isDead)
        {
            if (Time.timeScale == 0)
            {
                yield return null;
                continue;
            }

            if (animator != null)
            {
                animator.SetTrigger("attack");
            }
            SpawnDrop();
            yield return new WaitForSeconds(2f);
        }
    }

    private void SpawnDrop()
    {
        var drop = Instantiate(dropPrefab, dropSpawnPoint.position, dropSpawnPoint.rotation);
        var rb = drop.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = dropSpawnPoint.up * dropSpeed * -1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("drop"))
        {
            life--;
        }
    }
}