
using UnityEngine;

public class Script2 : MonoBehaviour
{
    public GameObject sahneDegistirScript;

    void SahneDegistirmeyeEris()
    {
        var sahneDegistir = sahneDegistirScript.GetComponent<SahneDegistir>();
        sahneDegistir.SahneDegistirr(5);
    }
}
