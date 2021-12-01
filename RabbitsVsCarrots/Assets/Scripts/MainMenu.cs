using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Desativador videoPlayer;
    public Desativador rawImage;

    // Start is called before the first frame update
    public void Begin(){
        GetComponent<AudioSource>().Stop();
        StartCoroutine(Esperar());
        
    }

    IEnumerator Esperar(){
        rawImage.Reativar();
        videoPlayer.Reativar();
        yield return new WaitForSeconds(88);
        SceneManager.LoadScene("Level_1");
    }
}
