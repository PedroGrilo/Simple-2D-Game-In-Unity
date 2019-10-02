    using System;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    public class ItemsToBuy : MonoBehaviour{
        public int fireballCost;
        public int heartsCost;
        private int maxItems = 2;
        public Text coins; 

        public GameObject Dialog;
        public TextMeshProUGUI DialogText;

    // Start is called before the first frame update
    void Start()
    {
        FireballCost();
    }

    private void DesactivateAll(){
        this.gameObject.transform.GetChild(0).gameObject.SetActive(false); //fireball
        this.gameObject.transform.GetChild(1).gameObject.SetActive(false); //hearts
    }
    

    private void FireballCost(){
        DesactivateAll();
        this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        this.gameObject.transform.GetChild(this.gameObject.transform.childCount-1).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = fireballCost.ToString();
    }
    
    
    private void LivesCost(){
        DesactivateAll();
        this.gameObject.transform.GetChild(1).gameObject.SetActive(true);
        this.gameObject.transform.GetChild(this.gameObject.transform.childCount-1).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = heartsCost.ToString(); ;
    }


    public void Next(){
        bool fireball =  gameObject.transform.GetChild(0).gameObject.active;
        bool hearts = gameObject.transform.GetChild(1).gameObject.active;

        if (fireball)
            LivesCost();
        
        if (hearts)
            FireballCost();
    }

    public void BuyItem(){

        bool activeDialog = false;
        bool fireball =  gameObject.transform.GetChild(0).gameObject.active;
        bool hearts = gameObject.transform.GetChild(1).gameObject.active;

        if (fireball && Int32.Parse(coins.text)>=fireballCost){
            PlayerStats.Coins -= fireballCost;
            PlayerStats.Fireball++;
        }
        else{
            activeDialog = true;
        }
        if (hearts && Int32.Parse(coins.text)>=heartsCost){
            PlayerStats.Coins -= heartsCost;
            PlayerStats.Hearts++;
        }
        else{
            activeDialog = true;
        }
       
        if(activeDialog){
            DialogText.text = "Enough money :(";
            Dialog.SetActive(true);
        }
        
        coins.text = PlayerStats.Coins.ToString();
    }
}
