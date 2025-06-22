using UnityEngine;

public class TunnelScale : MonoBehaviour
{
    public float interval;
    private float intervalOffset;
    private float time;
    public float min;
    public float max;
    private Vector3 scaleBase;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        time = 0f;
        scaleBase = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (time + interval + intervalOffset < Time.time)
        {
            transform.localScale = scaleBase + new Vector3(RandScale(), 0f, RandScale());
            intervalOffset = Random.Range(-interval / 15f, interval / 15f);
            time = Time.time;
        }
    }

    private float RandScale()
    {
        return Random.Range(min, max);
    }
}
