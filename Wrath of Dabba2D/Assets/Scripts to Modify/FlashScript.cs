using UnityEngine;
using System.Collections;

public class FlashScript : MonoBehaviour {

    public float FlashTime = 0.001f;
    public AudioSource boom = null;

    public float EffectOpacity = 0.8f;

    SpriteRenderer RenderComp;
    Color TempColor;

    // Use this for initialization
    void Start () {
        RenderComp = GetComponent<SpriteRenderer>(); //Get the sprite renderer component
        
        TempColor = RenderComp.color; //Copy the color details from the object's Sprite Renderer
        TempColor.a = 0f; //Change the .a (alpha) property, which influences the opacity
        RenderComp.color = TempColor; //Apply this alterered color to the Renderer
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void FlashOn() {    
        TempColor = RenderComp.color; //Copy the color details from the object's Sprite Renderer
        TempColor.a = EffectOpacity; //Change the .a (alpha) property, which influences the opacity
        RenderComp.color = TempColor; //Apply this alterered color to the Renderer
        boom.Play();
        Invoke("FlashOff", FlashTime);
    }

    public void FlashOff() {
        TempColor = RenderComp.color;
        TempColor.a = 0f;  //Change Alpha back to zero to make flash transparent again
        RenderComp.color = TempColor;
    }
}
