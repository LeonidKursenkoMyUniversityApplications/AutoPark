// File:    Check.cs
// Author:  Леонид
// Created: 26 ноября 2016 г. 22:27:33
// Purpose: Definition of Class Check

using Patterns1.Exceptions;
using System;
using System.IO;
using System.IO.MemoryMappedFiles;

public class CheckHandler
{
    private static CheckHandler instance;

    private Car car;    

    private int[] arrPoints;


    private CheckHandler(Car car)
    {
        this.car = car;
    }

    public static CheckHandler GetInstance(Car car)
    {
        if (instance == null)
            instance = new CheckHandler(car);
        
        return instance;
    }

    public bool MakeCheck()
    {
        int size;
        MemoryMappedFile sharedMemory;
        try
        {
            sharedMemory = MemoryMappedFile.OpenExisting("CheckCar");
        }
        catch
        {
            return false;
        }
        using (MemoryMappedViewAccessor reader = sharedMemory.CreateViewAccessor(0, 4, MemoryMappedFileAccess.Read))
        {
            size = reader.ReadInt32(0);
        }
        using (MemoryMappedViewAccessor reader = sharedMemory.CreateViewAccessor(4, size * 4, MemoryMappedFileAccess.Read))
        {
            arrPoints = new int[size];
            reader.ReadArray<int>(0, arrPoints, 0, size);
        }
        return true;
    }

    public void DoCheck()
    {
        if (MakeCheck() == true) SaveResult();
        else throw new CheckCarException("Checking cars not available");
    }

    public void DoCompare()
    {
        int[] arrPoints = FindCarCheckResult();
        bool result = true;
        if (arrPoints != null) result = Compare(arrPoints);
        if (result == false) throw new CheckCarException("Car was damaged");
    }

    public void SaveResult()
    {
        string fileName = "car_" + car.SerialNum + ".bin";
        using (TextWriter writer = File.CreateText(fileName))
        {
            writer.WriteLine(arrPoints.Length);
            foreach (int item in arrPoints)
            {
                writer.WriteLine(item);
            }
        }
        //using (var stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
        //using (var writer = new TextWriter(stream))
        //{
        //    writer.Write(arrPoints.Length);
        //    foreach (int item in arrPoints)
        //    {
        //        writer.Write(item);
        //    }
        //}
    }

    public int[] FindCarCheckResult()
    {
        string fileName = "car_" + car.SerialNum + ".bin";
        int[] arr = null;
        if (File.Exists(fileName))
        {
            
            using (StreamReader reader = new StreamReader(fileName))
            {
                string str = reader.ReadLine();                
                int length = Convert.ToInt32(str);
                arr = new int[length];
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = Convert.ToInt32(reader.ReadLine());
                }
            }

            

            //using (var stream = new FileStream(fileName, FileMode.Open))
            //using (BinaryReader reader = new BinaryReader(stream))
            //{
            //    int length = reader.ReadInt32();
            //    arr = new int[length];
            //    for (int i = 0; i < arr.Length; i++)
            //    {
            //        arr[i] = reader.ReadInt32();
            //    }
            //}            
        }
        else
        {
            throw new Exception("file " + fileName + " not exist");
        }
        return arr;
    }

    public bool Compare(int[] arrPoints2)
    {
        if (arrPoints.Length != arrPoints2.Length) return false;
        for (int i = 0; i < arrPoints.Length; i++)
        {
            if(arrPoints[i] != arrPoints2[i]) return false;
        }
        return true;
    }

    public static bool IsCheck(Car car)
    {
        string fileName = "car_" + car.SerialNum + ".bin";
        if (File.Exists(fileName))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}