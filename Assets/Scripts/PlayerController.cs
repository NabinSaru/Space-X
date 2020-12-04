using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0f;
    [SerializeField] GameObject cam;
    [SerializeField] TrackHandler th;
    [SerializeField] GameObject spaceshipMesh;
    [SerializeField] AudioClip[] audioPackage;
    [SerializeField] AudioSource SEGameObject;
    [SerializeField] AudioClip shipExaust;
    [SerializeField] AudioClip shipExplode;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        if(!audioSource.isPlaying){
            audioSource.clip=audioPackage[0];
            audioSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("MoveRight"))
        {
            gameObject.transform.Translate(Vector3.right*moveSpeed*Time.deltaTime);
        }
        else if (Input.GetButton("MoveLeft"))
        {
            gameObject.transform.Translate(Vector3.left*moveSpeed*Time.deltaTime);
        }
        if(!audioSource.isPlaying){
            audioSource.clip=audioPackage[0];
            audioSource.Play();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Obstacle"||other.gameObject.tag=="Border")
        {
            cam.transform.parent=null;
            th.enabled=false;
            spaceshipMesh.SetActive(false); 
            
        } 
        Invoke("GameOver",2.5f);
    }
    private void GameOver(){
        PlayerPrefs.SetInt("currentscore",th.score);
        PlayerPrefs.SetInt("highscore",th.hscore);
        SceneManager.LoadScene(2);
    }
}
