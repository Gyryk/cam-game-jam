using Unity.AI.Navigation;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    public NavMeshSurface nav;
    public Player player;
    
    public int num;
    public int dir;
    public float speed;
    public bool opened;
    private bool opening;
    private Transform hinge;
    public bool final;

    // Start is called before the first frame update
    void Start()
    {
        nav = GameObject.FindGameObjectWithTag("GameController").GetComponent<NavMeshSurface>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        hinge = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        Transform t = player.transform;
        Vector3 v = new Vector3(t.position.x, transform.position.y, t.position.z);

        if (Vector3.Distance(v, transform.position) <= 4f)
        {
            player.puzzle = num;
            player.door = this;
        }
        else if (player.GetComponent<Player>().puzzle == num || opened)
        {
            player.puzzle = 0;
        }
        
        Vector3 currRot = hinge.transform.localEulerAngles;

        if (opening)
        {
            if (dir == 1)
            {
                if (currRot.y < 100f)
                {
                    hinge.transform.localEulerAngles = Vector3.Lerp(currRot, new Vector3(currRot.x, 100f, currRot.z), speed * Time.deltaTime * 0.7f);
                }

                if (currRot.y >= 90f)
                {
                    opening = false;
                    nav.BuildNavMesh();
                    // doorBack.doorOpen = true;
                }
            }
            else
            {
                hinge.transform.localEulerAngles = new Vector3(currRot.x, 360f, currRot.z);
                if (currRot.y > 260f) // Assuming 260f as the opposite angle for opening
                {
                    // You might need to adjust the logic here for correct rotation
                    // This is just an example assuming you want to rotate back from 360 to 260 degrees
                    hinge.transform.localEulerAngles = Vector3.Lerp(currRot, new Vector3(currRot.x, 260f, currRot.z), speed * Time.deltaTime * 0.7f);
                }

                if (currRot.y <= 270f) // This condition checks if the door has opened in the opposite direction enough
                {
                    opening = false;
                    nav.BuildNavMesh();
                    // doorBack.doorOpen = true;
                }
            }
        }
    }

    public void Open()
    {
        if (final)
        {
            nav.gameObject.GetComponent<GameManager>().ChangeScene("Win");
        }

        gameObject.GetComponent<AudioSource>().Play();
        opened = true;
        opening = true;
        Destroy(player.collectable);
    }
}
