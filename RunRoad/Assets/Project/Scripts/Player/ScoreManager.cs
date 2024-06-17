using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI score;
    private float Curscore;
    private float AddScore;
    public GameObject player;
   
    private void Start()
    {
        Curscore = 0; 
    }

    private void Update()
    {
        Upscore();
    }

    public void Upscore()
    {
        score.text = Curscore.ToString();
        AddScore = Mathf.Clamp(player.transform.position.z/100,0, player.transform.position.z/100);
        Curscore += (float)(Time.deltaTime * 0.1) + AddScore;
    }    
}
