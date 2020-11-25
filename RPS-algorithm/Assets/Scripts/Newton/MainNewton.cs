using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MainNewton : MonoBehaviour
{

    public InputField outputfield;

    public List<int> ballCount = new List<int>();
    public List<int> notListed = new List<int>();

    private List<int> balls;

    // Start is called before the first frame update
    void Start()
    {
        balls = new List<int>(){0,0,0,0,1};
    }

    public void RunFunc()
    {
        //cycles like this -
        for (int i = 0; i < 15; i++)
        {
            //1. outswing ball 5, add value of 1 to ball 5, sum 1-4
            StepOne(); 
            //2. drop right ball and add value to #4 + sum 1-5
            StepTwo();
            //3. outswing ball 1, add value 5 to that ball, sum 2-5
            StepThree();
            //4. drop ball 1, add value of 1 to 2, sum 1-5
            StepFour();
        }


        PrintBallCount();
        
    }

    private void StepOne(){
        //1. outswing ball 5, add value of 1 to ball 5, sum 1-4
        balls[4] += balls[0];
        //sum 1-4
        ballCount.Add(balls.Take(4).Sum());
        notListed.Add(balls[4]);

    }

    private void StepTwo(){
        //2. drop right ball and add value to #4 + sum 1-5
        balls[3] += balls[4];
        //sum 1-5
        ballCount.Add(balls.Sum());
    }

    private void StepThree(){
        //3. outswing ball 1, add value 5 to that ball, sum 2-5
        balls[0] += balls[4];
        //sum 2-5
        ballCount.Add(balls.Skip(1).Take(4).Sum());
        notListed.Add(balls[0]);
    }

    private void StepFour(){
        //4. drop ball 1, add value of 1 to 2, sum 1-5
        balls[1] += balls[0];
        //sum 1-5
        ballCount.Add(balls.Sum());
    }

    private void PrintBallCount() 
    {
        outputfield.text = "";

        string str = "";
        for (int i = 1; i < ballCount.Count; i+=2)
        {
            str += ballCount[i].ToString() + ", ";
        }

        for (int i = 0; i < notListed.Count; i++)
        {
            str += notListed[i].ToString() + ", ";
        }
        outputfield.text = str;
    }
}
