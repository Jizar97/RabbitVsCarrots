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
        return "Pressione [E] para hackear";
    }

    public override void Interact() {
        if(telaHacking.fim == false){
            Hacking();
        }
    }
}