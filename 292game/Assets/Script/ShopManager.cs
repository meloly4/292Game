using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ShopManager : MonoBehaviour
{
   public int[,] shopItems= new int[5,5];
   public Text scoretxt;
   public GameObject player;

   
   
    // Start is called before the first frame update
    void Start()
    {
        scoretxt.text = ScoreScript.scoreNum.ToString() + " points to spend";
        
        //IDs
        shopItems[1,1] = 1;
        shopItems[1,2] = 2;
        shopItems[1,3] = 3;
        shopItems[1,4] = 4;

        //Price
        shopItems[2,1] = 50;
        shopItems[2,2] = 100;
        shopItems[2,3] = 150;
        shopItems[2,4] = 200;
    }


    public void buy(){
        int score = ScoreScript.scoreNum;

        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

            if (ButtonRef.GetComponent<ButtonInfo>().ItemID == 5){
                if (score >= 500){
            player.GetComponent<Shooting>().refreshammo();
            score -= 500;
            scoretxt.text= score + " points to spend";
            }
            return;
        }

        if (score >= shopItems[2,ButtonRef.GetComponent<ButtonInfo>().ItemID])
        {
            score -= shopItems[2,ButtonRef.GetComponent<ButtonInfo>().ItemID];
            scoretxt.text= score + " points to spend";
            player.GetComponent<PlayerTier>().Playertier= shopItems[1,ButtonRef.GetComponent<ButtonInfo>().ItemID];
        }
    }
}
