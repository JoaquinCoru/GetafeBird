using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    [Header("Tiene que ser negativa")]
    private float speed;
    [SerializeField]
    public GameObject cilindroSuperior;
    [SerializeField]
    public GameObject cilindroInferior;
    [Range(0,0.3f)]
    public float umbralOffset;

    private GameManager manager; //Componente

    void Start()
    {
        float offsetY = Random.Range(0, umbralOffset);
        cilindroSuperior.transform.Translate(Vector3.down * offsetY);
        cilindroInferior.transform.Translate(Vector3.up * offsetY);

        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.isPlaying() == true)
        {
            Vector3 movimiento = new Vector3(0, 0, speed * Time.deltaTime);
            transform.Translate(movimiento);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Limite")
        {
            Destroy(gameObject);
        }
        
    }
        

}
