using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{
    public GameObject tailPrefab;
    public int score;
    List<Transform> tail = new List<Transform>();
    bool eat = false;
    bool created = false;


    Vector2 dir;
    // Start is called before the first frame update
    public void Start()
    {
        score = 0;
        InvokeRepeating("Move", 0.2f, 0.2f);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow)) dir = Vector2.right;
        else if (Input.GetKey(KeyCode.LeftArrow)) dir = Vector2.left;
        else if (Input.GetKey(KeyCode.DownArrow)) dir = Vector2.down;
        else if (Input.GetKey(KeyCode.UpArrow)) dir = Vector2.up;
    }

    public void Move()
    {
        Vector2 v = transform.position;

        transform.Translate(dir);

        if (eat)
        {
            GameObject g = (GameObject)Instantiate(tailPrefab, v, Quaternion.identity);

            tail.Insert(0, g.transform);

            eat = false;
            score++;
        }

        else if (tail.Count > 0)
        {
            tail.Last().position = v;
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.StartsWith("Food"))
        {
            eat = true;

            Destroy(collision.gameObject);
        }
        else
        {
            SceneManager.LoadScene("menu", LoadSceneMode.Single);
        }
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt("score", score);
    }



}
