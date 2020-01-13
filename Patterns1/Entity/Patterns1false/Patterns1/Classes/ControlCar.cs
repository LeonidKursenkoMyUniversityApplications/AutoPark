// File:    ControlCar.cs
// Author:  Леонид
// Created: 23 октября 2016 г. 13:51:23
// Purpose: Definition of Class ControlCar

using Patterns1.Exceptions;
using System;

public class ControlCar
{
    private static ControlCar instance;

    public Car Car { get; set; }

    public Terminal Terminal {get; set;}

    private Check check;

    private ControlCar(Car car)
    {
        Car = car;
        //Terminal = Terminal.GetInstance();
        check = Check.GetInstance(car);
    }

    public static ControlCar GetInstance(Car car)
    {
        if (instance == null)
            instance = new ControlCar(car); 
           
        return instance;
    }

    public void InputCar()
    {
        check.DoCheck();
        Terminal.OnInputCarUpdate();
    }
   
    public void OutputCar()
    {
        if (check.MakeCheck() == true)
        {
            check.DoCompare();
            Terminal.OnOutputCarUpdate();
        }
    }
}