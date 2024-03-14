using System.Collections.Generic;
using UnityEngine;

public enum Enseigne
{
    Pique,
    Coeur,
    Trefle,
    Carreau
}

public class CarteData
{
    public int valeur;
    public Enseigne enseigne;

    public CarteData(int valeur, Enseigne enseigne)
    {
        this.valeur = valeur;
        this.enseigne = enseigne;
    }
}

public class CarteManager : MonoBehaviour
{
    [SerializeField] Carte[] main = new Carte[5];
    List<CarteData> pile = new List<CarteData>(52);
    int indexCarte = 0;
    private void Awake()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 1; j <= 13; j++)
            {
                pile.Add(new CarteData(j, (Enseigne)i));
            }
        }

        // https://fr.wikipedia.org/wiki/M%C3%A9lange_de_Fisher-Yates
        // Pour i allant de n − 1 à 1 faire:
        for (int i = pile.Count - 1; i >= 1; i--)
        {
            // j ← entier aléatoire entre 0 et i
            int j = Random.Range(0, i + 1);
            // échanger a[j] et a[i]
            (pile[i], pile[j]) = (pile[j], pile[i]);
        }

        Piger();
    }

    public void Piger()
    {
        for (int i = 0; i < 5; i++)
        {
            main[i].SetData(pile[indexCarte++]);
        }
    }
}
