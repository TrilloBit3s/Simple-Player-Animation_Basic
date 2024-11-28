using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VidaPlayer : MonoBehaviour
{
    public float vida = 100;
    public Image barraDeVida;
    public TMP_Text TextoSaude; // Alterado de Text para TMP_Text

    void Update()
    {
        AtualizacaoInterface();
    }

    void AtualizacaoInterface()
    {
        vida = Mathf.Clamp(vida, 0, 100);
        barraDeVida.fillAmount = vida / 100;

        TextoSaude.text = "+" + vida.ToString("f0");

        if (vida == 0)
            TextoSaude.text = "-" + vida.ToString("f0"); // Is Dead
    }
}
