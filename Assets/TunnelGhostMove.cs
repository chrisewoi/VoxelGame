using System;
using UnityEngine;
using UnityEngine.Rendering;
using Random = UnityEngine.Random;

public class TunnelGhostMove : MonoBehaviour
{
    public float speed;
    private Vector3 position;
    private bool triggered = false;

    public Volume volume;
    private float volumeWeight;
    private float startTime;
    public float easeTime;
    public AnimationCurve anim;
    
    //public RenderTexture renderTexture;
    public RenderTexture[] renderTextures;
    public float textureInterval;
    public float textureChance;
    private bool textureLow;
    private float textureChanceMult;
    public float minLowTexture; // as %
    public float maxLowTexture;// as %
    private Vector2 textureResolution;
    private float textureTimer;
    public Material renderMaterial;
    
    private Camera cam;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = GetComponentInChildren<Camera>();
        position = gameObject.transform.position;
        //textureResolution = new Vector2(renderTextures[0].width, renderTextures[0].height);
        
        textureTimer = 0f;
        textureChanceMult = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered)
        {
            position.z += speed * Time.deltaTime;
            gameObject.transform.position = position;
            volumeWeight = anim.Evaluate((Time.time - startTime)* easeTime);
            //volumeWeight = AnimationCurve.EaseInOut(startTime, 0f, startTime + easeTime, 1f).Evaluate(Time.time);
            volume.weight = volumeWeight;
        }
        SetTextureRes();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggered = true;
            startTime = Time.time;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //triggered = false;
        }    
    }

    private void SetTextureRes()
    {
        if (textureTimer > textureInterval * (textureLow?0.7f:1))
        {
            // Reset timer
            textureTimer = 0f;
            
            // Set chance mult
            textureChanceMult = 1f;
            if (textureLow) textureChanceMult = 4f; // tweak this
            
            //renderTexture.Release(); // Allow RenderTexture resolution to be adjusted
            
            // Chance to lower res
            if (Random.value <= textureChance * textureChanceMult)
            {
                textureLow = true;
                

                /*int textureMult = 1;
                if (Random.value > 0.5f)
                {
                    textureMult = 5;
                }*/

                //int finalMult = (int)Random.Range(minLowTexture, maxLowTexture) * textureMult;

                cam.targetTexture = renderTextures[Random.Range(1, renderTextures.Length)];
                renderMaterial.mainTexture = cam.targetTexture;
                

                //renderTextureLow.width = (int)(textureResolution.x * finalMult); // Scaled down render scale
                //renderTextureLow.height = (int)(textureResolution.y * finalMult);//

                //cam.targetTexture = renderTextureLow;
            }
            else
            {
                textureLow = false;
                //if(renderTextureLow != null) renderTextureLow.Release();
                //renderTexture.width = (int)textureResolution.x; // Default render scale
                //renderTexture.height = (int)textureResolution.y;//

                cam.targetTexture = renderTextures[0];
                renderMaterial.mainTexture = cam.targetTexture;
            }

            //renderTexture.Create(); // Locks in the new res
        }

        textureTimer += Time.deltaTime;
    }
}
