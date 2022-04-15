using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public CanvasGroup myUiGroup;
    
    // Start is called before the first frame update
    void Start()
    {
        myUiGroup.alpha = .00f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeMe()
    {
        StartCoroutine(DoFade());
    }

    IEnumerator DoFade()
    {
        
        while (myUiGroup.alpha < 1)
        {
            myUiGroup.alpha += Time.deltaTime / 2;
            yield return null;
        }
        myUiGroup.interactable = false;
        yield return null;
    }
}
