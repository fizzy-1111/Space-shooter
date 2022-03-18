using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    [SerializeField] GameObject asteroid;
    [SerializeField] int grindSpacing = 50;
    [SerializeField] int asteroidnumOnAxis = 10;
    public List<GameObject> asterList = new List<GameObject>();
    // Start is called before the first frame update
    private void OnEnable()
    {
        EventManager.onStartGame += placeAsteroid;
        EventManager.onPlayerDeath += WaitAminute;
    }
    private void OnDisable()
    {
        EventManager.onStartGame -= placeAsteroid;
        EventManager.onPlayerDeath -= WaitAminute;
    }
    void DestroyAsteroid()
    {
        for(int i = 0; i < asterList.Count; i++)
        {
            if (asterList[i] != null)
            {
                asterList[i].SetActive(false);
                Destroy(asterList[i]);
            }
            
        }
        asterList.Clear();
    }
    void WaitAminute()
    {
        Invoke("DestroyAsteroid", 3f);
    }
    void placeAsteroid()
    {
        for(int x = 0; x < asteroidnumOnAxis; x++)
        {
            for(int y = 0; y < asteroidnumOnAxis; y++)
            {
                for(int z = 0; z < asteroidnumOnAxis; z++)
                {
                    instantiateAsteroid(x, y, z);
                }
            }
        }
    }
    void instantiateAsteroid(int x,int y,int z)
    {
       GameObject tempt= Instantiate(asteroid, 
            new Vector3(transform.position.x + (x * grindSpacing)+AsteroidOffset(),
            transform.position.y + (y * grindSpacing) + AsteroidOffset(),
            transform.position.z + (z * grindSpacing) + AsteroidOffset()), 
            Quaternion.identity, 
            transform);
        asterList.Add(tempt);
    }
    float AsteroidOffset()
    {
       return Random.Range(-grindSpacing, grindSpacing);
    }
}
