using UnityEngine;

public class Mirror : MonoBehaviour
{
    public bool broken;
    
    public Transform player;
    public Transform enemy;
    public Collectable[] collectable;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
        broken = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = new Vector3(player.position.x, player.position.y, player.position.z);

        if (Vector3.Distance(v, transform.position) <= 6f)
        {
            player.gameObject.GetComponent<AudioSource>().Play();
            foreach (Collectable collect in collectable)
            {
                collect.discovered = true;
            }
            player.GetComponent<Player>().mirror = this;
        }
        else if (player.GetComponent<Player>().mirror == this)
        {
            player.GetComponent<Player>().mirror = null;
        }
        
        if (!broken)
        {
            Vector3 e = new Vector3(enemy.position.x, enemy.position.y, enemy.position.z);

            if (Vector3.Distance(e, transform.position) <= 15f)
            {
                enemy.GetComponent<Enemy>().nearMirror = this;
            }
            else if(enemy.GetComponent<Enemy>().nearMirror == this)
            {
                enemy.GetComponent<Enemy>().nearMirror = null;
            }
        }
        else if(enemy.GetComponent<Enemy>().nearMirror == this)
        {
            enemy.GetComponent<Enemy>().nearMirror = null;
        }
    }
}
