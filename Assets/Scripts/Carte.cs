using TMPro;
using UnityEngine;

public class Carte : MonoBehaviour
{
    public TMP_Text valeurText;
    public TMP_Text enseigneText;
    public CarteData data;
    internal void SetData(CarteData carteData)
    {
        data = carteData;
        string text = carteData.valeur.ToString();

        switch (carteData.valeur)
        {
            case 1:
                text = "A";
                break;
            case 11:
                text = "J";
                break;
            case 12:
                text = "Q";
                break;
            case 13:
                text = "K";
                break;
        }

        valeurText.text = text;

        string enseigneString = "";
        Color color = Color.red;
        switch (carteData.enseigne)
        {
            case Enseigne.Pique:
                enseigneString = "♠";
                color = Color.black;
                break;
            case Enseigne.Coeur:
                enseigneString = "♥";
                break;
            case Enseigne.Trefle:
                enseigneString = "♣";
                color = Color.black;
                break;
            case Enseigne.Carreau:
                enseigneString = "♦";
                break;
        }

        valeurText.color = color;
        enseigneText.color = color;
        enseigneText.text = enseigneString;
    }
}
