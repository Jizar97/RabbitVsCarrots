using UnityEngine;

public class Terminal : Interactable {

    public TelaHacking telaHacking;

    private void Start() {
        //Hacking();
    }

    void Hacking() {
        //Debug.Log("To hackeando esta porra");
        telaHacking.Setup();
    }

    public override string GetDescription() {
        return "Aperte [E] para acessar o terminal";
    }

    public override void Interact() {
        if(telaHacking.fim == false){
            Hacking();
        }
    }
}