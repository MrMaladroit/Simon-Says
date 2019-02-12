using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] private Image[] optionGFX;

    public IEnumerator LightUpForTwoSeconds()
    {
        optionGFX[1].enabled = true;
        yield return new WaitForSeconds(2);
        optionGFX[1].enabled = false;

    }
}