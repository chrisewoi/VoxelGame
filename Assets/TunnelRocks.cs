using UnityEngine;

public class TunnelRocks : MonoBehaviour
{
    public GameObject[] fires;
    public bool autoUnlocked;
    private bool unlocked = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        unlocked = autoUnlocked;
    }

    // Update is called once per frame
    void Update()
    {
        if (!unlocked)
        {
            bool allFiresOn = true; //set trigger to true

            foreach (GameObject fire in fires) // for each fire, 
            {
                if (!fire.activeInHierarchy) allFiresOn = false; //if any fires are off, set trigger to false
            }

            if (allFiresOn) unlocked = true; // if trigger is still on, all fires must be on, so unlock the tunnel!
        }
        else
        {
            gameObject.SetActive(false); // if unlocked, disable this gameObject (the tunnel rocks).
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            unlocked = true;
        }
    }
}
