using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puntaje : MonoBehaviour {
    public GameObject Player;
    public GameObject MenuInteractivoInGame;
    public GameObject ObsSpeed1;
    public GameObject ObsSpeed2;
    public GameObject ObsSpeed3;
    public GameObject SpawnerController;
    public GameObject MapaMove;
    public float Contador = 0f;
    public float Contador2 = 0f;
    public float Contador3 = 0f;

    public float CurrentSpeed = 50;
    public float InitialPlayerRotSpeed = 20;
	// Use this for initialization
	void Start ()
    {
        ResetAll();
    }
	
	// Update is called once per frame
	void Update ()
    {
        ContadorInGame();
        if (Player.GetComponent<Player>().PlayerDead == false && MenuInteractivoInGame.GetComponent<MenuInteractivoInGame>().IsPause == false)
        {
            if (ObsSpeed1.GetComponent<obstaculos>().speed <= 70)
            {
                NuevoAumentoSpeed();
            }
            if(ObsSpeed1.GetComponent<obstaculos>().speed >= 70)
            {
                MapaMove.GetComponent<Scroll>().scrolly = 0.38f;
            }
        }
        else
        {
            if (ObsSpeed1.GetComponent<obstaculos>().speed >= 70)
            {
                MapaMove.GetComponent<Scroll>().scrolly = 0.38f;
            }
        }
    }
    void ContadorInGame()
    {
        if (Player.GetComponent<Player>().PlayerDead == false && MenuInteractivoInGame.GetComponent<MenuInteractivoInGame>().IsPause == false)
        {
            Contador += 1 * Time.deltaTime * 5;
            Contador2 += 1 * Time.deltaTime * 0.6f;
            Contador3 += 1 * Time.deltaTime * 0.08f;
        }
    }
    void NuevoAumentoSpeed()
    {
        ObsSpeed1.GetComponent<obstaculos>().speed = CurrentSpeed + Contador2;
        ObsSpeed2.GetComponent<obstaculos>().speed = CurrentSpeed + Contador2;
        ObsSpeed3.GetComponent<obstaculos>().speed = CurrentSpeed + Contador2;
        SpawnerController.GetComponent<spawnerController>().contadorDificulty = SpawnerController.GetComponent<spawnerController>().contadorDificulty - 0.0002f;
        MapaMove.GetComponent<Scroll>().scrolly += 0.003f * Time.deltaTime;
        Player.GetComponent<Player>().playerRotation = InitialPlayerRotSpeed + Contador3;
    }
    void ResetAll()
    {
        MapaMove.GetComponent<Scroll>().scrolly = 0.25f;
        ObsSpeed1.GetComponent<obstaculos>().speed = CurrentSpeed;
        ObsSpeed2.GetComponent<obstaculos>().speed = CurrentSpeed;
        ObsSpeed3.GetComponent<obstaculos>().speed = CurrentSpeed;
        SpawnerController.GetComponent<spawnerController>().contadorDificulty = 2.3f;
        Player.GetComponent<Player>().playerRotation = InitialPlayerRotSpeed;
    }
}
