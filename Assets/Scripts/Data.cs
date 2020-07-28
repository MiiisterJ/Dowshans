using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Data : MonoBehaviour
{
    private static Data instance;
    #region Party Member 1
    public string memberName1;
    public int level1;
    public int statScale1;

    public int maxHP1;
    public int HP1;
    public int maxDamage1;
    public int minDamage1;
    public int damage1;
    public int exp1;
    public int maxEXP1;
    #endregion
    #region Party Member 2
    public string memberName2;
    public int level2;
    public int statScale2;

    public int maxHP2;
    public int HP2;
    public int maxDamage2;
    public int minDamage2;
    public int damage2;
    public int exp2;
    public int maxEXP2;
    #endregion
    #region Party Member 3
    public string memberName3;
    public int level3;
    public int statScale3;

    public int maxHP3;
    public int HP3;
    public int maxDamage3;
    public int minDamage3;
    public int damage3;
    public int exp3;
    public int maxEXP3;
    #endregion
    #region Party Member 4
    public string memberName4;
    public int level4;
    public int statScale4;

    public int maxHP4;
    public int HP4;
    public int maxDamage4;
    public int minDamage4;
    public int damage4;
    public int exp4;
    public int maxEXP4;
    #endregion
    void Awake()
    {
        DontDestroyOnLoad(this);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
