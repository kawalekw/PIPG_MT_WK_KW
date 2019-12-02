using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class sc : MonoBehaviour
{
    public static AudioClip startSound;
    private static bool created = false;
    Text txt;
    // Start is called before the first frame update
    void Start()
    {
        startSound = Resources.Load<AudioClip>("jump_10");
        txt = GameObject.Find("Score").GetComponent<Text>();
        txt.text = PlayerPrefs.GetInt("score").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) Exit();
        else if (Input.GetKey(KeyCode.Space))
        {

            ChangeScene();
            GetComponent<AudioSource>().PlayOneShot(startSound);
        }
        
        
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    void Awake()
    {
      if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
            Debug.Log("Awake: " + this.gameObject);
        }
    }

    
}
