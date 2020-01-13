// File:    AdministratorTable.cs
// Author:  Vitaliy
// Created: 23 окт€бр€ 2016 г. 17:25:09
// Purpose: Definition of Class AdministratorTable

using System;

public class AdministratorsTable
    {
    public Administrator[] Data
    {
        get
        ;
        set
        ;
    }
   
    public void Insert(Administrator administrator)
    {
        //not released yet
    }

    public void Update(Administrator administrator)
    {
        //not released yet
    }
   
    public void Delete(int id)
    {
        throw new NotImplementedException();
    }
   
    public AdministratorsTable Find(string condition)
    {
        throw new NotImplementedException();
    }

}