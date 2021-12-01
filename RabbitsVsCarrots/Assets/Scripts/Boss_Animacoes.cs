using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class Boss_Animacoes : MonoBehaviour {

    public BossAI naveMesh;
    public AudioClip Atacar, Olhar, Passear, Perseguir;
    public bool AudioTocando;
    public float AudioDuracao;
    
    // Use this for initialization
    void Start () {
 
    }
 
    // Update is called once per frame
    void Update () {
 
        if (AudioTocando == true) {/// AudioTocando ------------------------------------------------------
        AudioDuracao += Time.deltaTime;

        if (AudioDuracao >= GetComponent<AudioSource> ().clip.length ) {
            AudioTocando = false;
            AudioDuracao = 0;
        }
    }//----------------------------------------------------------------------------------------------------

    if (naveMesh.BMorrer == true) {
        GetComponent<Animator> ().SetBool ("Morreu", true);
    }


    if (naveMesh.BAtacar == true) {/// Atacar ------------------------------------------------------
        GetComponent<Animator> ().SetBool ("Atacar", true);
        GetComponent<AudioSource> ().clip = Atacar;
        GetComponent<AudioSource> ().PlayOneShot (Atacar);

    } else {
        GetComponent<Animator> ().SetBool ("Atacar", false);
    }//----------------------------------------------------------------------------------------------------


    if (naveMesh.BOlhar == true) {/// Olhar ------------------------------------------------------
        GetComponent<Animator> ().SetBool ("Olhar", true);

        if (GetComponent<AudioSource> ().clip != Olhar) {
            AudioTocando = false;
            AudioDuracao = 0;

        }

        if (AudioTocando == false) {
            GetComponent<AudioSource> ().clip = Olhar;
            GetComponent<AudioSource> ().PlayOneShot (Olhar);
            AudioTocando = true;
        }

    } else {
        GetComponent<Animator> ().SetBool ("Olhar", false);
    }//----------------------------------------------------------------------------------------------------


    if (naveMesh.BPassear == true) {/// Passear ------------------------------------------------------
        GetComponent<Animator> ().SetBool ("Passear", true);

        if (GetComponent<AudioSource> ().clip != Passear) {
            AudioTocando = false;
            AudioDuracao = 0;
        }

        if (AudioTocando == false) {
            GetComponent<AudioSource> ().clip = Passear;
            GetComponent<AudioSource> ().PlayOneShot (Passear);
            AudioTocando = true;
        }
 
        } else {
            GetComponent<Animator> ().SetBool ("Passear", false);
        }//----------------------------------------------------------------------------------------------------

        if (naveMesh.BPerseguir == true) { /// perseguir ------------------------------------------------------
            GetComponent<Animator> ().SetBool ("Perseguir", true);

            if (GetComponent<AudioSource> ().clip != Perseguir) {
                AudioTocando = false;
                AudioDuracao = 0;
            }

            if (AudioTocando == false) {
                GetComponent<AudioSource> ().clip = Perseguir;
                GetComponent<AudioSource> ().PlayOneShot (Perseguir);
                AudioTocando = true;
            }
 
            } else {
                GetComponent<Animator> ().SetBool ("Perseguir", false);
            }//----------------------------------------------------------------------------------------------------


        }
}