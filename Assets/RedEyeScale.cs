using UnityEngine;

public class RedEyeScale : MonoBehaviour
{
    public float interval;
    private float intervalOffset;
    private float time;
    public float min;
    public float max;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (time + interval + intervalOffset < Time.time)
        {
            transform.localScale = new Vector3(RandScale(), RandScale(), RandScale());
            intervalOffset = Random.Range(-interval / 15f, interval / 15f);
            time = Time.time;
        }
    }

    private float RandScale()
    {
        return Random.Range(min, max);
    }
}
