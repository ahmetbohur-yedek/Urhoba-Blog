using UnityEngine;
using UnityEngine.SceneManagement;

public class SahneDegistir : MonoBehaviour
{
    
    public void SahneDegistirr(int gidilecekSahne)
    {
        SceneManager.LoadScene(gidilecekSahne, LoadSceneMode.Single);
    }
  
}
