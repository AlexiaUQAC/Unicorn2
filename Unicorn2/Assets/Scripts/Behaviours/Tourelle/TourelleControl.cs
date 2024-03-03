using System;
using System.Collections.Generic;
using UnityEngine;

public class TourelleControl : MonoBehaviour
{
    public TourelleBehaviour[] tourelles;
    public GameObject[] projectiles;
    public Sequencer sequencer;
    public BossColider bossColider;
    
    private List<string> _playerInRange;
    
    public Action OnShoot;

    private void OnEnable()
    {
        PlayerController.OnSudBouton += Shoot;
    }

    private void OnDisable()
    {
        PlayerController.OnSudBouton -= Shoot;
    }

    // Start is called before the first frame update
    void Start()
    {
        _playerInRange = new List<string>();
    }
    
    /*void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("ForceShoot");
            //ForceShoot();
        }
    }*/

    #region Collider Enter and Exit

    private void OnTriggerEnter(Collider other)
    {
        EventsManager.PlayerInActionSudRange(other.tag, UI_Manager.UI_type.ACTION_UI, true, "< SHOOT >");
        _playerInRange.Add(other.tag);
    }

    private void OnTriggerExit(Collider other)
    {
        EventsManager.PlayerInActionSudRange(other.tag, UI_Manager.UI_type.ACTION_UI, false, "");
        _playerInRange.Remove(other.tag);
    }

    #endregion
    public void Shoot(string s)
    {
        if (_playerInRange.Contains(s))
        {
            // TODO : Chec if there is 2 ADN in the loader and get the color 
            //int color = GetColorFromLoader();
            // Get a random projectile index 
            int color = sequencer.GetIndexFusion();
            
            if (color!=-1)
            {
                EventsManager.PlayerInActionSudRange(s, UI_Manager.UI_type.ACTION_UI, false, "");
                tourelles[0].Shoot(projectiles[color]);
                tourelles[1].Shoot(projectiles[color]);

                if (color == 3)
                {
                    bossColider.BossSaved();
                }
            }
            else
            {
                Debug.Log("Inventaire plein");
                EventsManager.PlayerInActionSudRange(s, UI_Manager.UI_type.INFO_UI, true, "Il avor fusionner les ADNs !");
            }
        }
    }
    
    /*public void ForceShoot()
    {
        // Get a random projectile index 
        int color = UnityEngine.Random.Range(0, projectiles.Length);
        tourelles[0].Shoot(projectiles[color]);
        tourelles[1].Shoot(projectiles[color]);
        OnShoot?.Invoke();
    }*/
    
}
