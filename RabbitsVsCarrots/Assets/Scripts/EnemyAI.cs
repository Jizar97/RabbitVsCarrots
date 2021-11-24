using UnityEngine;
using System.Collections;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    public Transform Player;
    private NavMeshAgent naveMesh;
    private float DistanciaDoPlayer, DistanciaDoAIPoint;
    public float DistanciaDePercepcao = 30, DistanciaDeSeguir = 20, DistanciaDeAtacar = 2, VelocidadeDePasseio = 3, VelocidadeDePerseguicao = 6, TempoPorAtaque = 1.5f;
    public int DanoDoInimigo = 15;
    private bool VendoOPlayer;
    public Transform[] DestinosAleatorios;
    private int AIPointAtual;
    private bool PerseguindoAlgo, contadorPerseguindoAlgo, atacandoAlgo;
    private float cronometroDaPerseguicao, cronometroAtaque;
    public bool BPassear, BOlhar, BPerseguir, BAtacar, BMorrer;

    public PlayerHealth playerHealth;

    void Start()
    {
        AIPointAtual = Random.Range(0, DestinosAleatorios.Length);
        naveMesh = transform.GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        DistanciaDoPlayer = Vector3.Distance(Player.transform.position, transform.position);
        DistanciaDoAIPoint = Vector3.Distance(DestinosAleatorios[AIPointAtual].transform.position, transform.position);
        //============================== RAYCAST ===================================//
        RaycastHit hit;
        Vector3 deOnde = transform.position;
        Vector3 paraOnde = Player.transform.position;
        Vector3 direction = paraOnde - deOnde;

        if (BMorrer == true){


        } else {

            if (Physics.Raycast(transform.position, direction, out hit, 1000) && DistanciaDoPlayer < DistanciaDePercepcao)
            {
                if (hit.collider.gameObject.CompareTag("Player"))
                {
                    VendoOPlayer = true;
                } else {
                    VendoOPlayer = false;
                }
            }
            //================ CHECAGENS E DECISOES DO INIMIGO ================//
            if (DistanciaDoPlayer > DistanciaDePercepcao)
            {   
                BPassear = true;
                Passear();
            }
            if (DistanciaDoPlayer <= DistanciaDePercepcao && DistanciaDoPlayer > DistanciaDeSeguir)
            {
                if (VendoOPlayer == true)
                {
                    BOlhar = true;
                    Olhar();
                } else {
                    BPassear = true;
                    Passear();
                }
            }
            if (DistanciaDoPlayer <= DistanciaDeSeguir && DistanciaDoPlayer > DistanciaDeAtacar)
            {
                if (VendoOPlayer == true)
                {
                    BPerseguir = true;
                    Perseguir();
                    PerseguindoAlgo = true;
                }
                else
                {
                    BPassear = true;
                    Passear();
                }
            }
            if (DistanciaDoPlayer <= DistanciaDeAtacar) {
                BAtacar = true;
                Atacar();
            }
            //COMANDOS DE PASSEAR
            if (DistanciaDoAIPoint <= 2)
            {
                AIPointAtual = Random.Range(0, DestinosAleatorios.Length);
                BPassear = true;
                Passear();
            }
            //CONTADORES DE PERSEGUICAO
            if (contadorPerseguindoAlgo == true)
            {
                cronometroDaPerseguicao += Time.deltaTime;
            }
            if (cronometroDaPerseguicao >= 5 && VendoOPlayer == false)
            {
                contadorPerseguindoAlgo = false;
                cronometroDaPerseguicao = 0;
                PerseguindoAlgo = false;
            }
            // CONTADOR DE ATAQUE
            if (atacandoAlgo == true){
                cronometroAtaque += Time.deltaTime;
            }
            if(cronometroAtaque >= TempoPorAtaque && DistanciaDoPlayer <= DistanciaDeAtacar){
                atacandoAlgo = true;
                cronometroAtaque = 0;
                playerHealth.TakeDamage(DanoDoInimigo);
            } else if (cronometroAtaque >= TempoPorAtaque && DistanciaDoPlayer > DistanciaDeAtacar){
                atacandoAlgo = false;
                cronometroAtaque = 0;
            }

        }

        
    }

    void Passear()
    {
        BOlhar = false;
        BPerseguir = false;
        BAtacar = false;

        if (PerseguindoAlgo == false)
        {
            naveMesh.acceleration = 5;
            naveMesh.speed = VelocidadeDePasseio;
            naveMesh.destination = DestinosAleatorios[AIPointAtual].position;
        }
        else if (PerseguindoAlgo == true)
        {
            contadorPerseguindoAlgo = true;
        }
    }
    void Olhar()
    {
        BPassear = false;
        BPerseguir = false;
        BAtacar = false;
        naveMesh.speed = 0;
        transform.LookAt(Player);
    }
    void Perseguir()
    {
        BPassear = false;
        BOlhar = false;
        BAtacar = false;

        naveMesh.acceleration = 8;
        naveMesh.speed = VelocidadeDePerseguicao;
        naveMesh.destination = Player.position;
    }
    void Atacar()
    {
        BPassear = false;
        BOlhar = false;
        BPerseguir = false;

        atacandoAlgo = true;
    }

    public void Morrer()
    {
        BPassear = false;
        BOlhar = false;
        BPerseguir = false;
        BAtacar = false;

        BMorrer = true;
    }

}