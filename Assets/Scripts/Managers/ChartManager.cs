using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChartManager : MonoBehaviour
{
    public static ChartManager Instance;
    public RectTransform ChartContents;

    public void SetResult(int Round, int DiceNumber)
    {
        if(ChartContents.childCount <= DiceManager.rounds)
        {
            GameObject prefab = Resources.Load("Prefabs/Column") as GameObject;
            RectTransform trans = (RectTransform)prefab.transform;
            float width = trans.sizeDelta.x;
            GameObject card = MonoBehaviour.Instantiate(prefab, ChartContents);
            GameResultCard option = card.GetComponent<GameResultCard>();
            option.SetDisplay(round: DiceManager.rounds);

            var position = card.transform.localPosition;
            position.x = DiceManager.rounds * width;
            card.transform.localPosition = position;
            Vector2 total_size = ChartContents.sizeDelta;
            total_size.x = (ChartContents.childCount + 1) * width;
            ChartContents.sizeDelta = total_size;
            option.SetDisplay(round: DiceManager.rounds, dice_number: DiceNumber, is_odd: true, is_win: true);
        }
        else
        {
            GameResultCard option = ChartContents.GetChild(DiceManager.rounds).GetComponent<GameResultCard>();
            option.SetDisplay(round: DiceManager.rounds, dice_number: DiceNumber, is_odd: true, is_win: true);
        }
        
    }
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(this);
        }
            
    }
    // Start is called before the first frame update
    void Start()
    {
        GameObject prefab = Resources.Load("Prefabs/Column") as GameObject;
        RectTransform trans = (RectTransform)prefab.transform;
        float width = trans.sizeDelta.x;
        for (int i = 0; i < 10; ++i)
        {
            GameObject card = MonoBehaviour.Instantiate(prefab, ChartContents);
            GameResultCard option = card.GetComponent<GameResultCard>();
            option.SetDisplay(round: i);

            var position = card.transform.localPosition;
            position.x = i * width;
            card.transform.localPosition = position;
        }
        Vector2 total_size = ChartContents.sizeDelta;
        total_size.x = (ChartContents.childCount + 1) * width;
        ChartContents.sizeDelta = total_size;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
