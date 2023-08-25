using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    GameController gC;
    GameObject Alicio;
    Player player;
    Muerte muerte;
    private void Awake()
    {
        Alicio = GameObject.Find("Alicio");
        Alicio.gameObject.SetActive(false);
        player = FindObjectOfType<Player>();
        muerte = FindObjectOfType<Muerte>();

    }
    void Start()
    {
        if (gC == null)
        {
            gC = this;
        }
        else if (gC != this)
        {
            Destroy(gameObject);
        }
        
        Alicio.gameObject.SetActive(true);
        
        player.SetAnimator(Alicio);
        muerte.SetearMuerte();
    }

    // Update is called once per frame
    void Update()
    {
        //DontDestroyOnLoad(gC);
    }
    public void CambioDeEscena(string escena)
    {
        SceneManager.LoadScene(escena);
    }
}
