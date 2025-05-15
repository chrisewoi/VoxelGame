using UnityEngine;

public class FireFlicker : MonoBehaviour
{
    public float flickerStrength;
    public int interval;
    public int currentInterval;
    private int count;
    private Vector3 flicker;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        count = 0;
        currentInterval = interval;
        flicker = Vector3.zero;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        count++;
        if (count % currentInterval == Random.Range(2, interval))
        {
            flicker = new Vector3(OffsetByStrenght(), OffsetByStrenght(), OffsetByStrenght());
        }

        transform.localPosition = Vector3.MoveTowards(transform.localPosition, flicker, Vector3.Distance(transform.localPosition, flicker)/2f);
    }

    private float OffsetByStrenght()
    {
        return Mathf.Pow(Random.Range(-flickerStrength, flickerStrength), 2f);
    }
}
