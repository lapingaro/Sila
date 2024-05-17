using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class cardLayout : MonoBehaviour
{
    [SerializeField]
    private Transform targetdisplay;
    public GameObject card;
    public float cardLength;
    public GridLayoutGroup cardGrid;
    public int contraintCount;
    private int randomInt;

    // Start is called before the first frame update


    void Awake()
    {


        // Get the transform of the parent GameObject
        targetdisplay = GetComponent<Transform>();

        RandCardLayout();
        

    }

    public void CreateLayOutFour()
    {

        cardGrid = GetComponent<GridLayoutGroup>();
        cardGrid.constraintCount = 2;

        cardLength = 4;
        for (int i = 0; i < cardLength; i++)
        {
            //Intantiate the card on the deck
            GameObject cardInner = Instantiate(card);
            cardInner.name = "" + i;
            cardInner.transform.SetParent(targetdisplay, false);

        }

    }

    public void CreateLayOutSix()
    {

        cardGrid = GetComponent<GridLayoutGroup>();
        cardGrid.constraintCount = 3;

        cardLength = 6;
        for (int i = 0; i < cardLength; i++)
        {
            GameObject cardInner = Instantiate(card);
            cardInner.name = "" + i;
            cardInner.transform.SetParent(targetdisplay, false);

        }

    }

    public void CreateLayOutNine()
    {

        cardGrid = GetComponent<GridLayoutGroup>();
        cardGrid.constraintCount = 4;

        cardLength = 8;
        for (int i = 0; i < cardLength; i++)
        {
            GameObject cardInner = Instantiate(card);
            cardInner.name = "" + i;
            cardInner.transform.SetParent(targetdisplay, false);

        }

    }

    public void RandCardLayout()
    {
        //Generate a random number to select the layout
        randomInt = Random.Range(0, 3);

        switch (randomInt)
        {

            case 0:
                CreateLayOutFour(); break;
            case 1: CreateLayOutSix(); break;
            case 2:
                CreateLayOutNine(); break;
                ;

        }

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
