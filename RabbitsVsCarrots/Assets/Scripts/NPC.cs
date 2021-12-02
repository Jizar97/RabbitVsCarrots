using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NPC : Interactable {

    public Desativador balao;
    public Desativador dialogo;
    public Desativador crosshair;
    public Desativador textUI;
    public Text texto;
    public Transform PlayerRef;
    public PlayerController Player;
    public BossHealth boss;
    public HitSound music;
    public Desativador fim;


    public bool falou = false;


    private void Start() {
        
    }


    public override string GetDescription() {
        return "Pressione [E] para falar";
    }

    public override void Interact() {
        falou = true;
        Player.playerLiberado = false;
        transform.LookAt(PlayerRef);
        balao.Desativar();
        dialogo.Reativar();
        crosshair.Desativar();
        textUI.Desativar();
        if(boss.bossMorto == false){
            StartCoroutine(Espera());
        } else {
            StartCoroutine(Espera2());
        }
        
    }

    IEnumerator Espera(){
        yield return new WaitForSeconds(3);
        texto.text = "Se você não me matar nós podemos fazer um trato. Que tal?";
        yield return new WaitForSeconds(4);
        texto.text = "Eu posso te levar até a rainha.";
        yield return new WaitForSeconds(5);
        texto.text = "É isso que você quer, certo? Matar a rainha para acabar com a infestação.";
        yield return new WaitForSeconds(5);
        texto.text = "Eu te ajudo, eu não gosto dela mesmo.";
        yield return new WaitForSeconds(5);
        texto.text = "Para matá-la você vai precisar passar pela antiga barreira militar.";
        yield return new WaitForSeconds(5);
        texto.text = "Você vai ter de hackear o sistema de defesa no terminal de acesso.";
        yield return new WaitForSeconds(5);
        texto.text = "Mas não se preocupe, eu já pensei em tudo. Aqui, toma.";
        yield return new WaitForSeconds(5);
        texto.text = "Neste pendrive está o meu vírus, é só espetar ele no terminal.";
        yield return new WaitForSeconds(5);
        texto.text = "Bem... você ainda vai precisar passar pelas três camadas de proteção.";
        yield return new WaitForSeconds(5);
        texto.text = "Mas deve ser fácil o suficiente até para um coelho caipira.";
        yield return new WaitForSeconds(5);
        texto.text = "Ok, eu vou levá-lo até lá agora. Boa sorte.";
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Level_2");
    }

    IEnumerator Espera2(){
        yield return new WaitForSeconds(6);
        texto.text = "Nem acredito que acabou, e tudo graças a mim... claro, você também ajudou";
        yield return new WaitForSeconds(5);
        texto.text = "Formamos uma bela dupla, tenho que admitir";
        yield return new WaitForSeconds(5);
        texto.text = "...";
        yield return new WaitForSeconds(5);
        texto.text = "E aí, você bebe o quê?";
        music.Toca();
        yield return new WaitForSeconds(3);
        fim.Reativar();
        yield return new WaitForSeconds(8);
        SceneManager.LoadScene("MainMenu");
    }
}