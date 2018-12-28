using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sky : MonoBehaviour {

    [SerializeField] GameObject cloud1prefab;
    [SerializeField] GameObject cloud2prefab;
    [SerializeField] GameObject cloud3prefab;

    [SerializeField] GameObject BlackBirdprefab;
    [SerializeField] GameObject RedBirdprefab;


    public List<GameObject> clouds = new List<GameObject>();
    public List<GameObject> birds = new List<GameObject>();

    BoxCollider2D mycollider;


    int Options;

    Vector2 startingpoint;
    Vector2 movement;

    int cloudcount = 100;
    int birdcount = 100;
    float speed;




    private void Start()
    {
        clouds = new List<GameObject> {cloud1prefab, cloud2prefab, cloud3prefab };
        birds = new List<GameObject> { BlackBirdprefab, RedBirdprefab, BlackBirdprefab,BlackBirdprefab, BlackBirdprefab  ,BlackBirdprefab, BlackBirdprefab, BlackBirdprefab };
        mycollider = gameObject.GetComponent<BoxCollider2D>();
        startingclouds();
        StartCoroutine("cloudies");
        StartCoroutine("birdies");
    }

    //-----------------------------------------constant cloud production
    IEnumerator cloudies()
    {

        for (int i = 0; i < cloudcount; i++)
        {

            Debug.Log("is printing cloud" + i);
            cloudcount -= 1;
            Options = Random.Range(0, 3);


            var prefab = clouds[Options];
            var cloud = Instantiate(prefab, randomstartingpoint("cloud", 0), Quaternion.identity);
            cloud.name = "cloud" + i.ToString("00");
            cloud.transform.parent = gameObject.transform;


            var flipoliciousX = Random.Range(-3, 2);
            var flipoliciousY = Random.Range(-3, 2);
            cloud.transform.localScale =new Vector2( Mathf.Sign(flipoliciousX), Mathf.Sign(flipoliciousY));



            speed = Random.Range(0.3f, 1.0f);
            movement = new Vector2(speed, 0);
            cloud.GetComponent<Rigidbody2D>().velocity = movement;

            var wait = Random.Range(6.0f, 20.0f);
            yield return new WaitForSeconds(wait);

        }
    }
    //---------------------------------------------------

    //-----------------------------------------constant bird production
    IEnumerator birdies()
    {

        for (int i = 0; i < birdcount; i++)
        {

            Debug.Log("is printing bird" + i);
            birdcount -= 1;
            var lor = Random.Range(-3, 2);//----------deciding which side bird is coming from


            Options = Random.Range(0, 8);//------------deciding which bird
            var prefab = birds[Options];

            var bird = Instantiate(prefab, randomstartingpoint("bird", lor), Quaternion.identity);


            birdname(prefab, bird, i);
           



            bird.transform.parent = gameObject.transform;
            //bird.gameObject.GetComponent<Animator>().speed = 2;----------------------------------------change speed of animator to bird


            birdsides(lor, prefab, bird);

            
            movement = new Vector2(speed, 0);
            bird.GetComponent<Rigidbody2D>().velocity = movement;

            var wait = Random.Range(7.0f, 20.0f);
            yield return new WaitForSeconds(wait);

        }
    }
    //---------------------------------------------------


    //------------------------------------------- deciding which side the birds come from
    void birdsides(int lor, GameObject prefab, GameObject bird)
    {
        if (Mathf.Sign(lor) == 1)//--------------if from right
        {
            if (prefab == BlackBirdprefab)
            {
                bird.transform.localScale = new Vector2(-1, 1);
                speed = Random.Range(-10.0f, -4.0f);
            }
            else if (prefab == RedBirdprefab)
            {
                bird.transform.localScale = new Vector2(-1, 1);
                speed = Random.Range(-3.0f, -1.0f);
            }

        }
        else//--------if from left
        {
            if (prefab == BlackBirdprefab)
            {
                speed = Random.Range(4.0f, 10.0f);
            }
            else if (prefab == RedBirdprefab)
            {
                speed = Random.Range(1.0f, 3.0f);
            }

        }
       



    }

    //-------------------------------------------------

    //-----------------------------------bird name
    void birdname(GameObject prefab, GameObject bird, int i)
    {
        if (prefab == BlackBirdprefab)
        {
            bird.name = "BlackBird" + i.ToString("00");
        }
        else if (prefab == RedBirdprefab)
        {
            bird.name = "RedBird" + i.ToString("00");
        }
        else
        {
            Debug.LogWarning("Bird prefab not valid " + prefab.name);
        }
     
    }
    //-------------------------------------






    //-----------------------------------------pre placed clouds
    void startingclouds()
        {
            for (int i = 0; i < 4; i++) {
                Options = Random.Range(0, 3);
                var prefab = clouds[Options];
                int X = i * 12;
                Vector2 setplace = new Vector2(X, 1);
                var cloud = Instantiate(prefab, setplace, Quaternion.identity);
                cloud.name = "startingcloud" + i.ToString("00");
                cloud.transform.parent = gameObject.transform;
                speed = Random.Range(0.3f, 1.0f);
                movement = new Vector2(speed, 0);
                cloud.GetComponent<Rigidbody2D>().velocity = movement;
        }


        }
    //-----------------------------------------------



    //-----------------------------------------random position generation
    Vector2 randomstartingpoint(string objectname, int lor)
    {
        if (objectname == "cloud")
        {
            var X = Random.Range(-15, -12);
            var Y = Random.Range(-2.0f, 2.0f);
            startingpoint = new Vector2(X, Y);
            return startingpoint;
        }
        if (objectname == "bird")
        {

            if (Mathf.Sign(lor) == -1)
            {
                var X = Random.Range(-12.0f, -9.5f);
                var Y = Random.Range(-2.0f, 5.0f);
                startingpoint = new Vector2(X, Y);
                return startingpoint;
            }
            else
            {
                var X = Random.Range(40.0f, 41.0f);
                var Y = Random.Range(-2.0f, 5.0f);
                startingpoint = new Vector2(X, Y);
                return startingpoint;
            }

        }
        else
        {
            Debug.LogWarning("Objectname not valid");
            return new Vector2(0,0);
        }

    }
    //-----------------------------------------

    //-----------------------------------------destorying objects once they leave sky
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.transform.name.Contains("cloud")){
            cloudcount += 1;
        }
        else if (collision.gameObject.transform.name.Contains("bird"))
        {
            birdcount += 1;
            Debug.Log(birdcount);
        }
        else
        {
            Debug.LogWarning("Something entered Sky collider that is not been named " + collision.name);

        }


        Destroy(collision.gameObject);
    }
    //-----------------------------------------

}
