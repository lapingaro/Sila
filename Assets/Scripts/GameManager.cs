using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    private bool firstTry;
    private bool secondTry;
    public List<Button> cardBtns = new List<Button>();
    [SerializeField]
    private Sprite cardBack;
    public List<Sprite> cardDeck = new List<Sprite>();
    public Sprite[] cardsImages;
    private int gameTry;
    private int successCount;
    private int playerTry;

    private string firstTryName, secondTryName;
    private int firstTryIndex, secondTryIndex;
   
  

  
    private void Awake()
    {
        cardsImages = Resources.LoadAll<Sprite>("Sprites/Animals");
    }
    // Start is called before the first frame update
    void Start()
    {
        FindButton();
        btnListener();
        AddCardOnDeck();
        MixCard(cardDeck);

        gameTry = cardDeck.Count / 2;



    }

    // Update is called once per frame
    void Update()
    {


        GameCompletCheck();
        //Debug.Log(score);
    }

    void FindButton()
    {
        GameObject[] curentCards = GameObject.FindGameObjectsWithTag("card");

        for (int i = 0; i < curentCards.Length; i++)
        {
            //store the card on the scene in an array
            cardBtns.Add(curentCards[i].GetComponent<Button>());
            //assign a background image to each cards when created
            cardBtns[i].image.sprite = cardBack;
        }

    }
    //add the cards to the cardDeck List
    void AddCardOnDeck()
    {

        int cardCount = cardBtns.Count;
        int startCount = 0;

        for (int i = 0; i < cardCount; i++)
        {

            if (startCount == cardCount / 2)
            {

                startCount = 0;



            }

            cardDeck.Add(cardsImages[startCount]);
            startCount++;



        }

    }


    //Add a listener to each card when created  and assign a function to it
    void btnListener()
    {

        foreach (Button cardBtn in cardBtns)
        {
            cardBtn.onClick.AddListener(() => SelecdCard());

        }
    }


  



    //selected card
    void SelecdCard()
    {

        if (!firstTry)
        {
            //First Try
            firstTry = true;
            firstTryIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            //Get the name of the image
            firstTryName = cardDeck[firstTryIndex].name;

            cardBtns[firstTryIndex].image.sprite = cardDeck[firstTryIndex];
            





        }
        else if (!secondTry)
        {

            //second Try
            secondTry = true;
            secondTryIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            secondTryName = cardDeck[secondTryIndex].name;
            cardBtns[secondTryIndex].image.sprite = cardDeck[secondTryIndex];

            StartCoroutine(GamePaternCheck());

          

            playerTry++;


        }
    }

//check if the card are matching
    IEnumerator GamePaternCheck()
    {
        yield return new WaitForSeconds(1);

        if (firstTryName == secondTryName)
        {

            yield return new WaitForSeconds(0.6f);
            //Desable the button
            cardBtns[firstTryIndex].interactable = false;
            cardBtns[secondTryIndex].interactable = false;

            //Set the alpha chanel null
            cardBtns[firstTryIndex].image.color = new Color(0, 0, 0, 0);
            cardBtns[secondTryIndex].image.color = new Color(0, 0, 0, 0);

            successCount++;
          






        }
        else
        {
            // return the card after if the card is not matching then apply the background of the card 
            cardBtns[firstTryIndex].image.sprite = cardBack;
            cardBtns[secondTryIndex].image.sprite = cardBack;

        }
        //Reset the trying option to allow the user to interact again with the button 
        yield return new WaitForSeconds(0.6f);
        firstTry = secondTry = false;
    }
    //check if the game is completed
    void GameCompletCheck()
    {

    
         //if the number of correct pick is equal to the number of available try the game is finish
        if (successCount == gameTry)
        {
            Debug.Log("Game finished!");
            Debug.Log("You completed the game in  "  + playerTry + "  Moves ");
        }
    }

    //mix the card to avoid repetitive patern 
    void MixCard(List<Sprite> cardList)
    {

        for (int i = 0; i < cardList.Count; i++)
        {

            Sprite temp = cardList[i];
            int randomIndex = Random.Range(i, cardList.Count);
            cardList[i] = cardList[randomIndex];
            cardList[randomIndex] = temp;
        }


    }



 

}
//randomize the card game



