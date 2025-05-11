using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionScript : MonoBehaviour
{
    //this sciript goes on camera
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray toMouse = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            bool didHit = Physics.Raycast(toMouse, out hit, 500f);
            if (didHit)
            {
                if (hit.transform.gameObject.CompareTag("Tostada"))
                {
                    SceneManager.LoadScene("Tostada");
                }
                else if (hit.transform.gameObject.CompareTag("Proteina"))
                {
                    SceneManager.LoadScene("Proteina");
                }
                else if (hit.transform.gameObject.CompareTag("Higado"))
                {
                    SceneManager.LoadScene("Higado");
                }
                else if (hit.transform.gameObject.CompareTag("Sentadilla"))
                {
                    SceneManager.LoadScene("Sentadilla");
                }
                else if (hit.transform.gameObject.CompareTag("CurlBiceps"))
                {
                    SceneManager.LoadScene("CurlBiceps");
                }
                else if (hit.transform.gameObject.CompareTag("Cardio"))
                {
                    SceneManager.LoadScene("Cardio");
                }
            }
        }
    }
}
