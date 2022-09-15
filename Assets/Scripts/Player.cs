using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System.Threading.Tasks;

public class Player : MonoBehaviour, IShootable
{
    [SerializeField] private float health;
    [SerializeField] private float currentMaxHealth;
    [SerializeField] private int starsCount;
    [SerializeField] private Image healthImage;
    [SerializeField] private string path;
    [SerializeField] private int bestScore;
    
    private int score = 0;

    //инстанс объекта
    public static Player instance;

    //оставили свойство просто чтобы реализовать интерфейс
    public int myCost { get; set; }

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        LoadSave();
        VisualManager.instance.DrawScore(score);
        VisualManager.instance.StarsQuantity(starsCount);
    }
    private void LoadSave()
    {
#if UNITY_EDITOR
        path = Path.Combine(Application.dataPath,"Save.json");
#else
        path = Path.Combine(Application.persistentDataPath,"Save.json");
#endif
        if (File.Exists(path))
        {
            string temp = File.ReadAllText(path);
            Save saveGame = JsonUtility.FromJson<Save>(temp);
            starsCount = saveGame.stars;
            bestScore = saveGame.hightScore;
        }

    }

    public void CreateSave()
    {
        Save save = new Save();
        save.stars = starsCount;

        if (bestScore < score)
            save.hightScore = score;
        else save.hightScore = bestScore;

        string json = JsonUtility.ToJson(save);
        File.WriteAllText(path, json);
    }
    private void OnApplicationQuit()
    {
        CreateSave();
    }

    private void OnMouseDrag()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = transform.position.z;
        transform.position = mousePos;
    }

    public void ChangeHealth(int healthDelta)
    {
        health += healthDelta;
        if (health <= 0)
        {
            CreateSave();
            OnDeath();
            GameManager.isGaming = false;
            Destroy(gameObject);
        }
        VisualManager.instance.Drawator(healthImage, health, currentMaxHealth);
    }
    public void StarsQuantity(int starsDelta)
    {
        starsCount += starsDelta;
        VisualManager.instance.StarsQuantity(starsCount);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        col.gameObject.GetComponent<Obstacle>()?.ToHitSpaceship(this);
    }

    public void OnShotHit()
    {
        Debug.Log("OUCH !!");
    }

    public void CountScore(int scoreCost)
    {
        score += scoreCost;
        VisualManager.instance.DrawScore(score);
    }

    private async void OnDeath()
    {
        await Task.Delay(1000);
        VisualManager.instance.DrawLoosePanel(bestScore > score ? bestScore : score, score);
    }

}

public class Save
{
    public int score;
    public int stars;
    public int hightScore;
}
