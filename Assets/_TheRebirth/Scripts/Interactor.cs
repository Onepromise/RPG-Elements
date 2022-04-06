using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    // creating a list of interactable items
    List<Interaction> nearByInteractions = new List<Interaction>();

    
    private void OnTriggerEnter(Collider other)
    {
        //taking the items that are interactable within range and adding
        //them to the Interaction list
        Interaction otherInteraction = other.GetComponent<Interaction>();
        if (otherInteraction)
        {
            nearByInteractions.Add(otherInteraction);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Taking the items that are interactable and are exiting and removing
        //them from the Interaction list
        Interaction otherInteraction = other.GetComponent<Interaction>();
        if (otherInteraction)
        {
            nearByInteractions.Remove(otherInteraction);
        }
    }

    public Interaction ClosestObject()
    {
        // calls the closest items into a forloop to determin which is the closet
        
        //Using null to create the lowest possible distance (More of a placeholder for nothing)
        Interaction closestInteraction = null;

        //creates the largest possible number
        float closestDistance = float.MaxValue;

        //forloop. For everyobject that enters in range it runs through it.
        for(int i = 0; i<nearByInteractions.Count; i++)
        {
            //if an object gets removed, this will check and tell the forloop
            //to remove and go back a step so it doesn't skip an item
            //and continues the forloop
            //continue means stop doing this code and move on to the next item
            if (!nearByInteractions[i])
            {
                nearByInteractions.Remove(nearByInteractions[i]);
                i--; 
                continue;
            }
            //takes all the objects in the forloop and gathers the postion of player and position of object
            float Distance = Vector3.Distance(transform.position, nearByInteractions[i].transform.position);

            //if the distance is closer than the closest distance it will make the item the new closest interaction. 
            if(Distance < closestDistance)
            {
                closestDistance = Distance;
                closestInteraction = nearByInteractions[i];
            }
        }

        return closestInteraction;

    }

}
