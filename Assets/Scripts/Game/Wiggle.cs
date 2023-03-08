using UnityEngine;

public class Wiggle : MonoBehaviour
{
    public float speed = 10.0f;
    public float amount = 0.1f;

    private float timeOffset;
    private bool isWiggling = false;

    void Start()
    {
        timeOffset = Random.Range(0.0f, 100.0f);
    }

    void Update()
    {
        if (isWiggling)
        {
            float sineWave = Mathf.Sin((Time.time + timeOffset) * speed) * amount;
            transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, sineWave));
        }
    }

    public void startWiggle()
    {
        isWiggling = true;
    }

    public void stopWiggle()
    {
        isWiggling = false;
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}
