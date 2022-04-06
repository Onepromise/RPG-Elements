using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStats : MonoBehaviour
{

    public string charName;
    public int playerLevel = 1;
    public int currentEXP;

    public int[] expToNextLevel;
    public int maxLevel = 100;
    public int baseExp = 1000;


    public int currentHP;
    public int maxHP = 100;
    public int currentMP;
    public int maxMP = 30;
    public int[] mpLvlBonus;

    public int attack;
    public int defence;
    public int wpnPwr;
    public int armrPwr;
    public string equippedWpn;
    public string equippedArmr;
    public Sprite charImage;




    // Start is called before the first frame update
    void Start()
    {
        expToNextLevel = new int[maxLevel];
        expToNextLevel[1] = baseExp;

        for (int i = 2; i < expToNextLevel.Length; i++)
        {
            //Debug.Log(i);

            expToNextLevel[i] = Mathf.FloorToInt(expToNextLevel[i - 1] * 1.05f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Dev Tools
        if (Input.GetKey(KeyCode.G))
        {
            AddExp(500);
        }   
    }

    public void AddExp(int expToAdd)
    {
        currentEXP += expToAdd;

        if (playerLevel < maxLevel)
        {

            if (currentEXP > expToNextLevel[playerLevel])
            {
                currentEXP -= expToNextLevel[playerLevel];

                playerLevel++;

                if (playerLevel % 2 == 0)
                {
                    attack++;
                }
                else
                {
                    defence++;
                }
                maxHP = Mathf.FloorToInt(maxHP * 1.05f);
                currentHP = maxHP;

                maxMP += mpLvlBonus[playerLevel];
                currentMP = maxMP;


            }
        }

        if(playerLevel >= maxLevel)
        {
            currentEXP = 0;
        }
    }
}
