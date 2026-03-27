using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collectible : MonoBehaviour
{
    public float distanceToMove = 3;

    private Vector3 startingPosition;
    private Vector3 endingPosition;

    public float speed = 5f;
    public float direction = -1f;

    public int sceneNumber;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = gameObject.transform.position;
        endingPosition = new Vector3(distanceToMove, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < endingPosition.x)
        {
            direction = 1;
        }
        if(transform.position.x > startingPosition.x)
        {
            direction = -1;
        }
        transform.position += new Vector3(speed * direction * Time.deltaTime, 0, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            Invoke("LoadNextScene", 2f);
        }
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(sceneNumber);
    }
}