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
    public AudioSource audioSource;
    public AudioClip hitClip;

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
            audioSource.PlayOneShot(hitClip);
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
        audioSource.Play();
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