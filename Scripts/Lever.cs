using UnityEngine;

public class LeverInteraction : MonoBehaviour
{
    public GameObject[] levers;
    public GameObject[] handles;
    private bool[] activated = new bool[5];
    public bool[] solution = {true, false, true, true, false};

    // The on and off rotation angles for the lever
    public Vector3 onRotation;
    public Vector3 offRotation;

    public Player player;

    void Start()
    {
        activated = new[] {false, false, false, false, false};
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check for a mouse click
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Perform the raycast
            if (Physics.Raycast(ray, out hit))
            {
                for (int i = 0; i < 5; i++)
                {
                    if(hit.collider.gameObject == levers[i])
                    {
                        activated[i] = !activated[i];
                        handles[i].transform.localEulerAngles = activated[i] ? onRotation : offRotation;
                        player.leverSolved = checkLevers();
                    }
                }
            }
        }
    }

    bool checkLevers()
    {
        for (int i = 0; i < 5; i++)
        {
            if (activated[i] != solution[i])
            {
                return false;
            }
        }
        return true;
    }
}