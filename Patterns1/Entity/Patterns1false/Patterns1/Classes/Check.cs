// File:    Check.cs
// Author:  Леонид
// Created: 26 ноября 2016 г. 22:27:33
// Purpose: Definition of Class Check

using Patterns1.Exceptions;
using System;
using System.IO;
using System.IO.MemoryMappedFiles;

public class Check
{
    private static Check instance;

    private Car car;    

    private int[] arrPoints;


    private Check(Car car)
    {
        this.car = car;
    }

    public static Check GetInstance(Car car)
    {
        if (instance == null)
            instance = new Check(car);
        
        return instance;
    }

    public bool MakeCheck()
    {
        int size;
        MemoryMappedFile sharedMemory;
        try
        {
            sharedMemory = MemoryMappedFile.OpenExisting("MemoryFile");
        }
        catch(FileNotFoundException ex)
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
    }

    public void DoCompare()
    {
        int[] arrPoints = FindCarCheckResult();
        bool result = true;
        if (arrPoints != null) result = Compare(arrPoints);
        if (result != true) throw new CheckCarException();
    }

    public void SaveResult()
    {
        string fileName = "car" + car.Id + ".bin";
        using (var stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
        using (var writer = new BinaryWriter(stream))
        {
            writer.Write(arrPoints.Length);
            foreach (int item in arrPoints)
            {
                writer.Write(item);
            }
        }
    }

    public int[] FindCarCheckResult()
    {
        string fileName = "car" + car.Id + ".bin";
        int[] arr = null;
        if (File.Exists(fileName))
        {
            using (var stream = new FileStream(fileName, FileMode.Open))
            using (BinaryReader reader = new BinaryReader(stream))
            {
                int length = reader.ReadInt32();
                arr = new int[length];
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = reader.ReadInt32();
                }
            }
            
        }
        return arr;
    }

    public bool Compare(int[] arrPoints2)
    {
        if (arrPoints.Length != arrPoints2.Length) return false;
        for (int i = 0; i < arrPoints.Length; i++)
        {
            if(arrPoints[i] != arrPoints[i]) return false;
        }
        return true;
    }
}