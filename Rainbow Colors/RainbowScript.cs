using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowScript : MonoBehaviour
{
    //The material selected to be changed
    [SerializeField] private Material selectedMat;
    //The Array holding the wanted colors. 0 and last entry must be identical.
    private Color[] colors = { new Color(1f, 0f, 0f), new Color(0f, 1f, 0f), new Color(0f, 0f, 1f), new Color(1f, 0f, 0f) };
    //The main code of the script
    IEnumerator RunLoop()
    {
        float durationOfColors = 2f; //Sets how long you want the transition between the colors.

        while(true)
        {
            for (int i = 1; i < colors.Length; i++) //This for loop runs for the length of colors, allowing for the change between every 
            {
                float elapsed = 0.0f;
                while (elapsed < durationOfColors) //This while loop runs to smooth the transition between colors.
                {
                    float rVal = Mathf.Lerp(colors[i - 1].r, colors[i].r, elapsed / durationOfColors); //The temporary red color value
                    float gVal = Mathf.Lerp(colors[i - 1].g, colors[i].g, elapsed / durationOfColors); //The temporary green color value
                    float bVal = Mathf.Lerp(colors[i - 1].b, colors[i].b, elapsed / durationOfColors); //The temporary blue color value
                    elapsed += Time.deltaTime; // Increase the elapsed value by the time between frames.
                    selectedMat.color = new Color(rVal, gVal, bVal);

                    yield return new WaitForEndOfFrame(); // This is here so that the code will run every frame.
                }
                selectedMat.color = colors[i]; // This is added here because otherwise it may skip the wanted color by just a fraction.
            }
        }
        yield return null;
    }
    //A public method that can be called by an external source
    public void Run()
    {
        StartCoroutine(RunLoop()); // Starts the main part of the script
    }
    //Start() is private because there is no reason to add possible complications or errors by having it public and accessible.
    private void Start() // Because there is no external source calling Run(), i have it called here so that it will run on Start().
    {
        Run();
    }

}
