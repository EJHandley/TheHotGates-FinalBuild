using UnityEngine;

public class EnemyAura : MonoBehaviour
{
    private string enemyTag = "Enemy";
    private string turretTag = "Turret";

    public void ArtapanusAura()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);        
        foreach (GameObject enemy in enemies)        
        {        
            EnemyController e = enemy.GetComponent<EnemyController>();            
            if(e.artapanusAuraApplied)
            {
                e.BuffedByArtapanus();
            }                
        }
    }

    public void HydarnesAura()
    {
            
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);        
        foreach (GameObject enemy in enemies)        
        {        
            EnemyController e = enemy.GetComponent<EnemyController>();
            if(e.hydarnesAuraApplied)
            {
                e.BuffedByHydarnes();
            }
        }
    }   
    
    public void MardoniusAura()
    {
        GameObject[] spartans = GameObject.FindGameObjectsWithTag(turretTag);
        foreach (GameObject spartan in spartans)
        {
            SpartanController s = spartan.GetComponent<SpartanController>();
            if (s.mardoniusAuraApplied == false)
            {
                s.DebuffedByMardonius();
            }
        }
    }

    public void XerxesAura()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        foreach (GameObject enemy in enemies)
        {
            EnemyController e = enemy.GetComponent<EnemyController>();
            if (e.xerxesAuraApplied == false)
            {
                e.BuffedByXerxes();
            }
        }
                
        GameObject[] spartans = GameObject.FindGameObjectsWithTag(turretTag);
        foreach (GameObject spartan in spartans)
        {
            SpartanController s = spartan.GetComponent<SpartanController>();
            if(s.xerxesAuraApplied == false)
            {
                s.DebuffedByXerxes();
            }
        }
    }
}
