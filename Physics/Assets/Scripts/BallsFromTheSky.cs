using UnityEngine;

public class BallsFromTheSky : MonoBehaviour
{
    public float interval = 0.5f;

    [SerializeField] float range = 4f;

    private float nextBallTime = 0f;
    private Transform objectStart;
    private ObjectPooler objectPooler;

    void Start()
    {
        nextBallTime = Time.time + interval;
        objectStart = transform;
        objectPooler = GetComponent<ObjectPooler>();
    }

    void Update()
    {
        if (Time.time > nextBallTime)
        {
            Vector3 position = new Vector3(Random.Range(-range, range) + objectStart.position.x, objectStart.position.y, Random.Range(-range, range) + objectStart.position.z);
            NewBall(position);
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
            ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
