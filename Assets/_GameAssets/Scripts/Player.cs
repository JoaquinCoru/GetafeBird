using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float fuerza;

    [SerializeField]
    private GameObject prefabSangre;
    Rigidbody rb;

    private GameManager manager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {        
        /**
         * 
         */
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 impulso = new Vector3(0, fuerza, 0);
            rb.AddForce(impulso);
            GetComponent<AudioSource>().Play();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Crear sangre
        Instantiate(prefabSangre, transform);
        //Destroy(this.gameObject);
        gameObject.GetComponents<AudioSource>()[1].Play();

        gameObject.GetComponents<AudioSource>()[2].Play();

        manager.StopGame();

        Invoke("CargarEscena", 3);
       
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().IncrementarPuntuacion();
        other.gameObject.GetComponent<AudioSource>().Play();
    }

    void CargarEscena()
    {
        SceneManager.LoadScene(0);
    }
}
