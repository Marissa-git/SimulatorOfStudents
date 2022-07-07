using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HitsOnDormitory : MonoBehaviour
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

        // if (player_component.DormitoryCanvas.activeSelf == false)
        // {
        //   if (gameObject.tag == "Model") //transform.localScale *= 0.1f;
        //{

        //  player_component.DormitoryCanvas.SetActive(true);
        //player_component.DoSomeAtcion(5);
        //  }
        //}

    
}
