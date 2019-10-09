using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauchSpaceship : MonoBehaviour
{
    [SerializeField]int FuelCollected = 0;
    [SerializeField] int FuelRequired = 10;
    [SerializeField] GameObject[] SpawnPoints;
    [SerializeField] GameObject FuelTank;

    [SerializeField] GameObject fuelContainer;
    

    [Space(10)]
    [SerializeField] Transform[] FuelHolders;
    void OnEnable() {
        Events.OnCanopyAquired += SpawnFuelCanister;
    }

    void OnDisable() {
        Events.OnCanopyAquired -= SpawnFuelCanister;
    }

    private void SpawnFuelCanister() {
        int rand = Random.Range(0, SpawnPoints.Length - 1);
        Instantiate(FuelTank, SpawnPoints[rand].transform.position, Quaternion.identity);
    }
    // Start is called before the first frame update
    void Start()
    {
        SpawnPoints = GameObject.FindGameObjectsWithTag("Fuel");
        foreach (var item in FuelHolders) {
            item.gameObject.SetActive(false);
        }
       
    
    }

    public void GetFuel() {
        FuelCollected++;
        fuelContainer.transform.GetChild(FuelCollected).gameObject.SetActive(true);
        FuelHolders[FuelCollected-1].gameObject.SetActive(true);
        if (FuelCollected < FuelRequired) {
            SpawnFuelCanister();
            
        }
        else {
            Events.OnGameOver();
        }
        
    }

    
}
