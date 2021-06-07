using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ComboNode = System.Collections.Generic.Dictionary<uint, uint>;

public class SpawnerAbilitat : MonoBehaviour
{
    public Animator disparo_ac;
    public Animator ice_shot_ac;
    public Animator toxic_shot_ac;
    public Animator heal_AC;
    public Proyectil disparo;
    public Proyectil ice_shot;
    public Proyectil toxic_shot;

    enum BUTTONS {
        UP=0x01,
        DOWN=0x02,
        LEFT=0X04,
        RIGHT=0x08,
        COMBO_END=0xFFFFFFF,
    };

    uint buttons = 0;
    uint prebuttons = 0;
    uint comboIndex = 0;

    uint[] combo;

    string[] messages;

    List<ComboNode> nodes = new List<ComboNode>();

    List<uint[]> combos = new List<uint[]>();


    public float rateFire=2;
    float nextFire;

    // Start is called before the first frame update
    void Start()
    {

        nextFire = 0;

        combos.Add (new uint[] { 
            (uint)BUTTONS.RIGHT, 0, 
            (uint)BUTTONS.LEFT, 0, 
            (uint)BUTTONS.RIGHT, 0, 
            (uint)BUTTONS.LEFT, 0, 
            (uint)BUTTONS.COMBO_END });
        
        combos.Add( new uint[] {
            (uint)BUTTONS.UP, 0,
            (uint)BUTTONS.DOWN, 0,
            (uint)BUTTONS.UP, 0,
            (uint)BUTTONS.DOWN, 0,
            (uint)BUTTONS.COMBO_END+1 });

        combos.Add(new uint[] {
            (uint)BUTTONS.LEFT, 0,
            (uint)BUTTONS.RIGHT, 0,
            (uint)BUTTONS.UP, 0,
            (uint)BUTTONS.DOWN, 0,
            (uint)BUTTONS.COMBO_END + 2 });

        messages = new string[]
        {"Fireball","Toxic","Ice", };
        BuildNodes();
    }


    void UpdateButtons()
    {
        prebuttons = buttons;
        buttons = 0;

        buttons |= Input.GetKey(KeyCode.UpArrow) == true ? (uint)(BUTTONS.UP) : 0;

        buttons |= Input.GetKey(KeyCode.DownArrow) == true ? (uint)(BUTTONS.DOWN) : 0;

        buttons |= Input.GetKey(KeyCode.LeftArrow) == true ? (uint)(BUTTONS.LEFT) : 0;

        buttons |= Input.GetKey(KeyCode.RightArrow) == true ? (uint)(BUTTONS.RIGHT) : 0;


    }

    bool DidButtonChange()
    {
        if (prebuttons!=buttons)
        {
            return true;
        }
        return false;
    }

    void DetectCombo()
    {
        if (DidButtonChange())
        {
            if (nodes[(int)comboIndex].ContainsKey(buttons))
            {
                if (comboIndex > 268435457 || comboIndex < 0)
                {
                    comboIndex = 0;
                }
              
                comboIndex = nodes[(int)comboIndex][buttons];

                if (comboIndex >= (uint)BUTTONS.COMBO_END && Time.time>nextFire)
                {
                    Debug.Log(messages[comboIndex-(uint)BUTTONS.COMBO_END]);
                    if (comboIndex==268435455)
                    {
                        nextFire = Time.time + rateFire;
                        disparar_fire(transform.position, transform.rotation);
                        comboIndex = 0;

                    }
                    if (comboIndex== 268435456)
                        {
                        nextFire = Time.time + rateFire;
                        disparar_toxic(transform.position, transform.rotation);
                            comboIndex = 0;

                    }
                    if (comboIndex== 268435457)
                    {
                        nextFire = Time.time + rateFire;
                        disparar_ice(transform.position, transform.rotation);
                        comboIndex = 0;

                    }

                    comboIndex = 0;
                    ResetButtons();
                }
            }
            else
            {
                Debug.Log("error!!!");
                comboIndex = 0;
                ResetButtons();
            }
        }
    }
      


    void BuildNodes()
    {
        uint nodeCounter = 0;
        nodes.Add(new ComboNode());

        for (int row = 0; row < combos.Count; row++)
        {
            nodeCounter = 0;
            uint[] currentCombo = combos[row];
            for (int i = 0; i < currentCombo.Length - 1; i++)
            {
                if (!nodes[(int)nodeCounter].ContainsKey(currentCombo[i]))
                {
                    if (i < currentCombo.Length - 2)
                    {
                        nodes[(int)nodeCounter].Add(currentCombo[i], (uint)nodes.Count);
                        nodeCounter = (uint)nodes.Count;
                        nodes.Add(new ComboNode());
                    }
                    else
                    {
                        nodes[(int)nodeCounter].Add(currentCombo[i], currentCombo[i + 1]);
                    }
                }
                else
                {
                    nodeCounter = nodes[(int)nodeCounter][currentCombo[i]];
                }
            }
        }
    }

    void ResetButtons()
    {
        prebuttons = 0;
        buttons = 0;
}


    // Update is called once per frame
    void Update()
    {
        UpdateButtons();
        DetectCombo();
    }

    /*
     * Dispara proyectils en una posicio i una rotacio donades per parametre.
     */
    public void disparar_fire(Vector3 position, Quaternion angle)
    {
        Proyectil pro = Instantiate(disparo);
        pro.transform.position = position;
        pro.transform.rotation = angle;
    }

    public void disparar_ice(Vector3 position, Quaternion angle)
    {
        Proyectil pro = Instantiate(ice_shot);
        pro.transform.position = position;
        pro.transform.rotation = angle;
    }

    public void disparar_toxic(Vector3 position, Quaternion angle)
    {
        Proyectil pro = Instantiate(toxic_shot);
        pro.transform.position = position;
        pro.transform.rotation = angle;
    }
}