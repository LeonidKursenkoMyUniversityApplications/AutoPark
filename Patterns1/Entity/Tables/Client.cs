// File:    Client.cs
// Author:  ������
// Created: 23 ������� 2016 �. 12:18:25
// Purpose: Definition of Class Client

using System;

public class Client
{
   public int Id { get; set; }
   public string Name { get; set; }
   public string PassportId { get; set; }
   public DateTime RegistrationDate { get; set; }
   public string Password { get; set; }
    public bool IsBlock { get; set; }
}