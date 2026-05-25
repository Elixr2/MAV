using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public void OnClickStart()
    {
        SceneManager.LoadScene("Stage 0");
    }

}
