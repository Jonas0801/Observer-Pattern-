using System.Collections.Generic;
using UnityEngine;

public class ExampleObserverPattern : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Youtuber dinter = new Youtuber("Dinter");
        User jonas = new User("Jonas");

        dinter.RegisterObserver(jonas);
        dinter.NotifyObserver("DinTer】玩輔助都能呼風喚雨？！召喚艾莉露璐Lulu SUP真霜+蘇瑞亞！戰勝年紀的神反應！對面塔隆整場只督我一人！Shurelya's Battlesong Lulu！");

        dinter.RemoveObserver(jonas);
        dinter.NotifyObserver("【DinTer】跟國人從遊戲吵到語音互噴？！靈魂收割薩科Shaco JG 面具+疊書！陸服才看得到這畫面？報上大名嚇傻國人！Liandry's Anguish+ Soulstealer！");
    }

}

public interface ISubject
{
    void RegisterObserver(IObserver theObserver);
    void RemoveObserver(IObserver theObserver);
    void NotifyObserver(string content);
}

public interface IObserver
{
    void Update(string massage);
}

public class Youtuber : ISubject
{
    private string name;
    private List<IObserver> observers;

    public Youtuber(string name)
    {
        this.name = name;
        observers = new List<IObserver>();
    }

    public void RegisterObserver(IObserver theObserver) { if (!observers.Contains(theObserver)) observers.Add(theObserver); }

    public void RemoveObserver(IObserver theObserver) { if (observers.Contains(theObserver)) observers.Remove(theObserver); }

    public void NotifyObserver(string content) { if (observers.Count > 0) observers.ForEach((theObserver) => theObserver.Update(content)); }
}

public class User : IObserver
{
    private string name;

    public User(string name) { this.name = name; }

    public void Update(string message) { Debug.Log($"{name} 接收了新訊息 : {message}"); }
}
