using UnityEngine;
using UnityEngine.UI;

public class applicationquit : MonoBehaviour
{
    void Start()
    {
        // Add a listener to the button's onClick event
        GetComponent<Button>().onClick.AddListener(QuitApplication);
    }

    public void QuitApplication()
    {
        // Quit the application when the button is clicked
        Debug.Log("application's gonna quit");
        Application.Quit();
    }
}
