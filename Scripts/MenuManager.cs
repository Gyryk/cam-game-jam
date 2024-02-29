using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
    
    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    
    public void Quit()
    {
        Application.Quit();
    }
}
