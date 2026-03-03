using UnityEngine;

public class BallGame : MonoBehaviour
{
    public float interval = 0.5f;
    public Transform dropPoint;

    [SerializeField] float range = 4f;

    private float nextBallTime = 0f;
    private ObjectPooler objectPooler;
    private AudioSource soundEffect;

    void Start()
    {
        objectPooler = GetComponent<ObjectPooler>();
        soundEffect = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Time.time > nextBallTime)
        {
            NewBall(dropPoint.position);
            nextBallTime = Time.time + interval;
        }
    }

    void NewBall(Vector3 position)
    {
        GameObject ball = objectPooler.GetPooledObject();
        if (ball != null)
        {
            ball.transform.position = position;
            ball.transform.rotation = Quaternion.identity;
            Rigidbody rb = ball.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            ball.SetActive(true);
            soundEffect.Play();
        }
    }
}
