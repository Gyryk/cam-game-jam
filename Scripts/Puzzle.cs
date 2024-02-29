using UnityEngine;

public class Puzzle : MonoBehaviour
{
    public Transform player;
    public int num;
    public bool solved;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        solved = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = new Vector3(player.position.x, transform.position.y, player.position.z);

        if (Vector3.Distance(v, transform.position) <= 6f && !solved)
        {
            player.GetComponent<Player>().puzzle = num;
            player.GetComponent<Player>().puzzleObj = this;
        }
        else if (player.GetComponent<Player>().puzzle == num || solved)
        {
            player.GetComponent<Player>().puzzle = 0;
            player.GetComponent<Player>().puzzleObj = null;
        }
    }
}
