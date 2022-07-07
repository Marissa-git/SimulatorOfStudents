using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HitsOnHSE : MonoBehaviour
{
    public string getTag = "";
    public PlayersScrypt player_component;
    public ARController checkAllModel;


        void OnMouseDown()
        {

            if (player_component.DormitoryCanvas.activeSelf == false &&
                checkAllModel.dormitoryPlace == true &&
                checkAllModel.HSEPlace == true &&
                checkAllModel.MallPlace == true &&
                player_component.HSECanvas.activeSelf == false &&
                player_component.MallCanvas.activeSelf == false)
            {
                getTag = gameObject.tag;
            }

        }

    
}
