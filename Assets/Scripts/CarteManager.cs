using System.Collections.Generic;
using TMPro;
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
    [SerializeField] TMP_Text comboText;
    [SerializeField] Carte[] main = new Carte[5];
    List<CarteData> pile = new List<CarteData>(52);
    int indexCarte = 0;
    private void Awake()
    {
        InitPile();
        Piger();
    }

    private void InitPile()
    {
        pile.Clear();
        indexCarte = 0;

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
            int j = UnityEngine.Random.Range(0, i + 1);
            // échanger a[j] et a[i]
            (pile[i], pile[j]) = (pile[j], pile[i]);
        }
    }

    public void RemplacerCarte(int index)
    {
        if (indexCarte >= 50)
        {
            InitPile();
        }

        main[index].SetData(pile[indexCarte++]);
        VerifierCombo();
    }

    public void Piger()
    {
        if (indexCarte >= 46)
        {
            InitPile();
        }

        for (int i = 0; i < 5; i++)
        {
            main[i].SetData(pile[indexCarte++]);
        }
        VerifierCombo();
    }

    private void VerifierCombo()
    {
        if (ComboCarre())
        {
            comboText.text = "CARRE (4 OF A KIND)";
            return;
        }

        if (ComboFull())
        {
            comboText.text = "FULL (FULL HOUSE)";
            return;
        }

        if (ComboCouleur())
        {
            comboText.text = "COULEUR (FLUSH)";
            return;
        }

        if (ComboSuite())
        {
            comboText.text = "SUIT (STRAIGHT)";
            return;
        }

        if (ComboDoublePaire())
        {
            comboText.text = "DOUBLE PAIRE (2 PAIRS)";
            return;
        }

        if (ComboPaire())
        {
            comboText.text = "PAIRE (PAIR)";
            return;
        }

        comboText.text = "CARTE HAUTE";
    }

    private bool ComboCarre()
    {
        return false;
    }

    private bool ComboFull()
    {
        return false;
    }

    private bool ComboCouleur()
    {
        if (main[0].data.enseigne != main[1].data.enseigne)
        {
            return false;
        }

        if (main[0].data.enseigne != main[2].data.enseigne)
        {
            return false;
        }

        if (main[0].data.enseigne != main[3].data.enseigne)
        {
            return false;
        }

        if (main[0].data.enseigne != main[4].data.enseigne)
        {
            return false;
        }

        return true;
    }
    private bool ComboSuite()
    {
        return false;
    }

    private bool ComboDoublePaire()
    {
        return false;
    }
    private bool ComboPaire()
    {
        return false;
    }
}
