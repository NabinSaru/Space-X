using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TrackHandler : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0f;
    [SerializeField] GameObject TrackPrefab;
    [SerializeField] Text currentscore;
    [SerializeField] Text highscoretxt;
    private float distanceOfDeletion = 78.9f;
    private int lap=0;
    internal int score=0;
    internal int hscore;
    private void Start()
    {
        int temp = PlayerPrefs.GetInt("highscore");
        hscore=Math.Max(0,temp);
        highscoretxt.text=hscore.ToString();    
    }

    // Update is called once per frame
    void Update()
    {
         currentscore.text = score.ToString();
         gameObject.transform.Translate(Vector3.forward*moveSpeed*Time.deltaTime);
         if(gameObject.transform.position.z>= distanceOfDeletion)
         {
             Destroy(gameObject.transform.GetChild(0).gameObject);
             distanceOfDeletion +=78.9f;
             GameObject temp = Instantiate(TrackPrefab,Vector3.zero,Quaternion.identity);
             temp.transform.position = new Vector3(0,0,gameObject.transform.GetChild(gameObject.transform.childCount - 1).transform.position.z-78.9f);
             temp.transform.parent = gameObject.transform;
             score+=5;
             lap+=1;
             if(lap%10==0&&moveSpeed<=40f)
             {
                 moveSpeed+=1f;
             }

         }
    }
}
