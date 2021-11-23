using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class Enemy_Animacoes : MonoBehaviour {

    public EnemyAI naveMesh;
    public AudioClip Atacar, Olhar, Passear, Perseguir;
    public bool AldioTocando;
    public float AldioDuracao;
    
    // Use this for initialization
    void Start () {
 
    }
 
    // Update is called once per frame
    void Update () {
 
        if (AldioTocando == true) {/// AldioTocando ------------------------------------------------------
        AldioDuracao += Time.deltaTime;

        if (AldioDuracao >= GetComponent<AudioSource> ().clip.length ) {
            AldioTocando = false;
            AldioDuracao = 0;
        }
    }//----------------------------------------------------------------------------------------------------

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
            AldioTocando = false;
            AldioDuracao = 0;

        Debug.Log ("Audio Trocado");
    }

    if (AldioTocando == false) {
        GetComponent<AudioSource> ().clip = Olhar;
        GetComponent<AudioSource> ().PlayOneShot (Olhar);
        AldioTocando = true;
    }

    } else {
        GetComponent<Animator> ().SetBool ("Olhar", false);
    }//----------------------------------------------------------------------------------------------------


    if (naveMesh.BPassear == true) {/// Passear ------------------------------------------------------
        GetComponent<Animator> ().SetBool ("Passear", true);

        if (GetComponent<AudioSource> ().clip != Passear) {
            AldioTocando = false;
            AldioDuracao = 0;
            Debug.Log ("Audio Trocado");
        }

        if (AldioTocando == false) {
            GetComponent<AudioSource> ().clip = Passear;
            GetComponent<AudioSource> ().PlayOneShot (Passear);
            AldioTocando = true;
        }
 
        } else {
            GetComponent<Animator> ().SetBool ("Passear", false);
        }//----------------------------------------------------------------------------------------------------

        if (naveMesh.BPerseguir == true) { /// perseguir ------------------------------------------------------
            GetComponent<Animator> ().SetBool ("Perseguir", true);

            if (GetComponent<AudioSource> ().clip != Perseguir) {
                AldioTocando = false;
                AldioDuracao = 0;
                Debug.Log ("Audio Trocado");
            }

            if (AldioTocando == false) {
                GetComponent<AudioSource> ().clip = Perseguir;
                GetComponent<AudioSource> ().PlayOneShot (Perseguir);
                AldioTocando = true;
            }
 
            } else {
                GetComponent<Animator> ().SetBool ("Perseguir", false);
            }//----------------------------------------------------------------------------------------------------


        }
}