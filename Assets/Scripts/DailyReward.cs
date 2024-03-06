using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DailyReward : MonoBehaviour
{
    public bool initialized;
    public long rewardGivingTimeTicks;
    public GameObject rewardMenu;
    public Text remainingTimeText;

    private void Start()
    {
        if(rewardMenu.activeInHierarchy == false)
        {
            GameObject.FindWithTag("rewardparticle1").GetComponent<ParticleSystem>().Stop();
            GameObject.FindWithTag("rewardparticle2").GetComponent<ParticleSystem>().Stop();
        }
    }
    public void InitializeDailyRewrd()
    {
        //PlayerPrefs.SetString("lastDailyReward", (System.DateTime.Now.Ticks - 864000000000 + 10 * 10000000).ToString()); //10sn'ye düþürüyor test amaçlý
        if (PlayerPrefs.HasKey("lastDailyReward"))
        {
            rewardGivingTimeTicks = long.Parse(PlayerPrefs.GetString("lastDailyReward")) + 864000000000;
            long currentTime = System.DateTime.Now.Ticks;
            if (currentTime >= rewardGivingTimeTicks)
            {
                GiveReward();
            }
        }
        else
        {
            GiveReward();
        }initialized = true;
    }
    public void GiveReward()
    {
        LevelController.Current.DailyReward();
        rewardMenu.SetActive(true);
        PlayerPrefs.SetString("lastDailyReward", System.DateTime.Now.Ticks.ToString());
        rewardGivingTimeTicks = long.Parse(PlayerPrefs.GetString("lastDailyReward")) + 864000000000;
        GameObject.FindWithTag("rewardparticle1").GetComponent<ParticleSystem>().Play();
        GameObject.FindWithTag("rewardparticle2").GetComponent<ParticleSystem>().Play();
    }
    void Update()
    {
        if (initialized)
        {
            if (CameraControl.Current.GiftMenu.activeInHierarchy || LevelController.Current.startMenu.activeInHierarchy)
            {
                long currentTime = System.DateTime.Now.Ticks;
                long remainingTime = rewardGivingTimeTicks-currentTime;
                if (remainingTime <= 0)
                {
                    GiveReward();
                }
                else
                {
                    System.TimeSpan timeSpan = System.TimeSpan.FromTicks(remainingTime);
                    remainingTimeText.text = string.Format("{0}:{1}:{2}", timeSpan.Hours.ToString("D2"), timeSpan.Minutes.ToString("D2"), timeSpan.Seconds.ToString("D2"));
                }
            }
        }
    }
}
