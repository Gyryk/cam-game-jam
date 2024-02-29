using UnityEngine;

public class Collectable : MonoBehaviour
{
    public GameObject collect;
    public Transform player;
    public Transform collectView;

    public bool discovered;
    public bool hammer;
    public int num;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        collect.SetActive(false);
        discovered = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = new Vector3(player.position.x, transform.position.y, player.position.z);

        if (discovered)
        {
            collect.SetActive(true);
            collect.layer = 6;
        }
        
        if (Vector3.Distance(v, transform.position) <= 4f && discovered)
        {
            collect.layer = 6;
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!hammer && player.GetComponent<Player>().collect == 0)
                {
                    if (num == 4)
                    {
                        if (player.GetComponent<Player>().lockOpen)
                        {
                            player.GetComponent<Player>().collect = num;
                            player.GetComponent<Player>().collectable = collect;
                            collect.transform.SetParent(collectView);
                            collect.transform.localPosition = Vector3.zero;
                            collect.transform.localRotation = Quaternion.Euler(0, 0, 0);
                            collect.SetActive(false);
                            Destroy(gameObject);
                            collect.layer = 6;
                        }
                    }
                    else if (num == 5)
                    {
                        if (player.GetComponent<Player>().combinationSolved)
                        {
                            player.GetComponent<Player>().collect = num;
                            player.GetComponent<Player>().collectable = collect;
                            collect.transform.SetParent(collectView);
                            collect.transform.localPosition = Vector3.zero;
                            collect.transform.localRotation = Quaternion.Euler(0, 0, 0);
                            collect.SetActive(false);
                            Destroy(gameObject);
                            collect.layer = 6;
                        }
                    }
                    else if (num == 3)
                    {
                        if (player.position.y <= 4f)
                        {
                            player.GetComponent<Player>().collect = num;
                            player.GetComponent<Player>().collectable = collect;
                            collect.transform.SetParent(collectView);
                            collect.transform.localPosition = Vector3.zero;
                            collect.transform.localRotation = Quaternion.Euler(0, 0, 0);
                            collect.SetActive(false);
                            Destroy(gameObject);
                            collect.layer = 6;
                        }
                    }
                    else if (num == 6)
                    {
                        if (player.GetComponent<Player>().leverSolved)
                        {
                            player.GetComponent<Player>().collect = num;
                            player.GetComponent<Player>().collectable = collect;
                            collect.transform.SetParent(collectView);
                            collect.transform.localPosition = Vector3.zero;
                            collect.transform.localRotation = Quaternion.Euler(0, 0, 0);
                            collect.SetActive(false);
                            Destroy(gameObject);
                            collect.layer = 6;
                        }
                    }
                    else
                    {
                        player.GetComponent<Player>().collect = num;
                        player.GetComponent<Player>().collectable = collect;
                        collect.transform.SetParent(collectView);
                        collect.transform.localPosition = Vector3.zero;
                        collect.transform.localRotation = Quaternion.Euler(0, 0, 0);
                        collect.SetActive(false);
                        Destroy(gameObject);
                        collect.layer = 6;
                    }
                }

                if (hammer)
                {
                    player.GetComponent<Player>().hasHammer = true;
                    player.GetComponent<Player>().hammer = collect;
                    collect.transform.SetParent(collectView);
                    collect.transform.localPosition = Vector3.zero;
                    collect.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    collect.SetActive(false);
                    Destroy(gameObject);
                    collect.layer = 6;
                }
            }
        }
    }
}
