using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;

    public int P1Life;
    public int P2Life;

    public GameObject P1Win;
    public GameObject P2Win;

    public GameObject[] P1Sticks;
    public GameObject[] P2Sticks;

    public AudioSource hurtSound;

    public string MainMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(P1Life <= 0)
        {
            Player1.SetActive(false);
            P2Win.SetActive(true);
        }
        if(P2Life <= 0)
        {
            Player2.SetActive(false);
            P1Win.SetActive(true);
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(MainMenu);
        }
    }

    public void HurtP1()
    {
        P1Life -= 1;
        for(int i = 0; i < P1Sticks.Length; i++)
        {
            if(P1Life > i)
            {
                P1Sticks[i].SetActive(true);
            }
            else
            {
                P1Sticks[i].SetActive(false);
            }
        }
        hurtSound.Play();
    }
    
    public void HurtP2()
    {
        P2Life -= 1;
        for (int i = 0; i < P2Sticks.Length; i++)
        {
            if (P2Life > i)
            {
                P2Sticks[i].SetActive(true);
            }
            else
            {
                P2Sticks[i].SetActive(false);
            }
        }
        hurtSound.Play();
    }
}
